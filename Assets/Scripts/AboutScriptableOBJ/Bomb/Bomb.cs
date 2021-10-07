using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb
{
    BombData bombData;
    public BombData BombData
    {
        get{ return bombData;}
        set 
        {
            bombData = value;
        }
    }

    public List<OccurrenceTemplate> occurrences = new List<OccurrenceTemplate>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
