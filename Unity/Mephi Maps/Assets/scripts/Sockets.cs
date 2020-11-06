using System.Collections;
using UnityEngine;
using SocketIO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class Sockets : MonoBehaviour
{
	private SocketIOComponent socket;

	public void Start()
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", TestOpen);
		socket.On("hello", TestBoop);
		socket.On("close", TestClose);

		StartCoroutine(BeepBoop());
	}

	private IEnumerator BeepBoop()
	{
		// wait 1 seconds and continue
		yield return new WaitForSeconds(1);

		Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("cnt", "hello!");


		socket.Emit("helloMMM", JSONObject.Create(data));
	}

	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}

	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}

	public void TestError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}

	public void TestClose(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}
