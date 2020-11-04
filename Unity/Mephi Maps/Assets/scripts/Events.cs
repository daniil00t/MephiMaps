using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace EventsControll
{
	
	public class Events : Cam_Go
	{
		public static GameObject FindObject(GameObject parent, string name)
		{
			Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
			foreach (Transform t in trs)
			{
				if (t.name == name)
				{
					return t.gameObject;
				}
			}
			return null;
		}
		public Button SettingsBtn;

		public Button ExitBtn;
		public GameObject ExitBlock;

		public int CameraState = 0;
		public GameObject SettingsPage = FindObject(GameObject.Find("UI"), "Settings");
		// CameraState = 0 - Normal state
		// CameraState = 1 - 2D mod
		// CameraState = 2 - Menu
		public void Start()
		{
			Button _SettingsBtn = SettingsBtn.GetComponent<Button>();
			_SettingsBtn.onClick.AddListener(OpenSettings);

			Button _ExitBtn = ExitBtn.GetComponent<Button>();
			ExitBtn.onClick.AddListener(BlockExit);
			print("Start events!");
		}
		public void OpenSettings()
        {
			SettingsPage.SetActive(true);
        }
		public void BlockExit()
        {
			ExitBlock.SetActive(false);

		}
	}
}
