using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();

    public void Add(Card _card)
    {
        _card.transform.SetParent(this.transform);
        cardList.Add(_card);
    }
    public Card Pull(int _position)
    {
        Card card = cardList[_position];
        cardList.Remove(card);
        return card;
    }
}