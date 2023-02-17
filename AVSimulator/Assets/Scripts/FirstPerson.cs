using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour
{
    Transform m_Transform;
    float m_Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Transform.position = m_Transform.position + m_Transform.up * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Transform.position = m_Transform.position - m_Transform.up * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Transform.position = m_Transform.position + m_Transform.right * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Transform.position = m_Transform.position - m_Transform.right * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            m_Transform.position = m_Transform.position + m_Transform.forward * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.B))
        {
            m_Transform.position = m_Transform.position - m_Transform.forward * m_Speed * Time.deltaTime;
        }

    }
}
