using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;
using UnityEngine.UI;

public class Player : HPObject
{
    [SerializeField] List<Sprite> hp_bar_images;

    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private Image HP_bar;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    public float upgrade = 1;

    Rigidbody2D _rigidbody;

    public override void Death()
    {
        DeathPanel.SetActive(true);
        Destroy(gameObject);
    }

    public override void WhenDamaged()
    {
        HP_bar.sprite = hp_bar_images[base.hp];
    }

    void Start()
    {
        base.Init();
        _rigidbody = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _rigidbody.velocity = new Vector3(xMovement, yMovement, 0) * speed * upgrade;
    }
}
