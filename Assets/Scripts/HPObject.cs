using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class HPObject : MonoBehaviour
{

    [SerializeField] float damage_delay;
    [SerializeField] int max_hp;
    protected int hp;
    bool can_be_damage = true;

    SpriteRenderer _renderer;
    Tween _tween;
    // Start is called before the first frame update
    protected void Init()
    {
        _renderer = GetComponent<SpriteRenderer>();
        hp = max_hp;
    }

    IEnumerator DamageTimer()
    {
        can_be_damage = false;
        _tween = _renderer.DOColor(Color.red, damage_delay/2).OnComplete(() => { _renderer.DOColor(Color.white, damage_delay / 2); });
        yield return new WaitForSeconds(damage_delay);
        can_be_damage = true;
    }

    public void GetDamage()
    {
        if (can_be_damage)
        {
            hp -= 1;
            WhenDamaged();
            StartCoroutine(DamageTimer());
        }
        if (hp <= 0)
        {
            Death();
        }
    }

    public abstract void Death();

    public virtual void WhenDamaged()
    {

    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}
