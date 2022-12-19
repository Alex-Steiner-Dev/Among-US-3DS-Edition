using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class NetworkingManager : MonoBehaviour {

	[SerializeField] private UnityEngine.UI.Text infoText;

	[SerializeField] private string url;
	private WebSocket socket;

	private void Start()
	{
		ConnectToServer();
	}

	private void Update()
	{
        if (socket == null)
        {
            return;
        }
    }

	private void ConnectToServer()
	{
		try
		{
			socket = new WebSocket(url);
			socket.Connect();

            socket.OnMessage += (sender, e) =>
			{
				if (e.IsText)
				{
					infoText.text = (e.Data);
				}
			};
		}

		catch(Exception e)
		{
			infoText.text = e.Message;
			ConnectToServer();
		}
	}

	private void SendMessage(Vector3 pos)
	{

	}

    private void SendMessase(string msg)
    {

    }

    private void ReceiveMessage(Vector3 pos)
    {

    }

    private void ReceiveMessase(string msg)
    {

    }
}
