using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardGenerater_DE : MonoBehaviour
{
	public GameObject cardPrefab;
	Sprite sprite;
	string cardImagePath;

	public void Generate(CardData_DE _cardDataList, CardList_DE cardList_DE)
	{

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
			cardList_DE.Add(card);
		}

	public void GenerateJoker(JokerData_DE _cardDataList, JokerList_DE jokerList_DE)
	{

		GameObject cardObj = Instantiate(cardPrefab);
		cardObj.name = _cardDataList.name;
		GameObject cardImage = cardObj.transform.Find("Image").gameObject;

		cardImagePath = Environment.CurrentDirectory + "\\cardImage\\jokers\\joker (" + _cardDataList.id.ToString() + ").jpg";

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
		card.LoadJoker(_cardDataList);
		jokerList_DE.Add(card);
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
}


