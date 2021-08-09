using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraController instance;
    public Camera mainCamera;

    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos = new Vector3(); // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraOffset = new Vector3();
    public Vector3 cameraBasePos = new Vector3(0, 20, 0);
    public Vector3 cameraBaseRot;
    Vector3 cameraMovePos;

    public float cameraZoomInMoveSpeed;
    public float cameraMoveSpeed;
    public float cameraZoomIn;

    public bool doZoom;

    public float maxZoomInDist;
    public float minZoomInDist;

    public Transform zoomingCharacter;
    bool canChaseMousePos = false;
    bool canControlCamera = false;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.position = cameraBasePos;
        initialCameraPos = mainCamera.transform.position;

        canControlCamera = false;

        mainCamera.transform.rotation = Quaternion.Euler(cameraBaseRot);
    }

    void Update()
    {
        if (canControlCamera)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            cameraMovePos = new Vector3(h, 0, v) * cameraMoveSpeed;
        }
    }

    public void MoveToCharacter(Transform _CharacterPos)
    {
        canControlCamera = false;

        if (_CharacterPos.gameObject)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, _CharacterPos.position + cameraOffset, 3f * Time.deltaTime);
        }
    }

    public void ControlMouseWithCharacter()
    {
        if (!canChaseMousePos) return;

        if (zoomingCharacter && SearchWithRayCast.GetHitPoint() != Vector3.zero)
        {

            Vector3 dirPos = new Vector3(SearchWithRayCast.GetHitPoint().x, 0, SearchWithRayCast.GetHitPoint().z) - new Vector3(zoomingCharacter.transform.position.x, 0, zoomingCharacter.transform.position.z);

            if (Vector2.Distance(dirPos, zoomingCharacter.transform.position) > 0.5f)
            {
                dirPos.x = Mathf.Clamp(dirPos.x, -2.5f, 2.5f);
                dirPos.z = Mathf.Clamp(dirPos.z, -2.5f, 2.5f);

                Vector3 culculatePos = zoomingCharacter.transform.position + cameraOffset + new Vector3(dirPos.x, 0, dirPos.z);
                transform.position = Vector3.Lerp(transform.position, culculatePos, 2f * Time.deltaTime);
            }
        }
    }

    public void DirectMoveCamera()
    {
        canControlCamera = true;
        transform.Translate(cameraMovePos * Time.deltaTime, Space.World);
    }

    public void ZoomWithWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * cameraZoomIn;

        if (scroll < 0 && mainCamera.fieldOfView <= maxZoomInDist)
        {
            mainCamera.fieldOfView = maxZoomInDist;
        }
        else if (scroll > 0 && mainCamera.fieldOfView >= minZoomInDist)
        {
            mainCamera.fieldOfView = minZoomInDist;
        }
        else
        {
            mainCamera.fieldOfView += scroll;
        }
    }

    public void SetZoomCondition(bool _onOff)
    {
        doZoom = _onOff;
        Debug.Log("!!!");
    }

    public void SetZoomingCharacter(Transform _character)
    {
        zoomingCharacter = _character;
    }

    public Transform GetZoomingCharacter()
    {
        return zoomingCharacter;
    }

    public void ChangeCanChaseMousePos(bool _on)
    {
        canChaseMousePos = _on;
    }

    public bool GetCanControlCamera()
    {
        return canControlCamera;
    }
}
