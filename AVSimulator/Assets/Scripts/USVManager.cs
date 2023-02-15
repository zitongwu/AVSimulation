using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVManager : MonoBehaviour
{
    public GameObject m_USVPrefab;
    public int USVNumber = 10;
    public GameObject m_Terrain;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Spawn());
        Spawn();
    }

    void Spawn()
    {
        //yield return new WaitForSeconds(3f);
        Transform tr = GetComponent<Transform>();
        Vector2 terrainSize = m_Terrain.GetComponent<MeshGenerator>().GetSize();
        float sideLength = m_Terrain.GetComponent<MeshGenerator>().GetSideLength();
        float xSize = terrainSize[0];
        float zSize = terrainSize[1];
        float xMin = -xSize / 2;
        float xMax = xSize / 2;
        float zMin = -zSize / 2;
        float zMax = zSize / 2;
        for (int i = 0; i < USVNumber; i++)
        {
            GameObject USVInstance = Instantiate(m_USVPrefab, new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax)) * sideLength, Quaternion.identity);
            USVInstance.transform.parent = tr;
            //yield return new WaitForSeconds(0.05f);
        }
    }
}
