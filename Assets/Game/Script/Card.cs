/*

CardDataから送られてきた情報をもとにカードの生成を行う。
生成されたカードはDeckGeneraterにてデッキに生成される。

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text levelText;
    public Text CPText;
    public Text BPText;
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
	DeckGenerater deckgenerater;
	Player player_c;
	Player player_j;


	private void Start()
	{
		deckgenerater = GameObject.Find("Deck").GetComponent<DeckGenerater>();
		player_c = GameObject.Find("Content_Cards").GetComponent<Player>();
		player_j = GameObject.Find("Content_Jokers").GetComponent<Player>();
	}

	//カードをDeckGenerater_DEを使ってデッキに追加する。
	public void DeckLoad()
	{
		CardData cardDataList = new CardData(id, name, section, cp, color, race[0], race[1], bp[0], bp[1], bp[2], effectText, flavorText);
		//右クリックでデッキに追加
		Debug.Log("Load:Card_" + cardDataList.name);
		deckgenerater.Generate(cardDataList, player_c.deck_);
	}

	//DeckGeneraterの中でしか起こらないのでレベルに対応したBp変化はいらない
	public void Load(CardData _cardData)
    {
        id = _cardData.id;
        name = _cardData.name;
        cp = _cardData.cp;
        CPText.text = cp.ToString();
        color = _cardData.color;
        race[0] = _cardData.race1;
        race[1] = _cardData.race2;
        bp[0] = _cardData.bp1;
        bp[1] = _cardData.bp2;
        bp[2] = _cardData.bp3;
        BPText.text = bp[0].ToString();
    }
}