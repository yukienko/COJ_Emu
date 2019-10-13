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

	public void Generate(CardData_DE _cardDataList, Deck_DE _deck)
	{

			GameObject cardObj = Instantiate(cardPrefab);
			cardObj.name = _cardDataList.name;
			GameObject cardImage = cardObj.transform.Find("Image").gameObject;
			cardImagePath = Environment.CurrentDirectory + "\\cardImage\\units\\unit (" + _cardDataList.id.ToString() + ").jpg";
			Debug.Log(cardImagePath);

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


