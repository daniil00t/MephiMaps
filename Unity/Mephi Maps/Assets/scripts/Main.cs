using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using SocketIO;

public class Main : Marks
{
    private Marks InterfaceMark = new Marks();
    private Mark[] markArray;
    //private static int countMarks;

    public IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        print("start get marks from server");
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            JObject json = JObject.Parse(uwr.downloadHandler.text);
            int count = (int)json["count"];
            //countMarks = count;
            markArray = new Mark[count];

            JArray array = JArray.Parse(json["content"].ToString());

            Dictionary<string, int> corpusesNames = new Dictionary<string, int>();
            Dictionary<string, int> corpusesCount = new Dictionary<string, int>();

            int i = 0;
            InterfaceMark.init(GameObject.Find("Mark_Labels/MarkLabel"), FindObject(GameObject.Find("Mark_Panels"), "Mark_Panel"));

            foreach (JObject obj in array.Children<JObject>())
            {
                string corpus = System.Text.RegularExpressions.Regex.Split((string)obj["place"], "-")[0];

                if (!corpusesNames.ContainsKey(corpus))
                    corpusesNames.Add(corpus, 1);
                else 
                    corpusesNames[corpus]++;

                if (!corpusesCount.ContainsKey(corpus))
                    corpusesCount.Add(corpus, i);
                else
                    corpusesCount[corpus] = i;
                i++;
            }

            i = 0;
            foreach (JObject obj in array.Children<JObject>())
            {
                Mark mark = new Mark();
                string corpus = System.Text.RegularExpressions.Regex.Split((string)obj["place"], "-")[0];

                mark.corpus = corpus;
                mark.marksCount = corpusesNames[corpus];

                

                foreach (JProperty singleProp in obj.Properties())
                {
                    string name = singleProp.Name;
                    string value = singleProp.Value.ToString();
                    
                    // save data to struct Mark()
                    if(name == "id") mark.id = Int32.Parse(value);
                    if(name == "_date") mark._date = value;
                    if(name == "place") mark.place = value;
                    if(name == "user") mark.login  = value;
                    if(name == "content") mark.cnt = value;
                }
                mark.analogMarksAsCorpusName = new string[count];

                foreach (Mark iterMark in markArray)
                {
                    if (iterMark.corpus == corpus)
                    {
                        mark.analogMarksAsCorpusName[i] = iterMark.place;
                    }
                }

                markArray[i] = mark;
                InterfaceMark.renderMark(count, i, mark, corpusesNames, corpusesCount);
                InterfaceMark.renderMarkPanel(count, i, mark, corpusesNames, corpusesCount);

                i++;
            }
        }
    }
    private void updateMarks(SocketIOEvent e)
    {
        print($"Data for all users: {e.data}");
        GameObject Mark_Labels = GameObject.Find("Mark_Labels");
        GameObject Mark_Panels = GameObject.Find("Mark_Panels");
        for (int i = 1; i < Mark_Labels.GetComponentsInChildren<Transform>().Length; i++)
        {
            Destroy(Mark_Labels.GetComponentsInChildren<Transform>()[i].gameObject);
        }

        for (int i = 0; i < Int32.Parse(e.data.ToDictionary()["count"]); i++)
        {
            print($"Mark_Panel_{i}");
            Destroy(FindObject(Mark_Panels, $"Mark_Panel_{i+1}"));
        }


        FindObject(Mark_Labels, "MarkLabel").SetActive(true);
        FindObject(Mark_Panels, "Mark_Panel").SetActive(true);
        /*InterfaceMark.init(GameObject.Find("Mark_Labels/MarkLabel"), FindObject(GameObject.Find("Mark_Panels"), "Mark_Panel"));
        Mark mark = new Mark();
        mark.cnt = e.data.ToDictionary()["content"];
        mark.login = e.data.ToDictionary()["login"];
        mark.place = e.data.ToDictionary()["corpus"];
        InterfaceMark.renderMark(countMarks+1, countMarks+50, mark, corpusesNames, corpusesCount);*/
        StartCoroutine(GetRequest("http://192.168.100.10:5556/marks/get"));
    }
    public void Start()
    {
        SocketIOComponent socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        socket.On("changeMarks", updateMarks);

        StartCoroutine(GetRequest("http://192.168.100.10:5556/marks/get"));

        Debug.Log("Programm is running!");
    }
}
