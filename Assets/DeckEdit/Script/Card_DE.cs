using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card_DE : MonoBehaviour
{
	public int id;
	public new string name;
	public int section;
	public int cp;
	public int color;
	public int[] race = new int[2];
	public int[] bp = new int[3];
	public string effectText;
	public string flavorText;
	public int useGauge;
	Infomation_DE infomation_DE;
	DeckGenerater_DE deckgenerater_DE;
	Player_DE player_;

	private void Start()
	{
		infomation_DE = GameObject.Find("Infomation").GetComponent<Infomation_DE>();
		deckgenerater_DE = GameObject.Find("Deck").GetComponent<DeckGenerater_DE>();
		player_ = GameObject.Find("Content_Cards").GetComponent<Player_DE>();
	}

	public void DeckLoad()
	{
		CardData_DE cardDataList = new CardData_DE(id, name, section, cp, color, race[0], race[1], bp[0], bp[1], bp[2], effectText, flavorText);
		//右クリックでデッキに追加
		Debug.Log("Add");
		deckgenerater_DE.Generate(cardDataList, player_.deck_);
	}

	public void MyPointerDownUI()
	{
		if (section == 0)
		{
			JokerData_DE jokerDataList = new JokerData_DE(id, name, section, cp, effectText, useGauge);
			if (Input.GetMouseButtonDown(1))
			{
				//左クリックで説明表示
				Debug.Log("Infomation");
				infomation_DE.LoadInfo_Joker(jokerDataList);
			}
			else if (Input.GetMouseButtonDown(0))
			{
				//親がContents_Deckなら追加,Contents_Cardなら削除とする
				if (transform.parent.name == "Content_Jokers")
				{
					//右クリックでデッキに追加
					Debug.Log("Add");
					deckgenerater_DE.JokerGenerate(jokerDataList, player_.deck_);
				}
				else
				{
					//右クリックでデッキから削除
					Debug.Log("Del");
					deckgenerater_DE.DeleteJoker(jokerDataList, player_.deck_, transform);
					GameObject.Destroy(gameObject);
				}
			}
		}
		else
		{
			CardData_DE cardDataList = new CardData_DE(id, name, section, cp, color, race[0], race[1], bp[0], bp[1], bp[2], effectText, flavorText);
			if (Input.GetMouseButtonDown(1))
			{
				//左クリックで説明表示
				Debug.Log("Infomation");
				infomation_DE.LoadInfo(cardDataList);
			}
			else if (Input.GetMouseButtonDown(0))
			{
				//親がContents_Deckなら追加,Contents_Cardなら削除とする
				if (transform.parent.name == "Content_Cards")
				{
					//右クリックでデッキに追加
					Debug.Log("Add");
					deckgenerater_DE.Generate(cardDataList, player_.deck_);
				}
				else
				{
					//右クリックでデッキから削除
					Debug.Log("Del");
					deckgenerater_DE.Delete(cardDataList, player_.deck_, transform);
					GameObject.Destroy(gameObject);
				}
			}
		}
	}

	//DeckGeneraterの中でしか起こらないのでレベルに対応したBp変化はいらない
	public void Load(CardData_DE _cardData)
	{
		id = _cardData.id;
		name = _cardData.name;
		section = _cardData.section;
		cp = _cardData.cp;
		color = _cardData.color;
		race[0] = _cardData.race1;
		race[1] = _cardData.race2;
		bp[0] = _cardData.bp1;
		bp[1] = _cardData.bp2;
		bp[2] = _cardData.bp3;
		effectText = _cardData.effectText;
		flavorText = _cardData.flavorText;
	}

	public void LoadJoker(JokerData_DE _cardData)
	{
		id = _cardData.id;
		name = _cardData.name;
		cp = _cardData.cp;
		effectText = _cardData.effectText;
		useGauge = _cardData.useGauge;
	}

}
