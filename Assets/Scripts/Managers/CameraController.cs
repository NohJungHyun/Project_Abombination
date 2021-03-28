using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;

    // ***** 전투 내 Camera 이동, 회전 처리 *****
    Vector3 initialCameraPos = new Vector3(); // 카메라의 원래 위치를 위해 작성
    public Vector3 cameraOffset = new Vector3();
    public float cameraMoveSpeed;
    public bool doZoom;

    void Start()
    {
        mainCamera = Camera.main;
        initialCameraPos = mainCamera.transform.position;
    }

    // 코루틴으로 1초마다 돌아가게 만들까?

    public void CameraZoomIn(Temp_Character _temp_Character)
    {
        if (!_temp_Character) return;

        if (doZoom)
        {
            Vector3 relativePos = mainCamera.transform.position - _temp_Character.transform.position;
            //Quaternion camTurnAngle = Quaternion.AngleAxis(0.25f, Vector3.up); //Input.GetAxis("Mouse X") * 0.5f : 마우스 입력에 따라 바뀌게 끔 하는 식은 요거.
            //cameraOffset = camTurnAngle * cameraOffset; 

            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, _temp_Character.transform.position + cameraOffset, cameraMoveSpeed);
            //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Camera.main.transform.rotation * camTurnAngle, Time.deltaTime);
            //Camera.main.transform.LookAt(Vector3.Lerp(Camera.main.transform.position, nowPlayCharacter.transform.position + cameraOffset, cameraMoveSpeed));
            mainCamera.transform.LookAt(Vector3.Lerp(_temp_Character.transform.position, _temp_Character.transform.position + cameraOffset, cameraMoveSpeed));
        }
        else
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, initialCameraPos, cameraMoveSpeed);
            mainCamera.transform.LookAt(Vector3.Lerp(_temp_Character.transform.position, _temp_Character.transform.position + cameraOffset, cameraMoveSpeed));
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
}
