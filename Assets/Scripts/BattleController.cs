using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BattlePhase { Nothing, BattleStart, RoundStart, CharacterTurnStart, CharacterTurn, CharacterTurnEnd, RoundEnd, BattleEnd }
public class BattleController : MonoBehaviour
{
    // 전투가 시작되면 전투를 파악하는 용도로 사용.
    // 전투 행동 순서, 사망여부 처리, 턴의 경과 등을 담당
    // 캐릭터 다수한테 전투관련 스크립트를 부착하는 것보다, 하나의 스크립트에서 처리하게 끔하여 최적화 추구

    // 외부 참조
    public BattleUIManager battleUIManager;
    // public CharacterBattleAction characterBattleAction; 
    public BombManager bombManager;

    // ***** 전투 내 RayCast 처리 *****
    Ray ray;
    public RaycastHit hit;

    public Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.

    public List<Temp_Character> characterList = new List<Temp_Character>(); // 전투에 참여하는 캐릭터들을 담는 리스트.

    public Camera mCamera;

    public int battleRound = 0; // 배틀 경과 라운드
    public int battleTurn = 0; // 배틀 경과 턴

    BattlePhase battlePhase = BattlePhase.Nothing;

    int index = 0; // 현재 선택된 캐릭터를 측정하기 위해 사용되는 카운터.

    public bool doZoom;

    public int maxActionPoint;
    public int curActionPoint;
    public int canSetBombinBattle;


    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos = new Vector3(); // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraOffset = new Vector3();
    public float cameraMoveSpeed;

    private void Start()
    {
        characterList.Clear();
        RolltoInitiative(); // 모든 캐릭터들의 initiative를 계산한 후, characterList에 담는다.(전투 준비)
        initialCameraPos = Camera.main.transform.position;
        mCamera = Camera.main;
        // instance = this;
        battlePhase = BattlePhase.BattleStart;
        Debug.Log(characterList.Count);
        battleUIManager.GetActCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // 다음 차례의 캐릭터 설정.
        {
            // hit.point = Vector3.zero;

            battleTurn++;
            battlePhase = BattlePhase.CharacterTurn;

            doZoom = true;

            nowPlayCharacter = characterList[index];
            CharacterBattleAction.instance.from = GetNowCharacterPos();
            // CharacterBattleAction.instance.alreadymoveDist = 0;

            bombManager.Countdown();
            bombManager.GetBoomer(nowPlayCharacter);

            if (index < characterList.Count - 1)
                index++;
            else
            {
                index = 0;
                battleRound++;
            }

            if (nowPlayCharacter && doZoom)
                battleUIManager.ActivateActionUI(doZoom);
        }

        // SearchwithRayCast();

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                SearchwithRayCast();

                if (hit.collider != null && hit.collider.GetComponent<Temp_Character>()) //hit.collider != null && 
                {
                    battleUIManager.uitoShowBomb.OnOffShowBombUI(true);
                    battleUIManager.uitoShowBomb.ShowBomb(hit.collider.GetComponent<Temp_Character>());
                }
                else
                {
                    battleUIManager.uitoShowBomb.OnOffShowBombUI(false);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            battleUIManager.CloseUI();
        }

        if (bombManager.setupGo)
        {
            //bombManager.ReadytoSetup(hit.point);
            doZoom = false;
            SearchwithRayCast();
            bombManager.ReadytoSetup(hit.point, nowPlayCharacter);
        }
    }

    // 코루틴으로 1초마다 돌아가게 만들까?
    void FixedUpdate()
    {
        if (nowPlayCharacter)
        {
            if (doZoom)
                CameraZoomIn(nowPlayCharacter);
            else
                CameraZoomOut(nowPlayCharacter);
        }
        else if( hit.collider != null && hit.collider.GetComponent<Temp_Character>())
            CameraZoomIn(hit.collider.GetComponent<Temp_Character>());
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
    public void CameraZoomIn(Temp_Character _nowCharacter)
    {
        if (_nowCharacter)
        {
            Vector3 relativePos = mCamera.transform.position - _nowCharacter.transform.position;
            //Quaternion camTurnAngle = Quaternion.AngleAxis(0.25f, Vector3.up); //Input.GetAxis("Mouse X") * 0.5f : 마우스 입력에 따라 바뀌게 끔 하는 식은 요거.
            //cameraOffset = camTurnAngle * cameraOffset; 

            mCamera.transform.position = Vector3.Lerp(mCamera.transform.position, _nowCharacter.transform.position + cameraOffset, cameraMoveSpeed);
            //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Camera.main.transform.rotation * camTurnAngle, Time.deltaTime);
            //Camera.main.transform.LookAt(Vector3.Lerp(Camera.main.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
            mCamera.transform.LookAt(Vector3.Lerp(_nowCharacter.transform.position, _nowCharacter.transform.position + cameraOffset, cameraMoveSpeed));
        }
    }

    public void CameraZoomOut(Temp_Character _nowCharacter)
    {
        if (_nowCharacter)
        {
            mCamera.transform.position = Vector3.Lerp(mCamera.transform.position, initialCameraPos, cameraMoveSpeed);
            mCamera.transform.LookAt(Vector3.Lerp(_nowCharacter.transform.position, _nowCharacter.transform.position + cameraOffset, cameraMoveSpeed));
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
        ray = mCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 100);
    }

    public void SetNowCharacterPos(Vector3 _vec){
        nowPlayCharacter.transform.position = _vec;
    }

    public Vector3 GetNowCharacterPos(){
        return nowPlayCharacter.transform.position;
    }
    public Vector3 GetHitPoint(){
        return hit.point;
    }

    public Temp_Character GetTemp_Character(){
        return nowPlayCharacter;
    }
    public void SetTemp_Character( Temp_Character _now){
        nowPlayCharacter = _now;
    }
}
