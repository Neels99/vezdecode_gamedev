using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class Drone : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    Rigidbody2D _rigidbody;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            collision.GetComponent<HPObject>().GetDamage();
        }
        Debug.Log(collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _rigidbody.velocity = new Vector3(xMovement, yMovement, 0) * speed;
    }
}
