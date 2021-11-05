using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class Drone : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    Rigidbody2D _rigidbody;
    [SerializeField] float speed;
    public float upgrade = 1;

    private List<HPObject> collision_hp_objects = new List<HPObject>();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            collision_hp_objects.Add(collision.GetComponent<HPObject>());
            //collision_hp_objects.Add(collision.gameObject.GetHashCode(), collision.GetComponent<HPObject>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            collision_hp_objects.Remove(collision.GetComponent<HPObject>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _rigidbody.velocity = new Vector3(xMovement, yMovement, 0) * speed * upgrade;

        foreach (var mob in collision_hp_objects.ToArray())
        {
            mob.GetDamage();
        }
    }
}
