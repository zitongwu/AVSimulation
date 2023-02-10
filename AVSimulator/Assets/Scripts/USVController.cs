using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVController : MonoBehaviour
{
    Transform m_Transform;
    Vector3 m_Direction;
    float m_Speed = 1f;
    float m_RepeatRate = 3f;
    float m_Size = 1f;
    float m_HeightScale = 0.8f;
    public float m_maxSize = 1f;
    public float m_minSize = 3f;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Size = Random.Range(m_minSize, m_maxSize);
        Vector3 currentScale = m_Transform.localScale;
        m_Transform.localScale = new Vector3(currentScale.x * m_Size, currentScale.y * m_Size * m_HeightScale, currentScale.z * m_Size);
        m_RepeatRate = Random.Range(3f, 10f);
        InvokeRepeating("ChangeDirection", 0f, m_RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        m_Transform.position += m_Direction * m_Speed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        m_Direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        m_Direction.Normalize();
        m_Transform.rotation = Quaternion.LookRotation(m_Direction);
    }

}
