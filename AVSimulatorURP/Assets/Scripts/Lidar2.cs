using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidar2 : MonoBehaviour
{
    public GameObject particle;
    GameObject[,] particles;
    Vector3[,] positions;
    public int row = 64;
    public int col = 180;
    float minVerticalAngle = -30f;
    float maxVerticalAngle = 20f;
    float minHorizontalAngle = -180f;
    float maxHorizontalAngle = 180f;
    public Color NoObstructionColor = new Color(0.66f, 1f, 0.52f);
    public Color ObstructionColor = new Color(0.66f, 1f, 0.52f);
    List<Color> colors;
    public Transform folder;
    public Transform origin;
    Color[] segmentationColors = new Color[] { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };
    int fixedFrame = 0;
    int layer;


    // Start is called before the first frame update
    void Start()
    {
        particles = new GameObject[row, col];
        positions = new Vector3[row, col];
        //colors = new List<Color>();
        //float colorInc = 0.5f / ((float)row);
        //Vector3 randomPos = new Vector3(-100f, 0f, 0f);
        Quaternion rot = particle.transform.rotation;
        // layer = LayerMask.NameToLayer("NoPostProcessing");


        for (int i = 0; i < row; i++)
        {

            // colors.Add(Color.HSVToRGB(colorInc * i, 1, 1));
            for (int j = 0; j < col; j++)
            {
                Vector3 randomPos = new Vector3(Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50));
                GameObject obj = Instantiate(particle, randomPos, rot).gameObject;
                particles[i, j] = obj;
                //// particles[i, j].GetComponent<Renderer>().material.color = colors[i];
                particles[i, j].transform.parent = folder;
                //particles[i, j].layer = layer;

                //Vector3 randomPos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
                //GameObject a = Instantiate(particle, randomPos, particle.transform.rotation);
                // particles[i, j].GetComponent<Renderer>().material.color = colors[i];
                //a.transform.parent = folder;
            }
        }

    }

    void FixedUpdate()
    {
        Vector3 randomPos = new Vector3(0f, -100f, 0f);
        if (fixedFrame % 3 == 0)
        {
            Vector3 fwd = Vector3.forward;
            int castCount = 0;
            for (int i = 0; i < row; i++)
            {
                float incRow = (float)(maxVerticalAngle - minVerticalAngle) / row;
                Vector3 v = Quaternion.AngleAxis(i * incRow + minVerticalAngle, Vector3.right) * fwd;
                for (int j = 0; j < col; j++)
                {
                    float incCol = (float)(maxHorizontalAngle - minHorizontalAngle) / col;
                    Vector3 dir = Quaternion.AngleAxis(j * incCol + minHorizontalAngle, Vector3.up) * v;
                    RaycastHit hit;

                    if (Physics.Raycast(origin.position, dir, out hit, 100))
                    {
                        castCount++;
                        if (j == 0)
                        {
                            //Debug.DrawLine(origin.position, hit.point, ObstructionColor, Time.fixedDeltaTime, true);
                        }
                        positions[i, j] = hit.point;
                        Transform tr = particles[i, j].transform;
                        Vector3 vec = tr.position;
                        tr.position = hit.point;
                        tr.rotation = Quaternion.LookRotation(dir);
                        //if (hit.collider.gameObject.CompareTag("Cube"))
                        //{
                        //    particles[i, j].GetComponent<Renderer>().material.color = segmentationColors[0];
                        //}
                        //else if (hit.collider.gameObject.CompareTag("Sphere"))
                        //{
                        //    particles[i, j].GetComponent<Renderer>().material.color = segmentationColors[1];
                        //}
                        //else
                        //{
                        //    particles[i, j].GetComponent<Renderer>().material.color = segmentationColors[2];
                        //}

                    }
                    else
                    {
                        //Vector3 randomPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, -20), Random.Range(-100, 100));
                        particles[i, j].transform.position = randomPos;
                        //if (j == 0)
                        //{
                        //    Debug.DrawRay(origin.position, dir * 20f, NoObstructionColor);
                        //}
                    }
                }
            }
            Debug.Log(castCount);
        }
        fixedFrame++;

    }

}


//    void FixedUpdate()
//    {
//        if (fixedFrame % 3 == 0)
//        {
//            int AddedMatricies = 0;
//            Vector3 randomPos = new Vector3(0f, -100f, 0f);
//            float scale = instancer.scale;
//            List<List<Matrix4x4>> batches = new List<List<Matrix4x4>>();

//            Vector3 fwd = Vector3.forward;
//            for (int i = 0; i < row; i++)
//            {
//                float incRow = (float)(maxVerticalAngle - minVerticalAngle) / row;
//                Vector3 v = Quaternion.AngleAxis(i * incRow + minVerticalAngle, Vector3.right) * fwd;
//                for (int j = 0; j < col; j++)
//                {
//                    float incCol = (float)(maxHorizontalAngle - minHorizontalAngle) / col;
//                    Vector3 dir = Quaternion.AngleAxis(j * incCol + minHorizontalAngle, Vector3.up) * v;
//                    RaycastHit hit;


//                    //if (j == 0)
//                    //{
//                    //    Debug.DrawRay(origin.position, dir * 20f, NoObstructionColor, 1f);
//                    //}

//                    if (Physics.Raycast(origin.position, dir, out hit, 100))
//                    {
//                        if (AddedMatricies < 999 && batches.Count != 0)
//                        {
//                            Matrix4x4 mat = Matrix4x4.TRS(hit.point, Quaternion.LookRotation(dir), Vector3.one * scale);
//                            batches[batches.Count - 1].Add(mat);
//                            AddedMatricies += 1;
//                        }
//                        else
//                        {
//                            batches.Add(new List<Matrix4x4>());
//                            AddedMatricies = 0;
//                        }

//                    }

//                }
//            }
//            instancer.batches = batches;
//        }
//        fixedFrame++;


//    }

//}


