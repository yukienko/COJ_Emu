using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewChanger : MonoBehaviour
{
	//Dropdownを格納する変数
	[SerializeField] private Dropdown dropdown;
	public GameObject Card;
	GameObject hoge;
	List<GameObject> cardList = new List<GameObject>();

	public void ViewChange()
	{
		if(dropdown.value == 0)
		{
			foreach (Transform obj in Card.GetComponentInChildren<Transform>())
			{
				obj.gameObject.SetActive(true);
			}
		}
		else if(dropdown.value == 1)
		{
			foreach (Transform obj in Card.GetComponentInChildren<Transform>())
			{
				obj.gameObject.SetActive(false);
			}
		}
	}

	private void Start()
	{

	}
}
