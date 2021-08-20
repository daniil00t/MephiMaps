using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LayoutEvents : Structions
{
    public Button openSettings;
    //public Button openARCamera;
    public Button openAddMarkPanel;

    public GameObject SettingsPanel;
    //public GameObject ARCamera;
    public GameObject AddMarkForm;
    // Start is called before the first frame update
    void Start()
    {
        // Listeners
        //openSettings.onClick.AddListener(TaskOnClick);
        //openARCamera.onClick.AddListener(TaskOnClick);
        openAddMarkPanel.onClick.AddListener(openAddMarkPanelFunc);
    }
    private void openAddMarkPanelFunc()
    {
        state.addMarkPanel = true;
        AddMarkForm.SetActive(true);
        gameObject.SetActive(false);
    }
}
