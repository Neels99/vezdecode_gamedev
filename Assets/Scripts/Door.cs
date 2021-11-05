using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockType
{
    open,
    close
};

public enum ToRoomType
{
    from,
    normal
};

public class Door : MonoBehaviour
{
    LockType _lock = LockType.close;
    ToRoomType to_room_type;
    [SerializeField] FromDoorDirection door_position;

    [SerializeField] SpriteRenderer _render;
    [SerializeField] Transform spawn_pont;
    public Vector2 get_spawn { get { return spawn_pont.position; } }

    public void SetDoor(ToRoomType _type, Sprite _sprite, LockType _lock_type = LockType.close)
    {
        to_room_type = _type;
        _render.sprite = _sprite;
        _lock = _lock_type;
    }

    public void Open()
    {
        _lock = LockType.open;
    }

    public void DisableDoor()
    {
        gameObject.SetActive(false);
    }

    public void GoToDoor()
    {
        RoomManager.GoToRoom(door_position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_lock == LockType.open && to_room_type != ToRoomType.from)
            {
                Debug.Log("Go Next");
                GoToDoor();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
