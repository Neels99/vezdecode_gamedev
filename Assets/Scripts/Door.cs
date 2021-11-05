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
    [SerializeField] SpriteRenderer _render;

    public void SetDoor(ToRoomType _type, Sprite _sprite)
    {
        to_room_type = _type;
        _render.sprite = _sprite;
    }

    public void Open()
    {
        _lock = LockType.open;
    }

    public void DisableDoor()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_lock == LockType.open)
            {
                Debug.Log("Go Next");
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
