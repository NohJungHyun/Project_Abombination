using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpriteBound : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject sss;
    public float radius;

    public float border;

    public SpriteMask mask;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        // print(sprite.bounds.size);
        // print(sprite.size);

        // // Vector3 v = new Vector3(5, 0, 0);
        // // Vector3 ww = sprite.bounds.size;
        // // ww += v;

        // // transform.localScale = ww;
        // sprite.size += Vector2.one * 100;

        border = sprite.bounds.size.x;
        print(border);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, sss.transform.position);
        print(dist);
        // transform.localScale = Vector2.one * dist * radius;
        if (dist < border * 0.5f) //+ radius
        {
            print("우에에에엥");
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, border * 0.5f);   
    }
}
