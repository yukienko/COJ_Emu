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


		//読み込むデッキのPath
		string deckFilePath = Environment.CurrentDirectory + "\\deckFile\\" + deckName;

		//読み込むカードのPath
		var cardPath = deckFilePath + "\\card.txt";

		//読み込む予定のPathが存在しない場合はエラーを返す
		if (!File.Exists(cardPath))
		{
			Debug.Log("error:" + cardPath + "が存在しません");
			return;
		}

		Debug.Log("Load開始");
		
		//Deckの中のカードを1行1行読んでる(デッキの枚数文の配列となる)
		string[] deckList = File.ReadAllLines(cardPath);

		//cardsChildrenにカードリストからカードをすべて取得（いったんすべてのカードを取得しておく：生成しやすくするため）
		foreach (Transform card in content_Card.transform.GetComponentInChildren<Transform>())
		{
			cardsChildren.Add(card);
		}

		//deckListの名前をFromNameCardLoadで検索して見つけたらその情報を生成するカードにコピー
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
				Debug.Log("hoge");
				cardsChildren[i].GetComponent<Card>().DeckLoad();
				break;
			}
		}
	}
}