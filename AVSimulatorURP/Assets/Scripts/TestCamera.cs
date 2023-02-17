/*
 * Reference: https://forum.unity.com/threads/access-renderer-feature-settings-at-runtime.770918/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
public class TestCamera : MonoBehaviour
{
    public UniversalRendererData universalRendererData;
    List<ScriptableRendererFeature> features;

    // Start is called before the first frame update
    void Start()
    {
        features = universalRendererData.rendererFeatures;
        features[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
