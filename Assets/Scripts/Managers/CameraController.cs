using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraController instance;
    public Camera mainCamera;

    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos; // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraStartPos = new Vector3(0, 20, 0);
    public Vector3 cameraOffset;
    public Vector3 cameraBaseRot;
    // Vector3 cameraMovePos;

    public float cameraMoveSpeed;
    public float cameraZoomInSpeed;

    public float maxZoomInDist;
    public float minZoomInDist;

    Transform zoomingCharacter;

    bool canChaseMousePos = false;
    bool isCanControl = true;

    public bool IsCanControl
    {
        get{return isCanControl;}
        set{isCanControl = value;}
    }

    public bool isDirectControl = false;

    public bool IsDirectControl
    {
        get{return isDirectControl;}
        set{isDirectControl = value;}
    }

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.rotation = Quaternion.Euler(cameraBaseRot);
        mainCamera.transform.position = cameraStartPos;
        initialCameraPos = mainCamera.transform.position;
    }

    // private void Update()
    // {
    //     SwitchCameraControlMethod();
    // }

    public void TurnToCameraToNowCharacter()
    {
        if(NowTurnCharacterManager.nowPlayCharacter)
            zoomingCharacter = NowTurnCharacterManager.nowPlayCharacter.transform;
    }

    // public void ControlMouseWithCharacter()
    // {
    //     if (!canChaseMousePos) return;

    //     if (zoomingCharacter && SearchWithRayCast.GetHitPoint() != Vector3.zero)
    //     {

    //         Vector3 dirPos = new Vector3(SearchWithRayCast.GetHitPoint().x, 0, SearchWithRayCast.GetHitPoint().z) - new Vector3(zoomingCharacter.transform.position.x, 0, zoomingCharacter.transform.position.z);

    //         if (Vector2.Distance(dirPos, zoomingCharacter.transform.position) > 0.5f)
    //         {
    //             dirPos.x = Mathf.Clamp(dirPos.x, -2.5f, 2.5f);
    //             dirPos.z = Mathf.Clamp(dirPos.z, -2.5f, 2.5f);

    //             Vector3 culculatePos = zoomingCharacter.transform.position + cameraOffset + new Vector3(dirPos.x, 0, dirPos.z);
    //             transform.position = Vector3.Lerp(transform.position, culculatePos, 2f * Time.deltaTime);
    //         }
    //     }
    // }

    public void SwitchCameraControlToDirect(bool isCommanded)
    {
        if(isCanControl == false) return;

        if(isCommanded)
        {
            isDirectControl = true;
            DirectMoveCamera();
        }
            
        else
        {
            isDirectControl = false;
            MoveToCharacter();
        }
            
    }

    private void DirectMoveCamera()
    {
        Vector3 vec = new Vector3((Input.GetAxis("Horizontal")), 0, Input.GetAxis("Vertical"));
        transform.Translate(vec * cameraMoveSpeed * Time.deltaTime, Space.World);
    }

    private void MoveToCharacter()
    {
        // canControlCamera = true;
        if (zoomingCharacter)
        {
            if(!isDirectControl)
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, zoomingCharacter.transform.position + cameraOffset, 3f * Time.deltaTime);
        }
    }

    public void ZoomWithWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * cameraZoomInSpeed;

        if (scroll < 0 && mainCamera.fieldOfView <= maxZoomInDist)
            mainCamera.fieldOfView = maxZoomInDist;
        else if (scroll > 0 && mainCamera.fieldOfView >= minZoomInDist)
            mainCamera.fieldOfView = minZoomInDist;
        else
            mainCamera.fieldOfView += scroll;
    }

    public Transform GetZoomingCharacter()
    {
         return zoomingCharacter;
    }

    public void SetZoomingCharacter(Transform _character)
    {
        if(!isCanControl) return;

        isDirectControl = false;
        zoomingCharacter = _character;
    } 
    
    public void ChangeCanChaseMousePos(bool _on) => canChaseMousePos = _on;
    
}
