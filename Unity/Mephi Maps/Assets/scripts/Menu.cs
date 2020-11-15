using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketIO;
using Newtonsoft.Json.Linq;
using System.Threading;

public class Menu : Sockets
{
    // Init vars is called before the first frame update
    public Button goBtn;
    public Dropdown thisDropdown;
    public TMP_InputField LoginInput;
    public TMP_InputField NameInput;
    public TMP_InputField LastNameInput;
    public TMP_InputField GroupInput;
    
    void Start()
    {
        goBtn.onClick.AddListener(InitUser);
    }

    // Update is called once per frame
    private void InitUser()
    {
        

        // Init Components 
        string Name = NameInput.GetComponent<TMP_InputField>().text;
        string LastName = LastNameInput.GetComponent<TMP_InputField>().text;
        string Group = GroupInput.GetComponent<TMP_InputField>().text;
        string Login = LoginInput.GetComponent<TMP_InputField>().text;
        //int TypePerson = thisDropdown.GetComponent<Dropdown>().value;
        Dictionary<string, string> data = new Dictionary<string, string>();

        user.name = Name;
        user.lastName = LastName;
        user.group = Group;
        user.login = Login;
        //user.type = TypePerson;

        data.Add("name", Name);
        data.Add("last_name", LastName);
        data.Add("group", Group);
        data.Add("login", Login);
        //data.Add("type", user.getType);

        print($"{Name}{LastName}{Group}{Login}");
        StartCoroutine(sendDataToServer("initUser", data, disableMenu));
    }
    private void disableMenu()
    {
        gameObject.SetActive(false);
        state.Menu = false;
    }
}
