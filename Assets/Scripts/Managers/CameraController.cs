using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody rb;

    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos = new Vector3(); // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraOffset = new Vector3();
    public Vector3 cameraBasePos = new Vector3(0, 20, 0);
    public Vector3 cameraBaseRot;
    public float cameraZoomInMoveSpeed;
    public float cameramoveSpeed;
    public float cameraZoomIn;

    public bool doZoom;

    public float maxZoomInDist;
    public float minZoomInDist;

    public Temp_Character zoomingCharacter;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.position = cameraBasePos;
        initialCameraPos = mainCamera.transform.position;

        mainCamera.transform.rotation = Quaternion.Euler(cameraBaseRot);
        rb = GetComponent<Rigidbody>();
    }

    // 코루틴으로 1초마다 돌아가게 만들까?

    public void CameraZoomIn()
    {
        if (zoomingCharacter)
        {
            if (doZoom)
            {
                Vector3 relativePos = mainCamera.transform.position - zoomingCharacter.transform.position;
                //Quaternion camTurnAngle = Quaternion.AngleAxis(0.25f, Vector3.up); //Input.GetAxis("Mouse X") * 0.5f : 마우스 입력에 따라 바뀌게 끔 하는 식은 요거.
                //cameraOffset = camTurnAngle * cameraOffset; 

                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, zoomingCharacter.transform.position + cameraOffset, cameraZoomInMoveSpeed);
                //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Camera.main.transform.rotation * camTurnAngle, Time.deltaTime);
                //Camera.main.transform.LookAt(Vector3.Lerp(Camera.main.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
                mainCamera.transform.LookAt(Vector3.Lerp(zoomingCharacter.transform.position, zoomingCharacter.transform.position + cameraOffset, cameraZoomInMoveSpeed));
            }
            else
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, initialCameraPos, cameraZoomInMoveSpeed);
                mainCamera.transform.LookAt(Vector3.Lerp(zoomingCharacter.transform.position, zoomingCharacter.transform.position + cameraOffset, cameraZoomInMoveSpeed));
            }
        }
    }

    public void DirectMoveCamera()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 cameraMovePos = new Vector3(h, 0, v) * cameramoveSpeed * Time.deltaTime;

        //mainCamera.transform.position += cameraBasePos + cameraMovePos;
        rb.MovePosition(transform.position + cameraMovePos);
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

    // public void CameraZoomOut(Temp_Character _nowCharacter)
    // {
    //     if (_nowCharacter)
    //     {

    //     }
    // }

    public void SetZoomCondition(bool _onOff)
    {
        doZoom = _onOff;
        Debug.Log("!!!");
    }

    public void SetZoomingCharacter(Temp_Character _character)
    {
        zoomingCharacter = _character;
    }

    public Temp_Character GetZoomingCharacter()
    {
        return zoomingCharacter;
    }
}
