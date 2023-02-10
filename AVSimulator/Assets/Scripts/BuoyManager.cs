using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyManager : MonoBehaviour
{
    public GameObject m_BuoyPrefab;
    public int m_BuoyNumber = 10;
    public GameObject m_Terrain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        Transform tr = GetComponent<Transform>();
        Vector2 terrainSize = m_Terrain.GetComponent<MeshGenerator>().GetSize();
        float sideLength = m_Terrain.GetComponent<MeshGenerator>().GetSideLength();
        float xSize = terrainSize[0];
        float zSize = terrainSize[1];
        float xMin = -xSize / 2;
        float xMax = xSize / 2;
        float zMin = -zSize / 2;
        float zMax = zSize / 2;
        for (int i = 0; i < m_BuoyNumber; i++)
        {
            GameObject BuoyInstance = Instantiate(m_BuoyPrefab, new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax)) * sideLength, Quaternion.identity);
            BuoyInstance.transform.parent = tr;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
