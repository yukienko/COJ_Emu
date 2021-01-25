using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MessageTest : MonoBehaviour
{
	const int Port = 7777; // ポート番号。他のプログラムと被らなければ何でも良いです

	NetworkClient client;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			print("サーバー起動");
			NetworkServer.Listen(Port);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			print("Handlerを登録");
			NetworkServer.RegisterHandler(MyMsg.Hoge, OnHogeReceived);
			NetworkServer.RegisterHandler(MyMsg.Fuga, OnFugaReceived);
			NetworkServer.RegisterHandler(MyMsg.Custom, OnCustomMessageReceived);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			print("サーバーから全クライアントへMsgHogeを送信");
			NetworkServer.SendToAll(MyMsg.Hoge, new EmptyMessage());
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			print("サーバーから全クライアントへMsgFugaを送信");
			NetworkServer.SendToAll(MyMsg.Fuga, new EmptyMessage());
		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			print("サーバーから全クライアントへ123を送信");
			NetworkServer.SendToAll(MyMsg.Int, new IntegerMessage(123));
		}

		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			print("サーバーから全クライアントへ文字列を送信");
			NetworkServer.SendToAll(MyMsg.String, new StringMessage("こんにちは"));
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			print("クライアント生成");
			client = new NetworkClient();
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			print("client.isConnected:" + client.isConnected);
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			print("クライアントをサーバーへ接続");
			client.Connect("192.168.0.4", Port);
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			print("Handlerを登録");
			client.RegisterHandler(MyMsg.Hoge, OnHogeReceived);
			client.RegisterHandler(MyMsg.Fuga, OnFugaReceived);
			client.RegisterHandler(MyMsg.Int, OnIntegerMessageReceived);
			client.RegisterHandler(MyMsg.String, OnStringMessageReceived);
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			print("クライアントからサーバーへMsgHogeを送信");
			client.Send(MyMsg.Hoge, new EmptyMessage());
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			print("クライアントからサーバーへMsgFugaを送信");
			client.Send(MyMsg.Fuga, new EmptyMessage());
		}

		if (Input.GetKeyDown(KeyCode.U))
		{
			print("クライアントからサーバーへCustomMessageを送信");
			CustomMessage m = new CustomMessage();
			m.intValue = 1234;
			m.floatValue = 567.8f;
			m.stringValue = "あいうえお";
			m.hoge = new int[] {1,2,3,4};
			m.vector3Value = new Vector3(1, 2, 3);
			client.Send(MyMsg.Custom, m);
		}
	}

	void OnHogeReceived(NetworkMessage message)
	{
		print("MsgHogeを受信");
	}

	void OnFugaReceived(NetworkMessage message)
	{
		print("MsgFugaを受信");
	}

	void OnIntegerMessageReceived(NetworkMessage message)
	{
		int value = message.ReadMessage<IntegerMessage>().value;
		print("IntegerMessageを受信:" + value);
	}

	void OnStringMessageReceived(NetworkMessage message)
	{
		string value = message.ReadMessage<StringMessage>().value;
		print("StringMessageを受信:" + value);
	}

	class CustomMessage : MessageBase
	{
		public int intValue;
		public float floatValue;
		public string stringValue;
		public int[] hoge;
		public Vector3 vector3Value;
	}

	void OnCustomMessageReceived(NetworkMessage message)
	{
		CustomMessage m = message.ReadMessage<CustomMessage>();

		Debug.LogFormat("CustomMessageを受信:{0}, {1}, {2}, {3}, {4}", m.intValue, m.floatValue, m.stringValue, m.hoge[3], m.vector3Value);
	}
}
