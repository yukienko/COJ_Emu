using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infomation_DE : MonoBehaviour
{
	public new Text name;
	public Text section;
	public Text color;
	public Text race1;
	public Text race2;
	public Text cp;
	public Text bp1;
	public Text bp2;
	public Text bp3;
	public Text effect;
	public Text flavor;
	public Text gauge;

	enum Section
	{
		ジ,
		ユ,
		進,
		ト,
		イ,
		ウ,
		カ,
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
	public enum CardColor
	{
		無,
		赤,
		黄,
		青,
		緑,
		紫
	};
	public enum JokerGauge
	{
		無,
		小,
		中,
		大,
		特,
		全,
	};


	public void LoadInfo_Joker(JokerData_DE jokerData_DE)
	{
		name.text = jokerData_DE.name;
		for (int i = 0; i < Enum.GetNames(typeof(Section)).Length; i++)
		{
			if (jokerData_DE.section == i)
			{
				Section _section = (Section)Enum.ToObject(typeof(Section), i);
				section.text = _section.ToString();
			}
		}
		cp.text = jokerData_DE.cp.ToString();
		effect.text = jokerData_DE.effectText;
		for (int i = 0; i < Enum.GetNames(typeof(JokerGauge)).Length; i++)
		{
			if (jokerData_DE.useGauge == i)
			{
				JokerGauge _gauge = (JokerGauge)Enum.ToObject(typeof(JokerGauge), i);
				gauge.text = _gauge.ToString();
			}
		}
		color.text = "-";
		race1.text = "-";
		race2.text = "-";
		bp1.text = "-";
		bp2.text = "-";
		bp3.text = "-";
		flavor.text = "-";
	}

	public void LoadInfo(CardData_DE cardData_DE)
	{
		name.text = cardData_DE.name;
		for (int i = 0; i < Enum.GetNames(typeof(Section)).Length; i++)
		{
			if (cardData_DE.section == i)
			{
				Section _section = (Section)Enum.ToObject(typeof(Section), i);
				section.text = _section.ToString();
			}
		}
		for (int i = 0; i < Enum.GetNames(typeof(CardRace)).Length; i++)
		{
			if (cardData_DE.race1 == i)
			{
				CardRace _cardRace = (CardRace)Enum.ToObject(typeof(CardRace), i);

				race1.text = _cardRace.ToString();
			}
			if (cardData_DE.race2 == i)
			{
				CardRace _cardRace = (CardRace)Enum.ToObject(typeof(CardRace), i);

				race2.text = _cardRace.ToString();
			}
		}
		for (int i = 0; i < Enum.GetNames(typeof(CardColor)).Length; i++)
		{
			if (cardData_DE.color == i)
			{
				CardColor _color = (CardColor)Enum.ToObject(typeof(CardColor), i);
				color.text = _color.ToString();
			}
		}
		cp.text = cardData_DE.cp.ToString();
		bp1.text = cardData_DE.bp1.ToString();
		bp2.text = cardData_DE.bp2.ToString();
		bp3.text = cardData_DE.bp3.ToString();
		effect.text = cardData_DE.effectText;
		flavor.text = cardData_DE.flavorText;
		gauge.text = "-";
	}
}
