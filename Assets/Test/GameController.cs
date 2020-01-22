using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(sendInterval = 0)]
public class GameController : NetworkBehaviour
{
	public enum State
	{
		WaitOtherPlayerConnect, //ほかプレイヤーの参加待ち
		Connect,				//他プレイヤーと接続中
	}

	[SyncVar(hook = "OnStateChanged")]
	State m_State = State.WaitOtherPlayerConnect;

    // Start is called before the first frame update
    void Start()
    {
		OnStateChanged(m_State);
    }

	// Update is called once per frame
	// Updateはサーバーでのみ行う
	[ServerCallback]
	void Update()
    {
		switch (m_State)
		{
			case State.WaitOtherPlayerConnect:
				//UpDateWaitOtherPlayerConnect();
				break;
			case State.Connect:
				//UpdateResult();
				break;
			default:
				Debug.LogError("想定外のGameState" + m_State);
				break;
		}
    }

	//ほかプレイヤーの接続を待っているときのUpDate
	[Server]
	void UpDataWaitOtherPalyerConnect()
	{
		//Ready状態のプレイヤーの数を数え、2の場合は対戦を開始する
		int readyPlayerCount = 0;

		foreach(Test_Player player in FindObjectsOfType<Test_Player>())
		{
			
		}
	}

	//各プレイヤーが接続したときのUpdate
	[Server]
	void UpDateConnecting()
	{
		Test_Player[] players = FindObjectsOfType<Test_Player>();
	}

	//GameStateが変更されたときのhook
	void OnStateChanged(State state)
	{
		m_State = state;

		switch (m_State)
		{
			case State.WaitOtherPlayerConnect:
				break;
			case State.Connect:
				if (isServer)
				{

				}
				break;

		}
	}
}
