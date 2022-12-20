using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class Client : MonoBehaviour
{
    [SerializeField] private string ipString;
    [SerializeField] private int port;

    private void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        IPAddress ip = IPAddress.Parse(ipString);

        TcpClient client = new TcpClient();
        client.Connect(ip, port);
        Console.WriteLine("Connected to server");

        NetworkStream stream = client.GetStream();

        string message = "Hello from the client";
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Sent: " + message);

        data = new byte[1024];
        int bytesReceived = stream.Read(data, 0, data.Length);
        string response = Encoding.ASCII.GetString(data, 0, bytesReceived);
        Console.WriteLine("Received: " + response);

        stream.Close();
        client.Close();
    }
}