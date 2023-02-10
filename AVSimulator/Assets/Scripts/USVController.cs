using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVController : MonoBehaviour
{
    Transform tr;
    Vector3 dir;
    float nextActionTime = 0f;
    float interval = 5f;
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += interval;
            dir = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        }
        tr.position += dir * speed * Time.deltaTime;
    }

}
