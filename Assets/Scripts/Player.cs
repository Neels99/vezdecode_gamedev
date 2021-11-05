using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _rigidbody.velocity = new Vector3(xMovement, yMovement, 0) * speed;
    }
}
