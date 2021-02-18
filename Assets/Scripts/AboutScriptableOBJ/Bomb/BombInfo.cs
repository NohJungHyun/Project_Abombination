using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BombInfo : ScriptableObject
{
        //이 게임의 공격수단 장치이자, 주된 시스템을 차지하는 오브젝트.
    public string bombName;

    [TextArea]
    public string bombDescription;

    public Sprite bombImage;
    public GameObject bombObject;
    public SetBombPositions setBomb;
    
    public LayerMask mask;

    public int bombDamage;
    public int bombRadius;
    public bool bombCanStack;
    public int bombMaxStack;
    public int[] bombDispelNum; // 폭발물을 해제하기 위해서 필요한 숫자들
    public int[] bombAugmentNum; // 폭발물을 강화하기 위해서 필요한 숫자들
    public int[] bombSetupNum; // 폭발물을 설치하기 위해서 필요한 숫자들

    public int bombCountDown; // 폭탄이 폭발물과 상관없이 작동하게 되는 카운트다운을 의미.

    public StartSetPos startSetPos;

    public int bombMinCountDown;
    public int bombMaxCountDown;

    public List<Explosion> explosionList = new List<Explosion>(30);

    // public BombInfo()
    // { //생성자

    // }

    // 폭.8!
    public abstract void Boom(GameObject _bombObj);
    
    // 폭탄 해제 함수
    // _number: 적용되는 대상 수.
    public virtual void Diffuse(GameObject _bombObj, float _radius, int _number)
    {
       Collider[] cols = Physics.OverlapSphere(_bombObj.transform.position, _radius, mask);
       
    }
}
