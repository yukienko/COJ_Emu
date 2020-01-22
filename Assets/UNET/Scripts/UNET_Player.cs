using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UNET_Player : NetworkBehaviour
{
	// 移動速度（m/s）
	[SerializeField] float m_WalkSpeed = 4.0f;

	CharacterController m_CharacterController;

	void Start()
	{
		m_CharacterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		var axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		// ローカルプレイヤー（つまり自分のキャラクター）の場合のみ
		// 移動処理を実施する。
		if (isLocalPlayer)
		{
			// 移動量を求める
			Vector3 motion = axis * m_WalkSpeed;
			// Commandにより、移動の依頼をサーバーに発行
			m_CharacterController.Move(motion);
		}
	}

	//// 移動処理。これはサーバーで実行される
	//[Command]
	//void CmdMove(Vector3 motion)
	//{
	//	//print("CmdMove, netId=" + netId + ", motion=" + motion); // 仮。とりあえずログで確認

	//	m_CharacterController.Move(motion);
	//}
}
