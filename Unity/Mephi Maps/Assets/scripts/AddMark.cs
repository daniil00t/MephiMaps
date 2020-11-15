using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketIO;
using Newtonsoft.Json.Linq;

public class AddMark : Sockets
{

    public Button add;
    public TMP_InputField content;
    public Dropdown corpus;
    public GameObject success;
    public void PopulateDropdown(Dropdown dropdown, string[] optionsArray)
    {
        List<string> options = new List<string>();
        foreach (string option in optionsArray)
        {
            options.Add(option); // Or whatever you want for a label
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    void Start()
    { 
        add.onClick.AddListener(sendData);
        string[] values = new string[NameCorpuses.Count];
        int j = 0;
        foreach(var i in NameCorpuses.Values)
        {
            values[j] = i;
            j++;
        }
        PopulateDropdown(corpus, values);
    }
    private void sendData()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("content", content.GetComponent<TMP_InputField>().text);
        data.Add("corpus", NameCorpusesKeys[corpus.value]);
        data.Add("login", user.login);

        success.SetActive(true);
        StartCoroutine(sendDataToServer("addMark", data, callback));
    }
    private void callback()
    {
        state.addMarkPanel = false;
        gameObject.SetActive(false);
        FindObject(GameObject.Find("UI"), "Layout").SetActive(true);
        success.SetActive(false);
        //GameObject.Find("Layout").SetActive(true);
    }

}
