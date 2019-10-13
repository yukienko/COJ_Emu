using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData_DE : MonoBehaviour
{
	public int id;
	public new string name;
	public int section;
	public int cp;
	public int color;
	public int race1;
	public int race2;
	public int bp1;
	public int bp2;
	public int bp3;
	public string effectText;
	public string flavorText;


	public CardData_DE(int _id, string _name, int _section, int _cp, int _color, int _race1, int _race2, int _bp1, int _bp2, int _bp3, string _effectText,string _flavorText)
	{
		id = _id;
		name = _name;
		section = _section;
		cp = _cp;
		color = _color;
		race1 = _race1;
		race2 = _race2;
		bp1 = _bp1;
		bp2 = _bp2;
		bp3 = _bp3;
		effectText = _effectText;
		flavorText = _flavorText;
	}
}
