using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaIndicatorStorage : MonoBehaviour
{
    public AreaIndicatorStorage instance;

    public GameObject lineIndicator;
    public GameObject circleIndicator;
    public GameObject smallAreaIndicator;

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

    public void MoveIndicator(GameObject _indicator, Transform _trans)
    {
        _indicator.transform.position = _trans.position;
    }

    public void ModifyIndicatorSize(GameObject _indicator, float _scale)
    {
        _indicator.transform.localScale = new Vector3(_indicator.transform.localScale.x * _scale, _indicator.transform.localScale.y * _scale, 0);
    }
}
