using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] int max_hp;
    int hp;
    bool can_be_damage = true;
    //=========================================
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    Rigidbody2D _rigidbody;
    SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        hp = max_hp;
    }

    IEnumerator DamageTimer()
    {
        can_be_damage = false;
        _renderer.DOColor(Color.red, 0.4f).OnComplete(() => { _renderer.DOColor(Color.white, 0.6f); });
        yield return new WaitForSeconds(1f);
        can_be_damage = true;
        
    }

    public void GetDamage()
    {
        if (can_be_damage)
        {
            hp--;
            StartCoroutine(DamageTimer());
        }
        if (hp <= 0)
        {
            //TODO:
            Debug.Log("DEATH");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _rigidbody.velocity = new Vector3(xMovement, yMovement, 0) * speed;
    }
}
