using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : Structions
{
    // Init vars is called before the first frame update
    public Button goBtn;
    public Dropdown thisDropdown;
    public TMP_InputField NameInput;
    public TMP_InputField LastNameInput;
    public TMP_InputField GroupInput;

    

    void Start()
    {
        Button go = goBtn.GetComponent<Button>();
        
        go.onClick.AddListener(StartApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartApp()
    {
        
        // canvas _Manu
        GameObject _Menu = gameObject.transform.parent.parent.gameObject;

        // Init Components 
        string Name = NameInput.GetComponent<TMP_InputField>().text;
        string LastName = LastNameInput.GetComponent<TMP_InputField>().text;
        string Group = GroupInput.GetComponent<TMP_InputField>().text;
        int TypePerson = thisDropdown.GetComponent<Dropdown>().value;

        person.name = Name;
        person.lastName = LastName;
        person.group = Group;
        person.type = TypePerson;
        


        print(person);

        MenuState = false;
        _Menu.SetActive(false);
    }
}
