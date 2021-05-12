using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEventManager : MonoBehaviour
{
    public float UpdateIntervalTime = 0.5f;

    // Update is called once per frame

    // IEnumerator DoUpdate(float _delay)
    // {
    //     yield return new WaitForSeconds(_delay);
    //     BombGetUpdate?.Invoke();
    // }

    // public static void AddBombUpdateEvent(Bomb _bomb)
    // {
    //     BombGetUpdate += _bomb.bombUpdate;
    // }
}
