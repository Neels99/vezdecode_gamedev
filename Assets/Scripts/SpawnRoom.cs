using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FromDoorDirection
{
    Spawn = 5,
    up = 0,
    left,
    down,
    right
}

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private Sprite NormalRoomDoor;
    [SerializeField] private Sprite FromRoomDoor;

    [Header("Doors")]
    [SerializeField] List<Door> active_doors = new List<Door>();

    void Start()
    {
        Init(FromDoorDirection.Spawn);
    }

    void Update()
    {

    }

    public void Init(FromDoorDirection dir)
    {
        if (dir != FromDoorDirection.Spawn)
        {
            active_doors[(int)dir].SetDoor(ToRoomType.from, FromRoomDoor);
            active_doors.RemoveAt((int)dir);
        }

        List<Door> temp = new List<Door>();
        for (int i = 0; i < 2; i++)
        {
            var pos = Random.Range(0, active_doors.Count);
            active_doors[pos].SetDoor(ToRoomType.normal, NormalRoomDoor);
            temp.Add(active_doors[pos]);
            active_doors.RemoveAt(pos);
        }
        
        foreach (var _door in active_doors)
        {
            _door.DisableDoor();
        }
        active_doors.Clear();
        active_doors.AddRange(temp);
    }
}
