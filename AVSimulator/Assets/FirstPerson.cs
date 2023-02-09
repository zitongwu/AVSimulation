using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour
{
    Transform tr;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tr.position = tr.position + Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tr.position = tr.position + Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.position = tr.position + Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.position = tr.position + Vector3.left * speed * Time.deltaTime;
        }
    }
}
