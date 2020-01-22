using UnityEngine;
using UnityEngine.UI;

// タイトル画面のプレイヤー名入力欄を管理する
public class PlayerNameInputField : MonoBehaviour
{
	void Start()
	{
		InputField inputField = GetComponent<InputField>();

		// 初期値設定
		inputField.text = Test_Player.s_LocalPlayerName;

		// 編集完了時の処理を登録
		inputField.onEndEdit.AddListener(newValue => { Test_Player.s_LocalPlayerName = newValue; });
	}
}