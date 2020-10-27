using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Settings : Structions
{

    public Button goBtn;
    public Dropdown thisDropdown;
    public TMP_InputField NameInput;
    public TMP_InputField LastNameInput;
    public TMP_InputField GroupInput;

    void Start()
    {
        NameInput.GetComponent<TMP_InputField>().text = person.name;
        LastNameInput.GetComponent<TMP_InputField>().text = person.lastName;
        GroupInput.GetComponent<TMP_InputField>().text = person.group;
        thisDropdown.GetComponent<Dropdown>().value = person.type;
    }

    // Update is called once per frame
/*    void Update()
    {
        
    }*/
}
