using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();
	public List<Transform> cardsChildren = new List<Transform>();
	public GameObject content_Card;





	public void Add(Card _card)
    {
        _card.transform.SetParent(this.transform,false);
        cardList.Add(_card);
    }
    public Card Pull(int _position)
    {
        Card card = cardList[_position];
        cardList.Remove(card);
        return card;
    }

	//デッキのロード
	public void DeckLoad()
	{
		////残っているカードを「全削除
		//cardList.Clear();
		//foreach (Transform t in gameObject.transform)
		//{
		//	GameObject.Destroy(t.gameObject);
		//}


		//ここで読み込むデッキを変更できるように
		string deckName = "完成";
		string deckFilePath = Environment.CurrentDirectory + "\\deckFile\\" + deckName;

		var cardPath = deckFilePath + "\\card.txt";
		if (!File.Exists(cardPath))
		{
			Debug.Log("error:" + cardPath + "が存在しません");
			return;
		}
		string[] deckList = File.ReadAllLines(cardPath);

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

	//DeckFileのカード名からカードリストと同じ名前のカードを探してその情報をロードする
	void FromNameCardLoad(string s)
	{
		for (int i = 0; i < content_Card.transform.childCount; i++)
		{
			if (s == cardsChildren[i].GetComponent<Card>().name)
			{
				cardsChildren[i].GetComponent<Card>().DeckLoad();
				break;
			}
		}
	}
}