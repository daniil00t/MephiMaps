using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Structions : MonoBehaviour
{
    public static User user = new User();
    public static State state = new State(true, false, true);

    public delegate void Callback();
    public struct Mark
    {
        public int id;
        public string cnt;
        public string _date;
        public string login;
        public string place;
        public string corpus;
        public int marksCount;
        public string[] analogMarksAsCorpusName;
    }

    public struct State
    {
        public bool Menu;
        public bool addMarkPanel;
        public bool threeD;
        public State(bool Menu, bool addMarkPanel, bool threeD)
        {
            this.Menu = Menu;
            this.addMarkPanel = addMarkPanel;
            this.threeD = threeD;
        }
        
    }
    public Dictionary<string, string> NameCorpuses = new Dictionary<string, string>() {
        {"MAIN", "Главная"},
        {"Techno", "Технопарк"},
        {"KPP", "КПП"},
        {"Library", "Библиотека"},
        {"B-100", "Б-100"},
        {"A-100", "А-100"},
        {"A", "А"},
        {"B", "Б"},
        //{"31c30", ""},
        //{"31c31", ""},
        {"DinRoom", "Столовая"},
        {"E", "Е"},
        {"D", "Д"},
        {"V", "В"},
        //{"30", ""},
        //{"31c42", ""},
        {"Sport", "Спортзал"},
        //{"45", ""},
        {"Reactor", "Ядерный реактор"},
        {"Solser", "Военка"},
        //{"31c40", ""},
        //{"31", ""},
        //{"31c23", ""},
        {"Creeogen", "Криоген"},
        //{"98", ""},
        {"K", "К"},
        {"I", "И"}
    };
    public string[] NameCorpusesKeys = new string[] {
        "MAIN",
        "Techno",
        "KPP",
        "Library",
        "B-100",
        "A-100",
        "A",
        "B",
        //"31c30",
        //"31c31",
        "DinRoom",
        "E",
        "D",
        "V",
        //"30",
        //"31c42",
        "Sport",
        //"45",
        "Reactor",
        "Solser",
        //"31c40",
        //"31",
        //"31c23",
        "Creeogen",
        //"98",
        "K",
        "I"
    };


    public struct User
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
        public string login;
    }
    public GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
   
}