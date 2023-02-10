using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyController : MonoBehaviour
{
    float radius;
    public float maxRadius = 1f;
    public float minRadius = 3f;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        radius = Random.Range(minRadius, maxRadius);
        tr = GetComponent<Transform>();
        tr.localScale = Vector3.one * radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
