using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyController : MonoBehaviour
{
    float m_Radius;
    public float m_MaxRadius = 1f;
    public float m_MinRadius = 3f;
    Transform m_Transform;

    // Start is called before the first frame update
    void Start()
    {
        m_Radius = Random.Range(m_MinRadius, m_MaxRadius);
        m_Transform = GetComponent<Transform>();
        m_Transform.localScale = Vector3.one * m_Radius;
    }

}
