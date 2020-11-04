using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*using System.Text.Json;
using System.Text.Json.Serialization;*/
using Newtonsoft.Json.Linq;
//using LitJson;

namespace _Main_
{
    public class Main : Marks
    {
        public Mark[] _Marks;


        IEnumerator _GetRequest(UnityWebRequestAsyncOperation wr)
        {
            yield return wr;
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

                //Debug.Log(result);
                print($"----------------{uwr.downloadHandler.text}------------");
                /*string[] arrOne = System.Text.RegularExpressions.Regex.Split(result, "&&");
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
                }*/
                _Marks = new Mark[1];


                Marks _mark = new Marks();
                _mark.initMarks(new Mark[1]);
                _mark.start();
            }
        }
        public void Start()
        {
            /*using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:5556/users/get/")){
                StartCoroutine(_GetRequest(webRequest.SendWebRequest()));

                print(webRequest.downloadHandler.text);
                
            }
            
            Debug.Log("Programm is running!");
            //string urlWeather = "https://api.weather.yandex.ru/v2/informers?lat=55.650065057073256&lon=37.66450278636252";
            //[55.650065057073256,37.66450278636252]*/
        }
    }
}
