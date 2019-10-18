using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDeckNameObj : MonoBehaviour
{
	public Text listText;
	Text confiText;

	public void MyPointerDownUI()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("asda");
			confiText.text = listText.text;
		}
	}
	private void Start()
	{
		confiText = GameObject.Find("DeckName_Kakunin").GetComponent<Text>();
	}

}
