using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScannerForLidar4))]
public class Lidar4 : MonoBehaviour
{
    float minVerticalAngle = -30f;
    float maxVerticalAngle = 20f;
    float minHorizontalAngle = -180f;
    float maxHorizontalAngle = 180f;
    Color RayColor = new Color(0.66f, 1f, 0.52f);
    int fixedFrame = 0;

    public Transform origin;
    public bool showRay = false;
    public int row = 100;
    public int col = 100;
    ScannerForLidar4 scanner;
    [HideInInspector]
    public List<Vector3> positionsList = new();

    // Start is called before the first frame update
    void Start()
    {
        scanner = GetComponent<ScannerForLidar4>();
        scanner.enabled = true;
    }


    void FixedUpdate()
    {
        if (fixedFrame % 3 == 0)
        {

            int count = 0;
            Vector3 fwd = Vector3.forward;
            for (int i = 0; i < row; i++)
            {
                float incRow = (float)(maxVerticalAngle - minVerticalAngle) / row;
                Vector3 v = Quaternion.AngleAxis(i * incRow + minVerticalAngle, Vector3.right) * fwd;
                for (int j = 0; j < col; j++)
                {
                    float incCol = (float)(maxHorizontalAngle - minHorizontalAngle) / col;
                    Vector3 dir = Quaternion.AngleAxis(j * incCol + minHorizontalAngle, Vector3.up) * v;
                    count++;
                    // Draw ray for angle visualization
                    if (j == 0 && showRay)
                    {
                        Debug.DrawRay(origin.position, dir * 20f, RayColor, 1f);
                    }

                    // Raycast and build matrix for batching
                    RaycastHit hit;
                    if (Physics.Raycast(origin.position, dir, out hit, 100))
                    {
                        positionsList.Add(hit.point);
                    }
                }
            }
            scanner._positionsList = positionsList;
            scanner.ApplyPositions();
        }
        fixedFrame++;



    }

}

