using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Material m_OpaqueWaterMat;
    public Material m_TransparentWaterMat;
    Renderer m_Renderer;

    // Start is called before the first frame update
    void Awake()
    {

        m_Renderer = GetComponent<MeshRenderer>();

    }

    public void UpdateMaterial(bool opaque)
    {
        if (opaque)
        {
            m_Renderer.material = m_OpaqueWaterMat;
        }
        else
        {
            Debug.Log(m_Renderer.material);
            Debug.Log(m_TransparentWaterMat);
            m_Renderer.material = m_TransparentWaterMat;
        }
    }
}
