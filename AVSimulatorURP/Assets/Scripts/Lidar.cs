using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidar : MonoBehaviour
{
    public GameObject particle;
    GameObject [,] particles;
    int row = 64;
    int col = 180;
    float minVerticalAngle = -45f;
    float maxVerticalAngle = 20f;
    float minHorizontalAngle = -60f;
    float maxHorizontalAngle = 60f;
    public Color NoObstructionColor = new Color(0.66f, 1f, 0.52f);
    public Color ObstructionColor = new Color(0.66f, 1f, 0.52f);
    List<Color> colors;


    // Start is called before the first frame update
    void Start()
    {
        particles = new GameObject[row, col];
        colors = new List<Color>();
        float colorInc = 1f / ((float) row);
        for (int i = 0; i < row; i ++)
        {

            colors.Add(Color.HSVToRGB(colorInc * i, 1, 1));
            for (int j = 0; j < col; j ++)
            {
                particles[i, j] = Instantiate(particle, particle.transform.position, particle.transform.rotation);
                particles[i, j].GetComponent<Renderer>().material.color = colors[i];
            }
        }
        
    }

    void FixedUpdate()
    {
        Vector3 fwd = Vector3.forward;

        for (int i = 0; i < row; i++)
        {
            float incRow = (float) (maxVerticalAngle - minVerticalAngle ) / row;
            Vector3 v = Quaternion.AngleAxis(i * incRow + minVerticalAngle, Vector3.right) * fwd;
            for (int j = 0; j < col; j++)
            {
                float incCol = (float) (maxHorizontalAngle - minHorizontalAngle) / col;
                Vector3 dir = Quaternion.AngleAxis(j * incCol + minHorizontalAngle, Vector3.up) * v;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, dir, out hit, 1000))
                {
                    if (j == 0)
                    {
                        Debug.DrawLine(transform.position, hit.point, ObstructionColor, Time.fixedDeltaTime, true);
                    }
                    particles[i, j].transform.position = hit.point;
                    particles[i, j].transform.rotation = Quaternion.LookRotation(dir);
                }
                else
                {
                    particles[i, j].transform.position = transform.position;
                    if (j == 0)
                    {
                        Debug.DrawRay(transform.position, dir * 20f, NoObstructionColor);
                    }
                }
            }
        }


    }



}
