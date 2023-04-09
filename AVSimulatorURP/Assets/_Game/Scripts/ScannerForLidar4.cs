/*
 * Original Author: Leonhard Schnaitl
 * Modifier: Zitong Wu
 * GitHub: https://github.com/leonhardrobin
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ScannerForLidar4 : MonoBehaviour
{

    private List<VisualEffect> _vfxList = new();
    private VisualEffect _currentVFX;
    private Texture2D _texture;
    private Color[] _positions;
    private bool _createNewVFX;

    private const string TEXTURE_NAME = "PositionsTexture";
    private const string RESOLUTION_PARAMETER_NAME = "Resolution";

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private VisualEffect _vfxPrefab;
    [SerializeField] private GameObject _vfxContainer;
    [SerializeField] private int resolution = 200;

    [HideInInspector]
    public List<Vector3> _positionsList = new();

    private void Start()
    {
        // Get InputAction from PlayerInput
        _createNewVFX = true;
        CreateNewVisualEffect();
        ApplyPositions();
    }


    public void ApplyPositions()
    {
        // create array from list
        Vector3[] pos = _positionsList.ToArray();

        // cache position for offset
        Vector3 vfxPos = _currentVFX.transform.position;


        // cache transform position
        Vector3 transformPos = transform.position;

        // cache some more stuff for faster access
        int loopLength = _texture.width * _texture.height;
        int posListLen = pos.Length;

        for (int i = 0; i < loopLength; i++)
        {
            Color data;

            if (i < posListLen)
            {
                data = new Color(pos[i].x - vfxPos.x, pos[i].y - vfxPos.y, pos[i].z - vfxPos.z, 1);
            }
            else
            {
                data = new Color(0, 0, 0, 0);
            }
            _positions[i] = data;
        }

        // apply to texture
        _texture.SetPixels(_positions);
        _texture.Apply();

        // apply to VFX
        _currentVFX.SetTexture(TEXTURE_NAME, _texture);
        _currentVFX.Reinit();
        _positionsList.Clear();

    }

    private void CreateNewVisualEffect() // this is fucking performance heavy help
    {
        // make sure it only gets called once
        if (!_createNewVFX) return;

        // add old VFX to list
        _vfxList.Add(_currentVFX);

        // create new VFX
        _currentVFX = Instantiate(_vfxPrefab, transform.position, Quaternion.identity, _vfxContainer.transform);
        _currentVFX.SetUInt(RESOLUTION_PARAMETER_NAME, (uint)resolution);
        //_currentVFX.SetInt(PARTICLES_PER_SCAN_PARAMETER_NAME, _pointsPerScan);

        // create texture
        _texture = new Texture2D(resolution, resolution, TextureFormat.RGBAFloat, false);

        // create color array for positions
        _positions = new Color[resolution * resolution];

        // clear list
        _positionsList.Clear();

        _createNewVFX = false;
    }

}
