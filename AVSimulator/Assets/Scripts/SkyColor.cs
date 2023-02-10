using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zex.cvtools;

public class SkyColor : MonoBehaviour
{
    public Color m_Color;
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
            m_Segmentation.skyColor = m_Color;
        }
    }
}
