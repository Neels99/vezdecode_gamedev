using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    static private RoomManager _instance;
    static public RoomManager instance { get { return _instance; } }

    [Header("Prefabs")]
    [SerializeField] GameObject prefab_room;

    [Header("Objects")]
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _drone;

    Room room; //current room

    /// <summary>
    /// Создаёт комнату
    /// </summary>
    /// <param name="dir"></param>
    /// <returns> Место спавна игрока и дрона. </returns>
    Vector2 CreateRoom(FromDoorDirection dir)
    {
        room = GameObject.Instantiate(prefab_room).GetComponent<Room>();
        return room.Init(dir);
    }

    void SetPlayerPos(Vector2 pos)
    {
        _player.transform.position = pos;
        _drone.transform.position = pos;
    }

    private void Awake()
    {
        _instance = this;
        var pos = CreateRoom(FromDoorDirection.Spawn);
        SetPlayerPos(pos);
        room.OpenAllDoors();
    }

    static public void GoToRoom(FromDoorDirection from)
    {
        Destroy(_instance.room.gameObject);
        var pos = _instance.CreateRoom(from);
        _instance.SetPlayerPos(pos);
    }

    static public void OpenRoom()
    {
        _instance.room.OpenAllDoors();
    }

    static public Transform GetTempParent()
    {
        return _instance.room.get_temp_parent;
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
