using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zex.cvtools;

public class ShaderSwitch : MonoBehaviour
{
    DepthCameraScript m_DepthCamera;
    SegmentationScript m_Segmentation;
    public WaterController m_WaterController;

    Dictionary<string, Shader> m_ShaderDictionary;
    Shader m_defaultShader;

    // Start is called before the first frame update
    void Start()
    {
        m_DepthCamera = GetComponent<DepthCameraScript>();
        m_Segmentation = GetComponent<SegmentationScript>();

        m_defaultShader = Shader.Find("Standard");
        m_ShaderDictionary = new Dictionary<string, Shader>();

        UpdateSettings(false, false, true, false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateSettings(false, true, true, true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateSettings(true, false, true, false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UpdateSettings(false, false, true, false);
        }
    }

    void UpdateSettings(bool segEnabled, bool depthEnabled, bool useDefaultShader, bool opaque)
    {
        m_Segmentation.enabled = segEnabled;
        m_DepthCamera.enabled = depthEnabled;
        if (useDefaultShader)
            UseDefaultShader();
        m_WaterController.UpdateMaterial(opaque);
    }

    void UseDefaultShader()
    {
        var renderers = GameObject.FindObjectsOfType<Renderer>();

        foreach (var r in renderers)
        {
            var tag = r.gameObject.tag;
            Debug.Log(tag);
            if (!m_ShaderDictionary.ContainsKey(tag))
                r.material.shader = m_defaultShader;
        }
    }
}
