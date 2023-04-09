using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Instancer))]
public class Lidar3 : MonoBehaviour
{
    Vector3[,] positions;
    public int row = 64;
    public int col = 180;
    float minVerticalAngle = -30f;
    float maxVerticalAngle = 20f;
    float minHorizontalAngle = -180f;
    float maxHorizontalAngle = 180f;
    private Color RayColor = new Color(0.66f, 1f, 0.52f);
    List<Color> colors;
    public Transform origin;
    public bool showRay = false;
    Color[] segmentationColors = new Color[] { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };
    int fixedFrame = 0;
    int layer;

    [HideInInspector]
    public Instancer instancer;



    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[row, col];
        instancer = GetComponent<Instancer>();
        instancer.enabled = true;


    }


    void FixedUpdate()
    {
        if (fixedFrame % 3 == 0)
        {
            int AddedMatricies = 0;
            Vector3 randomPos = new Vector3(0f, -100f, 0f);
            float scale = instancer.scale;
            List<List<Matrix4x4>> batches = new List<List<Matrix4x4>>();
            batches.Add(new List<Matrix4x4>());
            int castCount = 0;
            Vector3 fwd = Vector3.forward;
            for (int i = 0; i < row; i++)
            {
                float incRow = (float)(maxVerticalAngle - minVerticalAngle) / row;
                Vector3 v = Quaternion.AngleAxis(i * incRow + minVerticalAngle, Vector3.right) * fwd;
                for (int j = 0; j < col; j++)
                {
                    float incCol = (float)(maxHorizontalAngle - minHorizontalAngle) / col;
                    Vector3 dir = Quaternion.AngleAxis(j * incCol + minHorizontalAngle, Vector3.up) * v;
                    RaycastHit hit;


                    if (j == 0 && showRay)
                    {
                        Debug.DrawRay(origin.position, dir * 20f, RayColor, 1f);
                    }

                    if (Physics.Raycast(origin.position, dir, out hit, 100))
                    {
                        castCount  += 1;
                        if (AddedMatricies >= 1023 || batches.Count == 0)
                        {
                            batches.Add(new List<Matrix4x4>());
                            AddedMatricies = 0;
                        }
                        Matrix4x4 mat = Matrix4x4.TRS(hit.point, Quaternion.LookRotation(dir), Vector3.one * scale);
                        batches[batches.Count - 1].Add(mat);
                        AddedMatricies++;

                    }

                }
            }
            instancer.batches = batches;
            Debug.Log(castCount);
        }
        fixedFrame++;
      


    }

}

