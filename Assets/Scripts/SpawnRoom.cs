using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : Room
{
    // Start is called before the first frame update
    void Start()
    {
        Init(FromDoorDirection.Spawn);
        foreach (var _door in active_doors)
        {
            _door.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
