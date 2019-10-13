using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck_DE : MonoBehaviour
{
	public List<Card_DE> cardList = new List<Card_DE>();

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
}
