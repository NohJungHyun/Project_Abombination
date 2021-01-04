using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    // 전투 내 다뤄질 폭탄의 처리를 도맡는 스크립트
    // 오브젝트풀링을 이용하여 다량의 폭탄처리를 진행.
    
    //현재 전장 내 존재하는 폭탄의 개수를 담는 큐 제작.
    [SerializeField]
    public Queue<GameObject> bombs = new Queue<GameObject>();
    public BattleController battleController;


    // 턴, 라운드가 진행될 때마다 카운트 다운되는 걸 계산, 처리하기 위해 만든 delegate;
    public delegate void CountdownChecker();
    public static CountdownChecker turnChecker;

    // Start is called before the first frame update
    void Start()
    {
        if (bombs.Count == 0)
        {
            GameObject bomb = new GameObject("Primitive Bomb");
            //bomb.AddComponent<Bomb>();
            bombs.Enqueue(bomb);
        }
        // print(bombs.Count);
    }


    void Countdown()
    {

    }

    public void SetBombsinUI()
    {
        List<Bomb> bList = new List<Bomb>(); 
        if (battleController.nowPlayCharacter && battleController.nowPlayCharacter.canSetBombs.Count > 0)
        {
            //foreach()
        }

    }
}
