using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public int row = 100;
    public int col = 100;
    public Transform folder;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < row; i++)
        {

            // colors.Add(Color.HSVToRGB(colorInc * i, 1, 1));
            for (int j = 0; j < col; j++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-100, 100), Random.Range(0, 20), Random.Range(-100, 100)) ;
                GameObject a = Instantiate(prefab, randomPos, prefab.transform.rotation);
                // particles[i, j].GetComponent<Renderer>().material.color = colors[i];
                a.transform.parent = folder;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
