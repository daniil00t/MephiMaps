using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace _Main_
{
    public class Main : Marks
    {
        public Mark[] _Marks;
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
                string result = uwr.downloadHandler.text;
                //Debug.Log(result);
                string[] arrOne = System.Text.RegularExpressions.Regex.Split(result, "&&");
                Mark[] Marks = new Mark[arrOne.Length];
                //Debug.Log(arrOne.Length);
                for (int i = 0; i < arrOne.Length; i++)
                {
                    string[] arrTwo = System.Text.RegularExpressions.Regex.Split(arrOne[i], "##");

                    Marks[i].id = Int32.Parse(arrTwo[0]);
                    Marks[i].cnt = arrTwo[1];
                    Marks[i]._date = arrTwo[2];
                    Marks[i].login = arrTwo[3];
                    Marks[i].place = arrTwo[4];
                    //Debug.Log(Marks[i].id);
                    //Debug.Log(Marks[i].cnt);
                    //Debug.Log(Marks[i]._date);
                    //Debug.Log(Marks[i].login);
                }
                _Marks = Marks;


                Marks _mark = new Marks();
                _mark.initMarks(Marks);
                _mark.start();
            }
        }
        public IEnumerator GetWeather(string uri)
        {
            UnityWebRequest uwr = UnityWebRequest.Get(uri);
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                string result = uwr.downloadHandler.text;
                
            }
        }
        private void Start()
        {
            
            Debug.Log("Programm is running!");
            StartCoroutine(GetRequest("http://localhost:5556/marks/get"));
            string urlWeather = "https://api.weather.yandex.ru/v2/informers?lat=55.650065057073256&lon=37.66450278636252";
            //[55.650065057073256,37.66450278636252]

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Yandex-API-Key", "7c5d2aac-973d-40ef-816a-e6b0173893c1");

            WWW www = new WWW(urlWeather, new Byte[0], headers);
            Debug.Log($"-----------------Weather: {www.text}--------------");
/*            {
                if (string.IsNullOrEmpty(www.error))
                {
                    
                    
                }
                else
                {
                    Debug.LogError("Error: " + www.error);
                }
            }*/
            
            //generateGraph(GameObject.Find("Map"), GameObject.Find("Paths"));
        }
    }
}
