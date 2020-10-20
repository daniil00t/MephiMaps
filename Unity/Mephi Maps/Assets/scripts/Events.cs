using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Events : Cam_Go
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
        try
        {
			thisButton.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
			toggleMapToCamera(false);

		}
        catch (System.Exception e)
        {
			print(e);
        }
		
	}
}