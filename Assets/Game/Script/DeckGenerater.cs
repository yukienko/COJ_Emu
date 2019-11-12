/*

Cardより受け取った情報をもとにカードの生成を行い、デッキに追加する。

 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * デッキを生成するためのスクリプト
 * 初回読み込み以外使わないと思う。
 * カードの複製などの生成はCardGenerater
 */

public class DeckGenerater : MonoBehaviour
{
	public GameObject cardPrefab;
	Sprite sprite;
	string cardImagePath;
	private const int sameCardLimit = 3;
	private const int deckCardLimit = 40;

	public void Generate(CardData _cardDataList, Deck _deck)
	{
		//カードのもとを生成してここからプレイヤーが判別できるように情報を加えていく
		GameObject cardObj = Instantiate(cardPrefab);
		cardObj.name = _cardDataList.name;
		GameObject cardImage = cardObj.transform.Find("Image").gameObject;

		Debug.Log(_cardDataList.section);
		switch (_cardDataList.section)
		{
			//ユニット
			case 1:
				Debug.Log("UnitCard_ImageLoad");
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

		//テクスチャにフォルダから読み込んだ画像を張る
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

		Card card = cardObj.GetComponent<Card>();
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