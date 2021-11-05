using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] GameObject _pref_bullet;
    [SerializeField] Transform _bullet_spawn;
    // Start is called before the first frame update

    void Fire()
    {
        float angle = 0;
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(_pref_bullet);
            bullet.transform.parent = RoomManager.GetTempParent();
            bullet.transform.position = _bullet_spawn.position;
            bullet.transform.Rotate(new Vector3(0, 0, angle));
            angle += 90f;
        }
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(2);
        Fire();
        StartCoroutine(FireTimer());
    }
    void Start()
    {
        StartCoroutine(FireTimer());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
