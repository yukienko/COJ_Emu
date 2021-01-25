using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionTest : MonoBehaviour
{
	string url = "https://touhoucannonball.com/assets/img/character/img_008.jpg";
	[SerializeField] private RawImage _image;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine (Connect ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private IEnumerator Connect()
	{
		//var www = new WWW(url);
		UnityWebRequest www_ = UnityWebRequestTexture.GetTexture(url);

		yield return www_.SendWebRequest();

		if (www_.isNetworkError || www_.isHttpError)
		{
			Debug.Log(www_.error);
		}
		else
		{
			//テクスチャを張り付ける
			_image.texture = ((DownloadHandlerTexture)www_.downloadHandler).texture;
		}
	}
}
