using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zex.cvtools;

public class ShaderSwitch : MonoBehaviour
{
    private DepthCameraScript m_DepthCamera;
    private SegmentationScript m_Segmentation;

    // Start is called before the first frame update
    void Start()
    {
        m_DepthCamera = GetComponent<DepthCameraScript>();
        m_Segmentation = GetComponent<SegmentationScript>();
        m_Segmentation.enabled = false;
        m_DepthCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Segmentation.enabled = false;
            m_DepthCamera.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Segmentation.enabled = true;
            m_DepthCamera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Segmentation.enabled = false;
            m_DepthCamera.enabled = false;
        }
    }
}