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


	public void LoadInfo(CardData_DE cardData_DE)
	{
		name.text = cardData_DE.name;
		section.text = cardData_DE.section.ToString();
		color.text = cardData_DE.color.ToString();
		race1.text = cardData_DE.race1.ToString();
		race2.text = cardData_DE.race2.ToString();
		cp.text = cardData_DE.cp.ToString();
		bp1.text = cardData_DE.bp1.ToString();
		bp2.text = cardData_DE.bp2.ToString();
		bp3.text = cardData_DE.bp3.ToString();
		effect.text = cardData_DE.effectText;
		flavor.text = cardData_DE.flavorText;
	}
}
