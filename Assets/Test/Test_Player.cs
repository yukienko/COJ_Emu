using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


// プレイヤー1人分の表示を管理する。
[NetworkSettings(sendInterval = 0)]
public class Test_Player : NetworkBehaviour
{
	//タイトルで入力されたプレイヤー名
	public static string s_LocalPlayerName = "名無しさん";

	public enum Id
	{
		None,	//なし
		B,		//ベルゼ
		A,		//アーミーアント
	}

	public enum State
	{
		Initializing,	//初期化中
		Connect,		//準備完了、ホストに入れます。
		Ready,			//ホストに接続済み
	}

	// プレイヤーの状態
	[SyncVar(hook = "OnStateChanged")]
	public State m_State = State.Initializing;

	// id
	[SyncVar(hook = "OnIdChanged")]
	public Id m_Id = Id.None;

	// プレイヤー名
	[SyncVar(hook = "OnPlayerNameChanged")]
	string m_PlayerName;

	// プレイヤー名Textの参照
	Text m_PlayerNameText;

	void Awake()
	{
		// プレイヤーオブジェクトはシーンのルートに生成されるので、
		// PlayerBlockの中に移動する。
		transform.SetParent(GameObject.Find("PlayerBlock").transform);
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;

		// 各種参照を取得する
		m_PlayerNameText = GameObject.Find("PlayerNameText").GetComponent<Text>();
	}

	// Start is called before the first frame update
	void Start()
    {
		if (isLocalPlayer)
		{
			// プレイヤーオブジェクトは、生成された瞬間はInitializingという非表示状態である。
			// クライアントで生成されたら、それをサーバーへ通知し、
			// 状態がReadyとなる。
			// （同時にプレイヤー名も送信する）
			CmdInitialize(s_LocalPlayerName);
		}

		// 各種表示の初期化
		OnPlayerNameChanged(m_PlayerName);
		OnStateChanged(m_State);
	}
	//クライアントからサーバへ
	[Command]
	void CmdInitialize(string playerName)
	{
		ChangeState(State.Ready);
		ChangePlayerName(playerName);
	}

	// プレイヤー名変更のhook
	void OnPlayerNameChanged(string name)
	{
		m_PlayerName = name;

		m_PlayerNameText.text = m_PlayerName;
	}

	// 状態変更のhook
	void OnStateChanged(State state)
	{
		m_State = state;

		// 状態に応じて、各表示を切り替える
		switch (m_State)
		{
			case State.Initializing:
				//m_PlayerNameText.enabled = false; // プレイヤー名非表示
				break;
			case State.Connect:
				break;
			default:
				Debug.LogError("想定外のstate:" + m_State);
				break;
		}

	}

	//Idが変更されたときのhook
	void OnIdChanged(Id id)
	{
		m_Id = id;

		//選ばれた画像を表示する
		switch (m_Id)
		{
			case Id.None:
				break;
			case Id.B:
				//ベルゼの表示プログラム（場のカードにImageを貼り付けで）
				break;
			case Id.A:
				break;
			default:
				Debug.LogError("想定外のId:" + m_Id);
				break;
		}
	}

	// 状態を変更する
	[Server]
	public void ChangeState(State state)
	{
		// m_Stateを変更すれば、あとはhookによりOnStateChangedが実行される
		m_State = state;
	}

	// プレイヤー名を変更する
	[Server]
	void ChangePlayerName(string name)
	{
		// m_PlayerNameを変更すれば、あとはhookによりOnPlayerNameChangedが実行される
		m_PlayerName = name;
	}

	// キーの入力をサーバーへ通知する
	[Command]
	public void CmdInput(Id id)
	{
		//m_Idを変更すれば、あとはhookによりOnIdChangeが実行
		m_Id = id;
	}

	private void Update()
	{
		Debug.Log(m_State);
	}
}
