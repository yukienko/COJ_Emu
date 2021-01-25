using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Joker_DE : MonoBehaviour
{
	public List<Card_DE> jokerList = new List<Card_DE>();
	public List<Transform> cardsChildren = new List<Transform>();
	public GameObject content_Joker; 
	private const int deckjokerLimit = 2;


	public void Add(Card_DE _card)
	{
		//GameObject deck = this.transform.Find("Content_Deck").gameObject;
		_card.transform.SetParent(transform, false);
		jokerList.Add(_card);
	}

	public Card_DE Pull(int _position)
	{
		Card_DE card = jokerList[_position];
		jokerList.Remove(card);
		return card;
	}

	public bool JokerSave(string deckFilePath)
	{
		//ジョーカーが2枚か
		if (jokerList.Count == deckjokerLimit)
		{
			var deckFileJokerPath = deckFilePath + "\\joker.txt";

			//deckFileがなければ作りましょう
			if (!Directory.Exists(deckFilePath))
			{
				Directory.CreateDirectory(deckFilePath);
			}

			//一回全部消す
			File.Delete(deckFileJokerPath);

			for (int i = 0; i < jokerList.Count; i++)
			{
				var stream = jokerList[i].name.ToString() + "\n";
				File.AppendAllText(deckFileJokerPath, stream);
			}

			Debug.Log("JokerSaveOK");
			return true;
		}
		//ジョーカーが規定枚数に達していないのでエラーを返す
		else
		{
			Debug.Log("error:ジョーカーが2枚未満");
			return false;
		}
	}

	public void JokerLoad(string deckFilePath)
	{
		//残っているカードを「全削除
		jokerList.Clear();
		foreach (Transform t in gameObject.transform)
		{
			GameObject.Destroy(t.gameObject);
		}

		var jokerPath = deckFilePath + "\\joker.txt";
		string[] deckList = File.ReadAllLines(jokerPath);
		//cardsChildrenにカードリストからカードをすべて取得
		foreach (Transform card in content_Joker.transform.GetComponentInChildren<Transform>())
		{
			cardsChildren.Add(card);
		}
		foreach (string s in deckList)
		{
			FromNameJokerLoad(s);
		}
		Debug.Log("JokerLoadOK");
	}

	void FromNameJokerLoad(string s)
	{
		for (int i = 0; i < content_Joker.transform.childCount; i++)
		{
			if (s == cardsChildren[i].GetComponent<Card_DE>().name)
			{
				cardsChildren[i].GetComponent<Card_DE>().DeckLoad_Joker();
				break;
			}
		}
	}

}