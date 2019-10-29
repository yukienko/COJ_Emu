using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerData_DE : MonoBehaviour
{
	public int id;
	public new string name;
	public int cp;
	public string effectText;
	public int useGauge;

	public JokerData_DE(int _id, string _name, int _cp, string _effectText, int _useGauge)
	{
		id = _id;
		name = _name;
		cp = _cp;
		effectText = _effectText;
		useGauge = _useGauge;
	}
}