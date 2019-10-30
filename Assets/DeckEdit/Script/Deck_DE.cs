using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine.UI;

public class Deck_DE : MonoBehaviour
{
	public List<Card_DE> cardList = new List<Card_DE>();
	public List<Card_DE> jokerList = new List<Card_DE>();
	public List<Transform> cardsChildren = new List<Transform>();
	public List<Transform> objList;
	public GameObject savePanel;
	public GameObject loadPanel;
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
		cardList.Add(_card);
	}

	public Card_DE Pull(int _position)
	{
		Card_DE card = cardList[_position];
		cardList.Remove(card);
		return card;
	}

	public void DeckSavePanel_Active()
	{
		deckName.text = "";
		savePanel.gameObject.SetActive(true);
	}

	public void DeckSavePanel_UnActive()
	{
		savePanel.gameObject.SetActive(false);
	}

	public void DeckSave()
	{
		//デッキ枚数が40枚か
		if (cardList.Count == deckCardLimit)
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
			for (int i = 0; i < cardList.Count; i++)
			{
				var stream = cardList[i].name.ToString() + "\n";
				File.AppendAllText(deckFilePath, stream);
			}
		}
		Debug.Log("SaveOK");
		DeckSavePanel_UnActive();
	}

	public void DeckSort()
	{
		IOrderedEnumerable<Card_DE> sortList = cardList.OrderBy(b => b.section).ThenBy(a => a.id);
		var count = cardList.Count;
		Debug.Log(sortList.Count());
		foreach(Card_DE card in sortList)
		{
			cardList.Add(card);
		}
		cardList.RemoveRange(0, count);

		objList = cardList.ConvertAll(x => x.transform.GetComponentInChildren<Transform>());

		foreach (var obj in objList)
		{
			obj.SetSiblingIndex(cardList.Count - 1);
		}
	}

	public void DeckLoad()
	{
		//残っているカードを「全削除
		cardList.Clear();
		foreach(Transform t in gameObject.transform)
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
		DeckLoadPanel_UnActive();
	}

	void FromNameCardLoad(string s)
	{
		for (int i = 0; i < content_Card.transform.childCount; i++)
		{
			if(s == cardsChildren[i].GetComponent<Card_DE>().name)
			{
				cardsChildren[i].GetComponent<Card_DE>().DeckLoad();
				break;
			}
		}
	}

	public void DeckLoadPanel_Active()
	{
		loadPanel.gameObject.SetActive(true);
	}

	public void DeckLoadPanel_UnActive()
	{
		loadPanel.gameObject.SetActive(false);
	}

	private void Start()
	{
		savePanel.SetActive(false);
		loadPanel.SetActive(false);
		//Loadするデッキをパネルに設置する。
		string deckFilePath = Environment.CurrentDirectory + "\\deckFile";
		string[] hoge = Directory.GetFiles(deckFilePath);

		for (int i = 0; i < hoge.Count(); i++)
		{
			hoge[i] = Path.GetFileNameWithoutExtension(hoge[i]);
			GameObject list = Instantiate(selectDeck);
			list.transform.SetParent(selectDeckView.transform, false);
			Text text = list.transform.GetComponentInChildren<Text>();
			text.text = hoge[i];
		}
	}
}
