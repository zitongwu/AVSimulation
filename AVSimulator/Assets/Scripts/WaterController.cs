using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Material m_OpaqueWaterMat;
    public Material m_TransparentWaterMat;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMaterial(bool opaque)
    {
        if (opaque)
        {
            m_Renderer.material = m_OpaqueWaterMat;
        }
        else
        {
            m_Renderer.material = m_TransparentWaterMat;
        }
    }
}
