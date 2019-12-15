using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Test_Image : MonoBehaviour
{
	//imageはスプライトを使って描画しているので
	Sprite sprite;
	//画像リンクから画像をテクスチャにする
	Texture2D texture;
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
			//textureからspriteに変換
			sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.zero);
			//Imageにspriteを張り付ける
			gameObject.GetComponent<Image>().sprite = sprite;
		}
	}
}
