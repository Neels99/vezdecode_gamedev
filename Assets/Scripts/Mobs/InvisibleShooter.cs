using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InvisibleShooter : MonoBehaviour
{
    [SerializeField] GameObject _pref_bullet;
    [SerializeField] Transform _bullet_spawn;
    Tween _tween;
    // Start is called before the first frame update
    void Fire()
    {
        GameObject bullet = Instantiate(_pref_bullet);
        bullet.transform.parent = RoomManager.GetTempParent();
        bullet.transform.position = _bullet_spawn.position;
        bullet.transform.Rotate(new Vector3(0, 0, _bullet_spawn.rotation.eulerAngles.z));
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(Random.Range(0,4));
        Fire();
        StartCoroutine(FireTimer());
    }
    void Start()
    {
        StartCoroutine(FireTimer());
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}
