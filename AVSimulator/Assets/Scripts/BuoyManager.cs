using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyManager : MonoBehaviour
{
    public GameObject BuoyPrefab;
    public int BuoyNumber = 10;
    public GameObject Terrain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        Transform tr = GetComponent<Transform>();
        Vector2 terrainSize = Terrain.GetComponent<MeshGenerator>().GetSize();
        float sideLength = Terrain.GetComponent<MeshGenerator>().GetSideLength();
        float xSize = terrainSize[0];
        float zSize = terrainSize[1];
        float xMin = -xSize / 2;
        float xMax = xSize / 2;
        float zMin = -zSize / 2;
        float zMax = zSize / 2;
        for (int i = 0; i < BuoyNumber; i++)
        {
            GameObject BuoyInstance = Instantiate(BuoyPrefab, new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax)) * sideLength, Quaternion.identity);
            BuoyInstance.transform.parent = tr;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
