using EventsControll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using EventsControll;

public class Structions : Events
{
    public float INF = Single.MaxValue;
    // Vars for states App
    public bool MenuState = true;
    public Person person = new Person();
    private void Start()
    {
        
    }

    public struct Mark
    {
        public int id;
        public string cnt;
        public string _date;
        public string login;
        public string place;
    }
    public struct Person
    {
        public string getType
        {
            get
            {
                string value;
                switch (this.type)
                {
                    case 0: value = "student"; break;
                    case 1: value= "aspirant"; break;
                    case 2: value= "teacher"; break;
                    default: value = "student"; break;
                }
                return value;
            }
        }
        public int type;
        public string name;
        public string lastName;
        public string group;
    }
    public string[] NameCorpuses = new string[27] {
        "MAIN",
        "Techno",
        "KPP",
        "Library",
        "B-100",
        "A-100",
        "A",
        "B",
        "31c30",
        "31c31",
        "DinRoom",
        "E",
        "D",
        "V",
        "30",
        "31c42",
        "Sport",
        "45",
        "Reactor",
        "Solser",
        "31c40",
        "31",
        "31c23",
        "Creeogen",
        "98",
        "K",
        "I"
    };
    public string[] NamePaths = new string[22];
    public void generateGraph(GameObject ParentCorpuses, GameObject ParentPaths)
    {

        int N_Paths = ParentPaths.GetComponentsInChildren<Transform>().Length;
        int N_Corpuses = ParentCorpuses.GetComponentsInChildren<Transform>().Length;
        
        GameObject[] Paths = new GameObject[N_Paths];
        GameObject[] Corpuses = new GameObject[N_Corpuses];

        double []size_Paths = new double[N_Paths];
        double []size_Corpuses = new double[N_Corpuses];

        for (int i = 0; i < N_Paths; i++)
        {
            GameObject c = ParentPaths.GetComponentsInChildren<Transform>()[i + 1].gameObject;
            if (Char.ToString(c.name[0]) == "p")
            {
                Paths[i] = c;
            }
            Vector3 size = Paths[i].GetComponent<Renderer>().bounds.size;
            // Находим длину путей в плоскости XZ
            size_Paths[i] = Math.Max(size.x, size.z);
            print($"{i}: {size_Paths[i]}");
        }
        for (int i = 0; i < N_Corpuses; i++)
        {
            Corpuses[i] = ParentCorpuses.GetComponentsInChildren<Transform>()[i + 1].gameObject;
            if (Corpuses[i].name.Substring(0, 3) != "Куб")
            {

            }
            Vector3 size = Corpuses[i].GetComponent<Renderer>().bounds.size;
            size_Corpuses[i] = Math.Max(size.x, size.z);
            print($"{i}: {size_Corpuses[i]}");
        }

        double getDist(float x, float z)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
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


    }
}