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
	//カード上に表示するUI用
	public Text levelText;
	public Text CPText;
	public Text BPText;
	public GameObject Attack_B;
	public GameObject Tettai_B;
	public GameObject ForUnActionImage_GO;

	//カード情報
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

	//
	DeckGenerater deckgenerater;
	Player player_c;
	Player player_j;


	private void Start()
	{
		deckgenerater = GameObject.Find("GameMaster").GetComponent<DeckGenerater>();
		player_c = GameObject.Find("Card1").GetComponent<Player>();
		player_j = GameObject.Find("Joker1").GetComponent<Player>();
	}

	//カードをDeckGenerater_DEを使ってデッキに追加する。
	public void DeckLoad()
	{
		CardData cardDataList = new CardData(id, name, section, cp, color, race[0], race[1], bp[0], bp[1], bp[2], effectText, flavorText);
		Debug.Log("Load:Card_" + cardDataList.name);
		deckgenerater.Generate(cardDataList, player_c.deck_);
	}

	//フィールドにいるときにクリックされたら攻撃、撤退ボタンを表示する。インフォメーションもここから呼び出しましょう
	public void ActiveButton()
	{
		//左クリック
		if (Input.GetMouseButtonDown(0))
		{
			Attack_B.SetActive(true);
			Tettai_B.SetActive(true);
			ForUnActionImage_GO.SetActive(true);
		}
		//右クリック
		else if (Input.GetMouseButtonDown(1))
		{

		}
	}

	//ボタンの非表示
	public void UnActiveButton()
	{
		Attack_B.SetActive(false);
		Tettai_B.SetActive(false);
		ForUnActionImage_GO.SetActive(false);
	}

	public void Select()
	{
		ActiveButton();
	}

	public void UnSelect()
	{
		UnActiveButton();
	}

	//攻撃ボタンが押された
	public void Attack()
	{
		Debug.Log("攻撃");
	}

	//撤退ボタンが押された
	public void Tettai()
	{
		Debug.Log("撤退");
	}

	//DeckGeneraterの中でしか起こらないのでレベルに対応したBp変化はいらない
	public void Load(CardData _cardData)
	{
		id = _cardData.id;
		name = _cardData.name;
		section = _cardData.section;
		cp = _cardData.cp;
		CPText.text = cp.ToString();
		color = _cardData.color;
		race[0] = _cardData.race1;
		race[1] = _cardData.race2;
		bp[0] = _cardData.bp1;
		bp[1] = _cardData.bp2;
		bp[2] = _cardData.bp3;
		BPText.text = bp[0].ToString();
		//カードがトリガー、インターセプトならBPは必要ないのでハイフン表示にする
		if (_cardData.section == 3 || _cardData.section == 4)
			BPText.text = "-";
	}
}