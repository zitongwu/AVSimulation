using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh m_Mesh;
    Vector3[] m_Vertices;
    int[] m_Triangles;

    public int m_xSize = 20;
    public int m_zSize = 20;
    public float m_SideLength = 5f;

    // Start is called before the first frame update
    void Start()
    {

        m_Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = m_Mesh;

        //StartCoroutine(CreateShape());
        CreateShape();
        UpdateMesh();
    }

    private void Update()
    {
        //UpdateMesh();
    }

    void CreateShape()
    {
        Transform origin = GetComponent<Transform>();
        m_Vertices = new Vector3[(m_xSize + 1) * (m_zSize + 1)];
        float xRandomOffset = 0; //Random.Range(0f, 20f);
        float zRandomOffset = 0; //Random.Range(0f, 20f);

        for (int i = 0, z = 0; z <= m_zSize; z++)
        {
            for (int x = 0; x <= m_xSize; x++)
            {
                float y = Mathf.PerlinNoise((x +  xRandomOffset) * .3f , (z + zRandomOffset) * .3f) * 20f;
                m_Vertices[i] = new Vector3((x - ((float) m_xSize/ 2))* m_SideLength, y, (z - ((float)m_zSize / 2)) * m_SideLength);
                i++;
            }
        }

        m_Triangles = new int[m_xSize * m_zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < m_zSize; z++)
        {
            for (int x = 0; x < m_xSize; x++)
            {
                m_Triangles[tris + 0] = vert + 0;
                m_Triangles[tris + 1] = vert + m_xSize + 1;
                m_Triangles[tris + 2] = vert + 1;
                m_Triangles[tris + 3] = vert + 1;
                m_Triangles[tris + 4] = vert + m_xSize + 1;
                m_Triangles[tris + 5] = vert + m_xSize + 2;

                vert++;
                tris += 6;

                //yield return new WaitForSeconds(0.002f);

            }
            vert++;
        }

    }

    // Update is called once per frame
    void UpdateMesh()
    {
        m_Mesh.Clear();
        m_Mesh.vertices = m_Vertices;
        m_Mesh.triangles = m_Triangles;

        m_Mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if (vertices == null)
    //        return;

    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(vertices[i], .1f);
    //    }
    //}

    public Vector2 GetSize()
    {
        return new Vector2((float) m_xSize, (float) m_zSize);
    }

    public float GetSideLength()
    {
        return m_SideLength;
    }
}
