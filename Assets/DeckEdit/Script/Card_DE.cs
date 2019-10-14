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
	public Infomation_DE infomation_DE;
	public Deck_DE deck_DE;

	private void Start()
	{
		infomation_DE = GameObject.Find("Infomation").GetComponent<Infomation_DE>();
		deck_DE = transform.parent.gameObject.GetComponent<Deck_DE>();
	}

	public void MyPointerDownUI()
	{

		CardData_DE cardDataList = new CardData_DE(id, name, section, cp, color, race[0], race[1], bp[0], bp[1], bp[2], effectText, flavorText);
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("Infomation");
			//Qキーを押したままだと説明を表示
			infomation_DE.LoadInfo(cardDataList);
		}
		else if(Input.GetMouseButtonDown(0))
		{
			Debug.Log("Add");
			//何も押さないとデッキにカード追加として扱う
			//deck_DE.Add(cardDataList);
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
}
