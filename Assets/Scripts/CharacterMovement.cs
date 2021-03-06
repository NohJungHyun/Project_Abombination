﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // 캐릭터의 턴이 진행되면, 그 캐릭터의 이동 명령을 수행하는 스크립트
    // 본 게임은 캐릭터가 동시다발적으로 행동하지 않기 때문에, battleManager script에 붙어서 작업 수행
    public Temp_Character temp_Character;
    public BattleController battleController;

    Ray ray;
    RaycastHit hit;
    //Vector3 getMousePos; // raycast로 찾은 좌표를 저장. 

    Vector3 beforePos; // 턴 시작 시, 캐릭터의 위치를 담아서 다시 돌아올 수 있도록 제작. 
    float canWalkDist; // 캐릭터가 월드 상에서 이동할 수 있는 거리를 의미. 캐릭터의 movement와 적절히 계산되어 산출되며, 이동 가능 반경을 이동할 때마다 감소한다.


    // Start is called before the first frame update
    // void Start()
    // {
    //     battleController = GameObject.Find("BattleController").GetComponent<BattleController>();
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            temp_Character = battleController.nowPlayCharacter;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        if (temp_Character != null)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 pos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                temp_Character.transform.position = Vector3.MoveTowards(temp_Character.transform.position, pos, temp_Character.characterInfo.characterMovement * Time.deltaTime);
            }
        }
    }
}
