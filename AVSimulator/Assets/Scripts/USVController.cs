using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVController : MonoBehaviour
{
    Transform tr;
    Vector3 dir;
    float speed = 1f;
    float repeatRate = 3f;
    float size = 1f;
    float heightScale = 0.8f;
    public float maxSize = 1f;
    public float minSize = 3f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        size = Random.Range(minSize, maxSize);
        Vector3 currentScale = tr.localScale;
        tr.localScale = new Vector3(currentScale.x * size, currentScale.y * size * heightScale, currentScale.z * size);
        repeatRate = Random.Range(3f, 10f);
        InvokeRepeating("ChangeDirection", 0f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        tr.position += dir * speed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        dir.Normalize();
        Debug.Log(dir);
        tr.rotation = Quaternion.LookRotation(dir);
    }

}
