using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerList_DE : MonoBehaviour
{
	public List<Card_DE> jokerList = new List<Card_DE>();

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
}
