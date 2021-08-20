using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NavigeModule : MonoBehaviour
{
    public GameObject ParentCorpuses;
    public GameObject ParentPaths;


    private double INF = Single.MaxValue;
    private const int pathCount = 38;
    private bool[,] AdjacencyMatrix = new bool[pathCount, pathCount];
    // Start is called before the first frame update
    void Start()
    {
        generateGraph(ParentCorpuses, ParentPaths);
    }
    private double getDist(float x, float z)
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
    }
    private bool adjacentPaths(GameObject P1, GameObject P2)
    {
        float f = 5f;
        double epsilon = 20f;
        bool res;


        double centerP1;
        double centerP2;

        double sizeP1;
        double sizeP2;
        if (P1.transform.position.x == P2.transform.position.x && P1.transform.position.z == P2.transform.position.z){
            return true;
        }
        print(P1.transform.localScale);
        if (Math.Abs(P1.transform.localScale.x) > Math.Abs(P1.transform.localScale.z) && Math.Abs(P2.transform.localScale.x) > Math.Abs(P2.transform.localScale.z))
        {
            // in X axis
            sizeP1 = Math.Abs(P1.transform.localScale.x) / 2 * f;
            centerP1 = P1.transform.position.x;

            sizeP2 = Math.Abs(P2.transform.localScale.x) / 2 * f;
            centerP2 = P2.transform.position.x;

            print($"X--{P1.name}: {Math.Abs((centerP1 + sizeP1) - (centerP2 - sizeP2))} || {P2.name}: {Math.Abs((centerP1 - sizeP1) - (centerP2 + sizeP2))}");
            res = Math.Min(Math.Abs(centerP1 + sizeP1 - (centerP2 - sizeP2)), Math.Abs(centerP1 - sizeP1 - (centerP2 + sizeP2))) < epsilon;
        }
        else if(Math.Abs(P1.transform.localScale.x) < Math.Abs(P1.transform.localScale.z) && Math.Abs(P2.transform.localScale.x) < Math.Abs(P2.transform.localScale.z))
        {
            sizeP1 = Math.Abs(P1.transform.localScale.z) / 2 * f;
            centerP1 = P1.transform.position.z;
            sizeP2 = Math.Abs(P2.transform.localScale.z) / 2 * f;
            centerP2 = P2.transform.position.z;
            print($"Z--{P1.name}: {Math.Abs((centerP1 + sizeP1) - (centerP2 - sizeP2))} || {P2.name}: {Math.Abs((centerP1 - sizeP1) - (centerP2 + sizeP2))}");
            res = Math.Min(Math.Abs(centerP1 + sizeP1 - (centerP2 - sizeP2)), Math.Abs(centerP1 - sizeP1 - (centerP2 + sizeP2))) < epsilon;
        }
        else
        {

            float sizeP1_x = Math.Abs(P1.transform.localScale.x) / 2 * f;
            float centerP1_x = P1.transform.position.x;
            float sizeP2_x = Math.Abs(P2.transform.localScale.x) / 2 * f;
            float centerP2_x = P2.transform.position.x;

            float sizeP1_z = Math.Abs(P1.transform.localScale.z) / 2 * f;
            float centerP1_z = P1.transform.position.z;
            float sizeP2_z = Math.Abs(P2.transform.localScale.z) / 2 * f;
            float centerP2_z = P2.transform.position.z;


            float dx = Math.Min(Math.Min(Math.Abs(centerP1_x + sizeP1_x - (centerP2_x - sizeP2_x)), Math.Abs(centerP1_x - sizeP1_x - (centerP2_x + sizeP2_x))), Math.Min(Math.Abs(centerP1_x + sizeP1_x - (centerP2_x + sizeP2_x)), Math.Abs(centerP1_x - sizeP1_x - (centerP2_x - sizeP2_x))));
            float dz = Math.Min(Math.Min(Math.Abs(centerP1_z + sizeP1_z - (centerP2_z - sizeP2_z)), Math.Abs(centerP1_z - sizeP1_z - (centerP2_z + sizeP2_z))), Math.Min(Math.Abs(centerP1_z + sizeP1_z - (centerP2_z + sizeP2_z)), Math.Abs(centerP1_z - sizeP1_z - (centerP2_z - sizeP2_z))));

            print($"XZ--{P1.name} and {P2.name}: {getDist(dx, dz)}");
            res = getDist(dx, dz) < epsilon;
        }


        //print($"{P1.name}: {Math.Abs((centerP1 + sizeP1) - (centerP2 - sizeP2))} || {P2.name}: {Math.Abs((centerP1 - sizeP1) - (centerP2 + sizeP2))}");


        return res;
    }
    public void generateGraph(GameObject ParentCorpuses, GameObject ParentPaths)
    {
        //int N_Paths = ParentPaths.GetComponentsInChildren<Transform>().Length;
        //int N_Corpuses = ParentCorpuses.GetComponentsInChildren<Transform>().Length;

        Transform[] _Paths = ParentPaths.GetComponentsInChildren<Transform>();
        GameObject[] Paths = new GameObject[pathCount];
        //GameObject[] Corpuses = new GameObject[N_Corpuses];

        //double []size_Paths = new double[N_Paths];
        //double []size_Corpuses = new double[N_Corpuses];
        int j = 0;
        foreach (Transform i in _Paths)
        {
            //print($"{i.gameObject.name[0]}, {Char.ToString(i.gameObject.name[0]) == "p"}");
            if (Char.ToString(i.gameObject.name[0]) == "p")
            {
                Paths[j] = i.gameObject;
                j++;
            }
            
        }
        j = 0;

        foreach (GameObject item in Paths)
        {
            string r = $"{item.name}: ";
            for (int k = 0; k < pathCount; k++)
            {
                AdjacencyMatrix[j, k] = adjacentPaths(item, Paths[k]);
                r += AdjacencyMatrix[j, k] + " ";
            }
            print(r);
            j++;
        }



        /*for (int i = 0; i < N_Corpuses; i++)
        {
            Corpuses[i] = ParentCorpuses.GetComponentsInChildren<Transform>()[i + 1].gameObject;
            if (Corpuses[i].name.Substring(0, 3) != "Куб")
            {

            }
            Vector3 size = Corpuses[i].GetComponent<Renderer>().bounds.size;
            size_Corpuses[i] = Math.Max(size.x, size.z);
            print($"{i}: {size_Corpuses[i]}");
        }

        
        // Обходим все входы в корпуса
        GameObject[] parEntr = new GameObject[GetComponentsInChildren<Transform>().Length];
        int[] ConPaths = new int[parEntr.Length];
        for (int i = 1; i < parEntr.Length; i++)
        {
            double minDist = INF;
            for (int j = 0; j < Paths.Length; j++)
            {
                float dx = Paths[j].transform.position.x;
                float dz = Paths[j].transform.position.z;
                float length = Convert.ToSingle(size_Paths[i]);

                float lx = parEntr[i].transform.position.x;
                float lz = parEntr[i].transform.position.z;
                if (minDist > getDist(dx - lx, dz - lz))
                {
                    minDist = getDist(dx - lx, dz - lz);
                    ConPaths[i] = j;
                }
                if (minDist > getDist((dx - length / 2) - lx, dz - lz))
                {
                    minDist = getDist((dx - length / 2) - lx, dz - lz);
                    ConPaths[i] = j;
                }
                if (minDist > getDist(dx - lx, (dz - length / 2) - lz))
                {
                    minDist = getDist(dx - lx, (dz - length / 2) - lz);
                    ConPaths[i] = j;
                }
            }
        }


        // Обходим все пути для создания сети путей
        int[,] BoundsPath = new int[Paths.Length, 2];
        for (int i = 0; i < Paths.Length; i++)
        {
            double minDist = INF;
            for (int j = i + 1; j < Paths.Length; j++)
            {
                float dx = Paths[i].transform.position.x;
                float dz = Paths[i].transform.position.z;
                float lengthM = Convert.ToSingle(size_Paths[i]);

                float lx = Paths[j].transform.position.x;
                float lz = Paths[j].transform.position.z;
                float lengthO = Convert.ToSingle(size_Paths[j]);



                if (minDist > getDist(dx - lx, dz - lz))
                {
                    minDist = getDist(dx - lx, dz - lz);
                    ConPaths[i] = j;
                }
                if (minDist > getDist((dx - lengthM / 2) - lx, dz - lz))
                {
                    minDist = getDist((dx - lengthM / 2) - lx, dz - lz);
                    ConPaths[i] = j;
                }
                if (minDist > getDist(dx - lx, (dz - lengthM / 2) - lz))
                {
                    minDist = getDist(dx - lx, (dz - lengthM / 2) - lz);
                    ConPaths[i] = j;
                }
            }
        }
*/

    }
}
