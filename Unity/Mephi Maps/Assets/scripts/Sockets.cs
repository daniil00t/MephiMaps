using System.Collections;
using UnityEngine;
using SocketIO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

public class Sockets : Structions
{
	public GameObject socketGO;
	private SocketIOComponent socket;

	public IEnumerator sendDataToServer(string nameEvent, Dictionary<string, string> data, Callback callback)
	{
		socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
		// wait 1 seconds and continue
		yield return new WaitForSeconds(0.8f);
		print($"send massage: {nameEvent}, {data["login"]}");
		socket.Emit(nameEvent, JSONObject.Create(data));
		callback();
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
