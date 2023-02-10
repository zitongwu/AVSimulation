using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USVManager : MonoBehaviour
{
    public GameObject USVPrefab;
    public int USVNumber = 10;
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
        yield return new WaitForSeconds(3f);
        Transform tr = GetComponent<Transform>();
        Vector2 terrainSize = Terrain.GetComponent<MeshGenerator>().GetSize();
        float sideLength = Terrain.GetComponent<MeshGenerator>().GetSideLength();
        float xSize = terrainSize[0];
        float zSize = terrainSize[1];
        float xMin = -xSize / 2;
        float xMax = xSize / 2;
        float zMin = -zSize / 2;
        float zMax = zSize / 2;
        for (int i = 0; i < USVNumber; i++)
        {
            GameObject USVInstance = Instantiate(USVPrefab, new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax)) * sideLength, Quaternion.identity);
            USVInstance.transform.parent = tr;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
