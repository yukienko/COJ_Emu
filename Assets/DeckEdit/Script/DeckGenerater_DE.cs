using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using System;

public class DeckGenerater_DE : MonoBehaviour
{
	public GameObject cardPrefab;
	Sprite sprite;
	string cardImagePath;
	int same = 0;
	private const int sameCardLimit = 3;
	private const int deckCardLimit = 40;

	public void Generate(CardData_DE _cardDataList, Deck_DE _deck)
	{
		if(_deck.cardList.Count >= deckCardLimit)
		{
			Debug.Log("デッキは40枚にしてください");
			return;
		}
		same = 0;
		for(int i = 0; i< _deck.cardList.Count; i++)
		{
			if(_deck.cardList[i].id == _cardDataList.id)
				same++;
		}
		if (same >= sameCardLimit)
		{
			Debug.Log("同じカードは3枚までです");
			return;
		}
		

		GameObject cardObj = Instantiate(cardPrefab);
		cardObj.name = _cardDataList.name;
		GameObject cardImage = cardObj.transform.Find("Image").gameObject;

		switch (_cardDataList.section)
		{
			//ジョーカー
			case 0:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\jokers\\joker (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//ユニット
			case 1:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\units\\unit (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//進化
			case 2:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\units\\unit (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//トリガー
			case 3:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\triggers\\trigger (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//インターセプト
			case 4:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\intercepts\\intercept (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//ウイルス
			case 5:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\viruses\\viruse (" + _cardDataList.id.ToString() + ").jpg";
				//Debug.Log(cardImagePath);
				break;
			//カエル
			case 6:
				cardImagePath = Environment.CurrentDirectory + "\\cardImage\\kaeru\\kaeru.jpg";
				//Debug.Log(cardImagePath);
				break;
		}

		Texture Card_texture = cardImage.GetComponent<Texture>();
		if (!File.Exists(cardImagePath))
		{
			Debug.Log("error");
		}
		else
		{
			Card_texture = ReadTexture(cardImagePath, 93, 140);
		}
		// テクスチャーを適用
		cardImage.GetComponent<Renderer>().material.mainTexture = Card_texture;
		// 下地の色は白にしておく (そうしないと下地の色と乗算みたいになる)
		cardImage.GetComponent<Renderer>().material.color = Color.white;

		Card_DE card = cardObj.GetComponent<Card_DE>();
		card.Load(_cardDataList);
		_deck.Add(card);
	}

	public void Delete(CardData_DE _cardDataList, Deck_DE _deck, Transform transform)
	{
		int childcount = 0;
		foreach(Transform obj in _deck.transform.GetComponentInChildren<Transform>())
		{
			if(transform == obj.transform)
			{
				_deck.Pull(childcount);
				return;
			}
			childcount++;
		}
	}


	//フォルダ内のJPGを読み込む
	Texture ReadTexture(string path, int width, int height)
	{
		byte[] readBinary = ReadJpgFile(path);

		Texture2D texture = new Texture2D(width, height);
		texture.LoadImage(readBinary);

		return texture;
	}

	byte[] ReadJpgFile(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader bin = new BinaryReader(fileStream);
		byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

		bin.Close();

		return values;
	}



	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
