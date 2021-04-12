using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaIndicatorStorage : MonoBehaviour
{
    public AreaIndicatorStorage instance;

    public GameObject lineIndicator;
    public GameObject circleIndicator;
    public GameObject smallAreaIndicator;

    Vector3 basicScale;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // lineIndicator.SetActive(false);
        // circleIndicator.SetActive(false);
        // smallAreaIndicator.SetActive(false);
    }

    void update()
    {

    }

    // 마우스 입력을 받아서 indicator를 회전시킴.
    public void RotateIndicator(Transform _trans)
    {

    }

    public void MoveIndicator(GameObject _indicator, Vector3 _vec)
    {
        _indicator.transform.position = _vec;
    }

    public void ModifyIndicatorSize(GameObject _indicator, float _scale)
    {
        //_indicator.GetComponent<SpriteRenderer>().size *= _scale;

        _indicator.transform.localScale *= _scale;
    }

    public void ResetIndicatorSize(GameObject _indicator)
    {
        _indicator.GetComponent<SpriteRenderer>().size = basicScale;
        _indicator.transform.localScale = basicScale; 
    }

    public GameObject GetCircleIndicator(){
        return circleIndicator;
    }
}
