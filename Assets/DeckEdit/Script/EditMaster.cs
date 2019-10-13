/*
 * ここでカードの生成するコードを書く
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditMaster : MonoBehaviour
{
	public Player_DE player_;
	public ReadText readText;
	CardGenerater_DE cardGenerater;
	Deck_DE deck_;


	// Start is called before the first frame update
	void Start()
	{
		cardGenerater = GetComponent<CardGenerater_DE>();


		//132,"name0",1,1,1,0,1000,1000,2000,"asd"
		//133,"name0",1,1,1,0,1000,1000,2000,"asd"

		//縦の列が0
		//横の列が1
		for (int i = 0; i < readText.textWords.GetLength(0); i++)
		{
			//クリックされたときに呼び出す。
			//カードの表示だけ行う
			//CardData_DE(int _id, string _name, int _section, int _cp, int _color, int _race1, int _race2, int _bp1, int _bp2, int _bp3, string _effectText,string _flavorText)
			CardData_DE generateCardList = new CardData_DE(int.Parse(readText.textWords[i, 0]), readText.textWords[i, 1], int.Parse(readText.textWords[i, 2]), int.Parse(readText.textWords[i, 3]), int.Parse(readText.textWords[i, 4]), int.Parse(readText.textWords[i, 5]), int.Parse(readText.textWords[i, 6]), int.Parse(readText.textWords[i, 7]), int.Parse(readText.textWords[i, 8]), int.Parse(readText.textWords[i, 9]), readText.textWords[i, 10], readText.textWords[i, 11]);

			cardGenerater.Generate(generateCardList, player_.deck_);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}


