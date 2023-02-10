using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zex.cvtools;

public class SkyColor : MonoBehaviour
{
    public Color color;
    private SegmentationScript m_Segmentation;

    // Start is called before the first frame update
    void Start()
    {
        m_Segmentation = GetComponent<SegmentationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Segmentation != null)
        {
            Debug.Log(true);
            m_Segmentation.skyColor = color;
        }
            
        //Debug.Log(m_Segmentation.skyColor);
    }
}
