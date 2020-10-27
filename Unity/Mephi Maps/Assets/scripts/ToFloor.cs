using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToFloor : Cam_Go
{
	public Button thisButton;

	public void Start()
	{
		Button btn = thisButton.GetComponent<Button>();
		btn.onClick.AddListener(ToFLoorClick);
	}

    public void ToFLoorClick()
    {
        Debug.Log("You have clicked the button!");
        string name = thisButton.gameObject.name;
        string[] temp = System.Text.RegularExpressions.Regex.Split(name, "_");
        string corpus = temp[0];
        int floor = Int32.Parse(temp[1].Substring(1));

        toggleMapToCamera(0);

        Transform[] TwoDChildren = GameObject.Find("2D").GetComponentsInChildren<Transform>();
        print($"Corpus: {corpus}");
        print($"floor: {floor}");
        GameObject.Find($"2D/Corpuses/BG").gameObject.SetActive(true);
        GameObject.Find($"2D/Corpuses/Corpus_{corpus}/Floor{floor}").gameObject.SetActive(true);
        for (int i = 0; i < TwoDChildren.Length; i++)
        {
            print(TwoDChildren[i].gameObject.name);
        }

        thisButton.gameObject.transform.parent.gameObject.SetActive(false);
    }
}