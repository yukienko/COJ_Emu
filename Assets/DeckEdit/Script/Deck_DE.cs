using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections.ObjectModel;


public class Deck_DE : MonoBehaviour
{
	public List<Card_DE> cardList = new List<Card_DE>();
	public List<Transform> objList;

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

	public void Sort()
	{
		//CardListのみだがカードid順にソート
		//cardList.Sort((a, b) => a.section - b.section);
		//cardList.Sort((a, b) => a.id - b.id);
		//cardList.Sort((a, b) => a.id - b.id);
		//cardList.Sort((a, b) => a.id - b.id);	

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
}
