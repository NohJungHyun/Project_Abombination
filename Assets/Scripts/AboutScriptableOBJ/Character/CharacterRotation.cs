using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{

    bool canRotate = true;

    public bool CanRotate
    {
        set
        {
            canRotate = value;
        }
    }
    
    public float turnSpeed;

    public void RotateToDir(Vector3 _point)
    {

        if(!canRotate) return;

        // Vector3 lookPoint = new Vector3(_point.x, transform.position.y + transform.localScale.y, _point.z);
        // transform.LookAt(lookPoint);
        // Vector3 vec = _point - transform.position;
        // vec.Normalize();
        // Quaternion rot = Quaternion.LookRotation(vec);
        // transform.rotation = rot;
        // 출처: https://legacy.tistory.com/81 [Planetis Code Legacy]

        Vector3 targetDir = _point - transform.position;
        targetDir.y = 0;
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
