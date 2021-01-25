using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UNET3_Player : NetworkBehaviour
{
	[SyncVar(hook = "HookCountChanged")]
	int m_Count = 0;

	TextMesh m_CountText;
    // Start is called before the first frame update
    void Start()
    {
		//自分の子からTextMeshコンポーネントを取得する
		m_CountText = GetComponentInChildren<TextMesh>();

		//テキストを更新する
		m_CountText.text = m_Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		//ローカルプレイヤーのみ（他人のプレイヤーでは、やらない）
		if (isLocalPlayer)
		{
			//スペースキー押下でカウントアップ
			if (Input.GetKeyDown(KeyCode.Space))
			{
				CmdCountUp();
			}
		}

		//テキストを更新する
		//m_CountText.text = m_Count.ToString();
    }

	//カウントアップ処理はサーバで行う
	[Command]
	void CmdCountUp()
	{
		m_Count++;
	}

	//m_Countが同期されたときに呼ばれる
	void HookCountChanged(int newValue)
	{
		m_Count = newValue;

		//テキストを更新する
		m_CountText.text = m_Count.ToString();
	}
}
