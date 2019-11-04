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
	Joker_DE joker_;
	public List<Card_DE> cardList = new List<Card_DE>();
	public List<Transform> cardsChildren = new List<Transform>();
	public List<Transform> objList;
	public GameObject savePanel;
	public GameObject loadPanel;
	public GameObject content_Card;
	public GameObject selectDeck;
	public GameObject selectDeckView;
	public Text deckName;
	public Text selectDeckName;
	private const int deckCardLimit = 40;

	//デッキにカードを追加する
	public void Add(Card_DE _card)
	{
		//GameObject deck = this.transform.Find("Content_Deck").gameObject;
		_card.transform.SetParent(transform, false);
		cardList.Add(_card);
	}

	//デッキからカードを抜く
	public Card_DE Pull(int _position)
	{
		Card_DE card = cardList[_position];
		cardList.Remove(card);
		return card;
	}

	//セーブパネルの表示
	public void DeckSavePanel_Active()
	{
		deckName.text = "";
		savePanel.gameObject.SetActive(true);
	}

	//セーブパネルの非表示
	public void DeckSavePanel_UnActive()
	{
		savePanel.gameObject.SetActive(false);
	}

	//デッキのセーブ
	public void DeckSave()
	{
		//デッキ枚数が40枚か
		if (cardList.Count == deckCardLimit)
		{
			//deckFilePathの作製
			string deckFilePath = Environment.CurrentDirectory + "\\deckFile\\" + deckName.text;

			//ジョーカーのセーブ
			if (!joker_.JokerSave(deckFilePath))
			{
				//ジョーカーが2枚未満
				return;
			}

			//ここはDeck_DEなのでデッキのパスから
			var deckFileCardPath = deckFilePath + "\\card.txt";

			//上書きするので前のデッキデータ(card)を消しますよ
			File.Delete(deckFileCardPath);

			for (int i = 0; i < cardList.Count; i++)
			{
				var stream = cardList[i].name.ToString() + "\n";
				File.AppendAllText(deckFileCardPath, stream);
			}
		}
		else
		{
			Debug.Log("error:デッキを40枚にしてください。");
			return;
		}

		Debug.Log("SaveAllOK");
		DeckSavePanel_UnActive();
	}

	//デッキソート
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

	//デッキロード
	public void DeckLoad()
	{
		//カードのロード
		//残っているカードを「全削除
		cardList.Clear();
		foreach(Transform t in gameObject.transform)
		{
			GameObject.Destroy(t.gameObject);
		}

		//選んだデッキの名前はここに
		string deckname = selectDeckName.text;
		string deckFilePath = Environment.CurrentDirectory + "\\deckFile\\" + deckname;
		
		var cardPath = deckFilePath + "\\card.txt";
		if (!File.Exists(cardPath))
		{
			Debug.Log("error" + cardPath);
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
		Debug.Log("CardLoadOK");
		joker_.JokerLoad(deckFilePath);
		Debug.Log("LoadAllOK");
		DeckLoadPanel_UnActive();
	}

	//DeckFileのカード名からゲーム画面右のカードリストから同じ名前のカードを探してその情報をロードする
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

	//ロードパネル表示
	public void DeckLoadPanel_Active()
	{
		loadPanel.gameObject.SetActive(true);
	}

	//ロードパネル非表示
	public void DeckLoadPanel_UnActive()
	{
		loadPanel.gameObject.SetActive(false);
	}

	private void Start()
	{
		joker_ = GameObject.Find("Content_Joker").GetComponent<Joker_DE>();
		savePanel.SetActive(false);
		loadPanel.SetActive(false);
		//Loadするデッキをパネルに設置する。
		string deckFilePath = Environment.CurrentDirectory + "\\deckFile";
		string[] hoge = Directory.GetDirectories(deckFilePath);

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
