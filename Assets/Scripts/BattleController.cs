using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // 전투가 시작되면 전투를 파악하는 용도로 사용.
    // 전투 행동 순서, 사망여부 처리, 턴의 경과 등을 담당
    // 캐릭터 다수한테 전투관련 스크립트를 부착하는 것보다, 하나의 스크립트에서 처리하게 끔하여 최적화 추구.

    // ***** 전투 내 캐릭터 처리 *****
    //public CharacterBattleAction cba; // 전투 내에 진행되는 캐릭터 행동을 모아놓은 스크립트.

    // 외부 참조
    public BattleUIManager battleUIManager;
    // public CharacterBattleAction characterBattleAction;
    public BombManager bombManager;

    // ***** 전투 내 RayCast 처리 *****
    Ray ray;
    public RaycastHit hit;

    public Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.
    public List<Temp_Character> characterList = new List<Temp_Character>(); // 전투에 참여하는 캐릭터들을 담는 리스트.

    public List<Stat> statList = new List<Stat>(20); // 각 캐릭터의 이니시에이티브 수치를 넣어 결산하는 용도로 사용되는 리스트.

    public int battleRound = 0; // 배틀 경과 라운드
    public int battleturn = 0; // 배틀 경과 턴

    int index = 0; // 현재 선택된 캐릭터를 측정하기 위해 사용되는 카운터.

    public bool doZoom;
    public bool characterTurn;

    //public delegate void DoYourTurn(); //턴이 시작될 때, 진행할 캐릭터의 
    //public DoYourTurn turnStart;

    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos = new Vector3(); // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraOffset = new Vector3();
    public float cameraMoveSpeed;

    private void Start()
    {
        characterList.Clear();
        RolltoInitiative(); // 모든 캐릭터들의 initiative를 계산한 후, characterList에 담는다.(전투 준비)

        initialCameraPos = Camera.main.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // 다음 차례의 캐릭터 설정.
        {
            hit.point = Vector3.zero;

            battleturn++;
            
            doZoom = true;

            nowPlayCharacter = characterList[index];

            if (index < characterList.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
                battleRound++;
            }

            if (nowPlayCharacter && doZoom)
            {
                battleUIManager.ActivateActionUI();
            }
        }
        
    }

    void FixedUpdate()
    {
        if (doZoom)
        {
            CameraZoomIn();
        }
        else
        {
            CameraZoomOut();
        }
    }

    void RolltoInitiative() // 우선권 결정
    {
        if (characterList.Count == 0)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Temp_Character temp = obj.GetComponent<Temp_Character>();

                temp.info.statInitiative.CheckCal(0, Random.Range(1, 7), 0);
                Debug.Log(temp.name + "의 우선권: " + temp.info.statInitiative.resultStat);

                characterList.Add(obj.GetComponent<Temp_Character>());

                for (int t = 0; t < characterList.Count; t++)
                {
                    characterList.Sort(SortbyInitiative);
                    // Debug.Log("리스트 내 " + characterList[t].name + "의 우선도: " + characterList[t].info.statInitiative.resultStat);
                }
            }
        }
    }

    // nowPlayCharacter를 향해 카메라를 확대 및 이동할 때 사용하는 함수
    public void CameraZoomIn()
    {
        if (nowPlayCharacter)
        {
            Vector3 relativePos = Camera.main.transform.position - nowPlayCharacter.transform.position;
            //Quaternion camTurnAngle = Quaternion.AngleAxis(0.25f, Vector3.up); //Input.GetAxis("Mouse X") * 0.5f : 마우스 입력에 따라 바뀌게 끔 하는 식은 요거.
            //cameraOffset = camTurnAngle * cameraOffset; 

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed);
            //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Camera.main.transform.rotation * camTurnAngle, Time.deltaTime);
            //Camera.main.transform.LookAt(Vector3.Lerp(Camera.main.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
            Camera.main.transform.LookAt(Vector3.Lerp(nowPlayCharacter.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
        }
    }

    public void CameraZoomOut()
    {
        if (nowPlayCharacter)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, initialCameraPos, cameraMoveSpeed);
            Camera.main.transform.LookAt(Vector3.Lerp(nowPlayCharacter.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
        }
    }

    void CameraRotationControl()
    {
        //Quaternion camTurnAngle = Quaternion.AngleAxis(0.25f, Vector3.up); //Input.GetAxis("Mouse X") * 0.5f : 마우스 입력에 따라 바뀌게 끔 하는 식은 요거.
        //cameraOffset = camTurnAngle * cameraOffset; 
        //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Camera.main.transform.rotation * camTurnAngle, Time.deltaTime);
    }

    static int SortbyInitiative(Temp_Character a, Temp_Character b)
    {
        return -a.info.statInitiative.resultStat.CompareTo(b.info.statInitiative.resultStat);
    }

    // 캐릭터의 이동 좌표, 폭탄 전달 대상, 스킬 시전 대상 결정 등을 하나로 처리하기 위해 raycast 기능을 여기에 작성.
    public void SearchwithRayCast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
    }

    public void DoOrder()
    {
        doZoom = !doZoom;
    }

}
