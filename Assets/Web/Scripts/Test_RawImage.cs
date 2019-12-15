using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Test_RawImage : MonoBehaviour
{
	//画像リンクから画像をテクスチャにする
	Texture texture;
	//画像リンク
	string url = "https://touhoucannonball.com/assets/img/character/img_008.jpg";

	void Start()
	{
		StartCoroutine(Connect());
	}

	//テクスチャを読み込む
	private IEnumerator Connect()
	{
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.Log(www.error);
		}
		else
		{
			//textureに画像格納
			texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			//そのまま貼り付け
			gameObject.GetComponent<RawImage>().texture = texture;
		}
	}
}
