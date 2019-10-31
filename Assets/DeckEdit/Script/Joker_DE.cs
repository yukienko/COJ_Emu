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
	public List<Transform> objList;
	public GameObject content_Card; 
	public GameObject selectDeck;
	public GameObject selectDeckView;
	public Text deckName;
	public Text selectDeckName;
	public string[,] textMessage;
	private const int deckCardLimit = 40;


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

	public void DeckSave()
	{
		//デッキ枚数が40枚か
		if (jokerList.Count == deckCardLimit)
		{
			//DeckSort();
			string deckFilePath = Environment.CurrentDirectory + "\\deckFile";
			if (!Directory.Exists(deckFilePath))
			{
				Directory.CreateDirectory(deckFilePath);
			}
			deckFilePath = deckFilePath + "\\" + deckName.text + ".txt";
			//var info = "DeckName:" + deckName.text;
			//File.WriteAllText(deckFilePath, info + "\n");
			for (int i = 0; i < jokerList.Count; i++)
			{
				var stream = jokerList[i].name.ToString() + "\n";
				File.AppendAllText(deckFilePath, stream);
			}
		}
		Debug.Log("SaveOK");
	}

	public void DeckSort()
	{
		IOrderedEnumerable<Card_DE> sortList = jokerList.OrderBy(b => b.section).ThenBy(a => a.id);
		var count = jokerList.Count;
		Debug.Log(sortList.Count());
		foreach (Card_DE card in sortList)
		{
			jokerList.Add(card);
		}
		jokerList.RemoveRange(0, count);

		objList = jokerList.ConvertAll(x => x.transform.GetComponentInChildren<Transform>());

		foreach (var obj in objList)
		{
			obj.SetSiblingIndex(jokerList.Count - 1);
		}
	}

	public void DeckLoad()
	{
		//残っているカードを「全削除
		jokerList.Clear();
		foreach (Transform t in gameObject.transform)
		{
			GameObject.Destroy(t.gameObject);
		}

		string deckFilePath = Environment.CurrentDirectory + "\\deckFile";
		//選んだデッキの名前はここに
		string deckname = selectDeckName.text;
		deckFilePath = deckFilePath + "\\" + deckname + ".txt";
		if (!File.Exists(deckFilePath))
		{
			Debug.Log("error" + deckFilePath);
			return;
		}
		string[] deckList = File.ReadAllLines(deckFilePath);
		//cardsChildrenにカードリストからカードをすべて取得
		foreach (Transform card in content_Card.transform.GetComponentInChildren<Transform>())
		{
			cardsChildren.Add(card);
		}
		foreach (string s in deckList)
		{
			FromNameCardLoad(s);
		}
	}

	void FromNameCardLoad(string s)
	{
		for (int i = 0; i < content_Card.transform.childCount; i++)
		{
			if (s == cardsChildren[i].GetComponent<Card_DE>().name)
			{
				cardsChildren[i].GetComponent<Card_DE>().DeckLoad();
				break;
			}
		}
	}

}