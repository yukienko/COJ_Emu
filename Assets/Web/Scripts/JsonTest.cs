using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;

public class JsonTest : MonoBehaviour
{
	public UserData userData = new UserData();
	public string url = "https://unity-api-falcon.herokuapp.com/api/users";

	private void Start()
	{
		StartCoroutine(Method());
	}

	//IEnumeratorを使うのは通信に関してはコルーチンを用いなければならないため
	private IEnumerator Method()
	{
		//UnityWebRequestを生成
		UnityWebRequest request = UnityWebRequest.Get(url);

		//SendWebRequestを実行、送受信開始
		yield return request.SendWebRequest();

		//isNetworkErrorとisHttpErrorでエラー判定
		if (request.isHttpError || request.isNetworkError)
		{
			Debug.Log(request.error);
		}
		else
		{
			//結果実行
			Debug.Log(request.downloadHandler.text);
		}
	}
}
