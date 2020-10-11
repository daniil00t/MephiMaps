using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Events : MonoBehaviour
{
	public Button thisButton;

	public void Start()
	{
		Button btn = thisButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		print(thisButton.gameObject.transform.parent.gameObject.name);
		thisButton.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
	}
}