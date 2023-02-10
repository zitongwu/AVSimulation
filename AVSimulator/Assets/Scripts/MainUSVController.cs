using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUSVController : MonoBehaviour
{
    Renderer rend;
    public Renderer mount;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        mount.enabled = false;
        Invoke("Show", 4f);
    }

    void Show()
    {
        rend.enabled = true;
        mount.enabled = true;
    }
}
