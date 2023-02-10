using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVController : MonoBehaviour
{
    Transform tr;
    Vector3 dir;
    float interval = 5f;
    float speed = 1f;
    int frames;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        InvokeRepeating("ChangeDirection", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        tr.position += dir * speed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        dir = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
    }

}
