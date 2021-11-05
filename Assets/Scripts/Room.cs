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

public class Room : MonoBehaviour
{
    [SerializeField] protected Sprite NormalRoomDoor;
    [SerializeField] protected Sprite FromRoomDoor;

    [SerializeField] protected SpawnArea _spawn_area;

    [SerializeField] protected Transform temp_objects;
    public Transform get_temp_parent { get { return temp_objects; } }

    [Header("Doors")]
    [SerializeField] protected List<Door> active_doors = new List<Door>();

    [Header("Mobs")]
    [SerializeField] protected List<GameObject> prefab_mobs;
    [SerializeField] protected int mob_nums;
    //ѕока число не равно нулю - двери не открываютс€.
    int reasons_for_closed;

    void Start()
    {
    }

    void Update()
    {
        if (reasons_for_closed == 0)
        {
            OpenAllDoors();
        }
    }

    void SpawnMob()
    {
        reasons_for_closed++;
        var rand_pref_mob = prefab_mobs[Random.Range(0, prefab_mobs.Count)];
        var spawn_point = _spawn_area.get_point();
        var mob = Instantiate(rand_pref_mob);
        mob.transform.position = spawn_point;
        mob.transform.parent = get_temp_parent;
    }

    public void OpenAllDoors()
    {
        foreach (var _door in active_doors)
        {
            _door.Open();
        }
    }

    public Vector2 Init(FromDoorDirection dir)
    {
        Vector2 spawn_point = Vector2.zero;
        if (dir != FromDoorDirection.Spawn)
        {
            int from_door_pos = 0;
            switch (dir)
            {
                case FromDoorDirection.up:
                    from_door_pos = (int)FromDoorDirection.down;
                    break;
                case FromDoorDirection.left:
                    from_door_pos = (int)FromDoorDirection.right;
                    break;
                case FromDoorDirection.down:
                    from_door_pos = (int)FromDoorDirection.up;
                    break;
                case FromDoorDirection.right:
                    from_door_pos = (int)FromDoorDirection.left;
                    break;
            }
            active_doors[from_door_pos].SetDoor(ToRoomType.from, FromRoomDoor);
            spawn_point = active_doors[from_door_pos].get_spawn;
            active_doors.RemoveAt(from_door_pos);
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

        if (dir != FromDoorDirection.Spawn)
        {
            for (int i = 0; i < mob_nums; i++)
            {
                SpawnMob();
            }
        }

        return spawn_point;
    }
}
