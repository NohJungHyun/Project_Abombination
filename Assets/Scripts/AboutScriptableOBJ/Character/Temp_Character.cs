using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Character : MonoBehaviour
{
    public CharacterInfo characterInfo;

    public CharacterInfo info { get; set; }

    public bool canMove;
    public bool canActwithBomb;
    public bool canUseSkill;

    // 캐릭터가 설치가능한 폭발물 리스트
    public List<Explosion> canSetExplosions = new List<Explosion>(30);
    // 캐릭터가 설치가능한 폭탄 리스트
    public List<Bomb> canSetBombs = new List<Bomb>(10);
    public List<Bomb> haveBombs = new List<Bomb>(10);

    Vector3 beforePos; // 턴 시작 시, 캐릭터의 위치를 담아서 다시 돌아올 수 있도록 제작. 
    float canWalkDist; // 캐릭터가 월드 상에서 이동할 수 있는 거리를 의미. 캐릭터의 movement와 적절히 계산되어 산출되며, 이동 가능 반경을 이동할 때마다 감소한다.

    // 버프 List 제작 
    // 장비 List 제작
    // 스킬 List 제작

    void Awake()
    {
        info = ScriptableObject.Instantiate(characterInfo);
    }

}