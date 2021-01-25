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
		Ready,					//他プレイヤーと接続中
		Battle,					//ルームの作成
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
				UpDateWaitOtherPlayerConnect();
				break;
				//クライアント側から準備完了
			case State.Ready:
				UpDateReady();
				break;
			default:
				Debug.LogError("想定外のGameState" + m_State);
				break;
		}
    }

	//ほかプレイヤーの接続を待っているときのUpDate
	[Server]
	void UpDateWaitOtherPlayerConnect()
	{
		
		//Ready状態のプレイヤーの数を数え、2の場合は対戦を開始する
		int readyPlayerCount = 0;

		foreach(Test_Player player in FindObjectsOfType<Test_Player>())
		{
			if (player.m_State == Test_Player.State.Connect && readyPlayerCount == 0)
			{
				readyPlayerCount++;
			}
		}

		//対戦相手が1人以上いればバトルの開始(サーバの状態をバトルモードに移行)
		if (readyPlayerCount > 2)
			ChangeGameState(State.Battle);
		else
			Debug.Log("参加者受付中！現在のルーム内人数は" + readyPlayerCount + "人です");
	}

	//各プレイヤーが接続したときのUpdate
	[Server]
	void UpDateConnecting()
	{
		Test_Player[] players = FindObjectsOfType<Test_Player>();
	}

	[Server]
	void UpDateReady()
	{
		
	}

	// 状態を変更する
	[Server]
	void ChangeGameState(State state)
	{
		// m_GameStateを変更すれば、あとはhookによりOnStateChangedが実行される
		m_State = state;
	}

	//GameStateが変更されたときのhook
	void OnStateChanged(State state)
	{
		m_State = state;

		switch (m_State)
		{
			case State.WaitOtherPlayerConnect:
				break;
			case State.Ready:
				if (isServer)
				{

				}
				break;

		}
	}
}
