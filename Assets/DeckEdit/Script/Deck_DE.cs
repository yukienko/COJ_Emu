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
	public List<Transform> objList;
	public GameObject savePanel;
	public Text deckName;
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
			DeckSort();
			string deckFilePath = Environment.CurrentDirectory + "\\deckFile";
			if (!Directory.Exists(deckFilePath))
			{
				Directory.CreateDirectory(deckFilePath);	
			}
			deckFilePath = deckFilePath + "\\" + deckName.text + ".txt";
			var info = "DeckName:" + deckName.text;
			File.WriteAllText(deckFilePath, info + "\n");
			for (int i = 0; i < cardList.Count; i++)
			{
				var stream = cardList[i].id.ToString() + "," + cardList[i].section.ToString() + "\n";
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

	private void Start()
	{
		savePanel.SetActive(false);	
	}
}
