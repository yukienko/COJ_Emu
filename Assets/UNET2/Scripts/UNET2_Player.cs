using UnityEngine;
using UnityEngine.Networking; // NetworkBehaviourを使うのに必要
using UnityEngine.UI; // UGUIを使うのに必要

public class UNET2_Player : NetworkBehaviour // ←NetworkBehaviourを継承する
{
	// チャットのメッセージ履歴を表示するText
	Text m_ChatHistory;
	// メッセージの入力欄
	InputField m_ChatInputField;

	void Start()
	{
		// メッセージ履歴を表示するTextを検索して取得
		m_ChatHistory = GameObject.Find("ChatHistory").GetComponent<Text>();
	}

	// ローカルプレイヤーが初期化される際に呼ばれる。
	public override void OnStartLocalPlayer()
	{
		// メッセージ入力欄のInputFieldを検索して取得
		m_ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
	}

	void Update()
	{
		// 他人のプレイヤーに対しては何も行わない
		if (!isLocalPlayer)
			return;

		// Enterキーが押されて
		if (Input.GetKeyDown(KeyCode.Return))
		{
			// 文字列が入力されていたら
			if (m_ChatInputField.text.Length > 0)
			{
				// Commandを使って入力された文字列をサーバーへ送信
				CmdPost(m_ChatInputField.text);

				// 入力欄を空にする
				m_ChatInputField.text = "";
			}
		}
	}

	// 文字列をサーバーに送信する。
	[Command]
	void CmdPost(string text)
	{
		RpcPost(text);
	}

	// ClientRpcは各クライアントで実行される。
	// チャット履歴表示欄に文字列を追加する。
	[ClientRpc]
	void RpcPost(string text)
	{
		m_ChatHistory.text += text + System.Environment.NewLine;
	}
}