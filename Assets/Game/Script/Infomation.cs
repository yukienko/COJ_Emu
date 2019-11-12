using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * カードをクリックしたときにカード情報パネルにてユーザーに視的に情報を伝える
 */

public class Infomation : MonoBehaviour
{
	//インフォのとこのやつら
	public new Text name;
	public Text section;
	public Text race1;
	public Text race2;
	public Text cp;
	public GameObject ColorImage;
	public Text effect;
	public Text bp1;
	public Text bp2;
	public Text bp3;
	public GameObject lv1;
	public GameObject lv2;
	public GameObject lv3;


	enum Section
	{
		ジョーカー,
		ユニット,
		進化,
		トリガー,
		インターセプト,
		ウィルス,
		カエル,
	};
	public enum CardRace
	{
		なし,
		獣,
		戦士,
		珍獣,
		悪魔,
		巨人,
		精霊,
		機械,
		侍,
		ドラゴン,
		魔導士,
		天使,
		神,
		不死,
		忍者,
		海洋,
		英雄,
		神獣,
		舞姫,
		盗賊,
		昆虫,
		道化師,
		四聖獣,
		武神
	}

	//カードの情報を出しましょ
	public void LoadInfo(CardData cardData)
	{
		name.text = cardData.name;
		for (int i = 0; i < Enum.GetNames(typeof(Section)).Length; i++)
		{
			if (cardData.section == i)
			{
				Section _section = (Section)Enum.ToObject(typeof(Section), i);
				section.text = _section.ToString();
			}
		}
		for (int i = 0; i < Enum.GetNames(typeof(CardRace)).Length; i++)
		{
			if (cardData.race1 == i)
			{
				CardRace _cardRace = (CardRace)Enum.ToObject(typeof(CardRace), i);

				race1.text = _cardRace.ToString();
			}
			if (cardData.race2 == i)
			{
				CardRace _cardRace = (CardRace)Enum.ToObject(typeof(CardRace), i);

				race2.text = _cardRace.ToString();
			}
		}
		cp.text = cardData.cp.ToString();
		bp1.text = cardData.bp1.ToString();
		bp2.text = cardData.bp2.ToString();
		bp3.text = cardData.bp3.ToString();
		effect.text = cardData.effectText;

		//レベルで赤くする場所を変更
		switch (cardData.level)
		{
			case 1:
				lv1.SetActive(true);
				lv2.SetActive(false);
				lv3.SetActive(false);
				break;
			case 2:
				lv1.SetActive(false);
				lv2.SetActive(true);
				lv3.SetActive(false);
				break;
			case 3:
				lv1.SetActive(false);
				lv2.SetActive(false);
				lv3.SetActive(true);
				break;
		}

		//色をかえましょ
		switch (cardData.color)
		{
			case 0:
				ColorImage.GetComponent<Image>().color = Color.black;
				break;
			case 1:
				ColorImage.GetComponent<Image>().color = Color.red;
				break;
			case 2:
				ColorImage.GetComponent<Image>().color = Color.yellow;
				break;
			case 3:
				ColorImage.GetComponent<Image>().color = Color.blue;
				break;
			case 4:
				ColorImage.GetComponent<Image>().color = Color.green;
				break;
			case 5:
				//紫はじぶんで作って
				ColorImage.GetComponent<Image>().color = Color.white;
				break;
		}
	}
}
