using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Color GizmosColor = new Color(1, 0, 0, 0.3f);

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    public Vector2 get_point()
    {
        Vector2 origin = transform.position;
        Vector2 range = transform.localScale / 2.0f;
        Vector2 randomRange = new Vector2(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y));
        Vector2 randomCoordinate = origin + randomRange;

        return randomCoordinate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
