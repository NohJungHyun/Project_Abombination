using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEventBoom : MonoBehaviour, IBombEventExcutor
{
    public Bomb bomb;
    public event BombEventBox eventBox;
    public GameObject boomParticle;

    public BombEventBoom(Bomb _Bomb)
    {
        bomb = _Bomb;
        eventBox += Boom;
    }

    public void Excute(Temp_Character _Character)
    {
        eventBox?.Invoke(_Character);
    }

    public void Boom(Temp_Character _Character)
    {
        bomb.Boom();
    }

    public void OnDisable()
    {
        eventBox -= Boom;
    }

    public IEnumerator OnCallingBoom(Temp_Character _Character)
    {
        bomb.PlayUseAnimation();
        yield return new WaitForSeconds(bomb.boomEffect22.GetComponent<ParticleSystem>().main.duration * 0.5f);
    }
}
