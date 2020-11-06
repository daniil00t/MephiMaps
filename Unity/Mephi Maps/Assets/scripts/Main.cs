using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;


public class Main : Marks
{
    private Marks InterfaceMark = new Marks();
    private static GameObject FindObject(GameObject parent, string name)
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

    public IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            JObject json = JObject.Parse(uwr.downloadHandler.text);
            int count = (int)json["count"];


            JArray array = JArray.Parse(json["content"].ToString());

            int i = 0;
            InterfaceMark.init(GameObject.Find("Mark_Labels/MarkLabel"), FindObject(GameObject.Find("Mark_Panels"), "Mark_Panel"));
            foreach (JObject obj in array.Children<JObject>())
            {
                Mark mark = new Mark();
                foreach (JProperty singleProp in obj.Properties())
                {
                    string name = singleProp.Name;
                    string value = singleProp.Value.ToString();

                    // save data to struct Mark()
                    if(name == "id") mark.id = Int32.Parse(value);
                    if(name == "_date") mark._date = value;
                    if(name == "place") mark.place =   value;
                    if(name == "user") mark.login = value;
                    if(name == "content") mark.cnt = value;

                }
                InterfaceMark.renderMark(count, i, mark);
                InterfaceMark.renderMarkPanel(count, i, mark);

                i++;
            }
        }
    }
    public void Start()
    {
        

        StartCoroutine(GetRequest("http://localhost:5556/marks/get"));

        Debug.Log("Programm is running!");
        //string urlWeather = "https://api.weather.yandex.ru/v2/informers?lat=55.650065057073256&lon=37.66450278636252";
        //[55.650065057073256,37.66450278636252]
    }
}
