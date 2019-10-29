/*
 * ここでカードの生成するコードを書く
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditMaster_Joker : MonoBehaviour
{
	public Player_DE player_;
	public ReadText_Joker readText_Joker;
	CardGenerater_DE cardGenerater;


	// Start is called before the first frame update
	void Start()
	{
		cardGenerater = GetComponent<CardGenerater_DE>();


		//132,"name0",1,1,1,0,1000,1000,2000,"asd"
		//133,"name0",1,1,1,0,1000,1000,2000,"asd"

		//縦の列が0
		//横の列が1
		for (int i = 0; i < readText_Joker.textWords.GetLength(0); i++)
		{
			//クリックされたときに呼び出す。
			//カードの表示だけ行う
			//CardData_DE(int _id, string _name, int _section, int _cp, int _color, int _race1, int _race2, int _bp1, int _bp2, int _bp3, string _effectText,string _flavorText)
			JokerData_DE generateJokerList = new JokerData_DE(int.Parse(readText_Joker.textWords[i, 0]), readText_Joker.textWords[i, 1], int.Parse(readText_Joker.textWords[i, 2]), readText_Joker.textWords[i, 3], int.Parse(readText_Joker.textWords[i, 4]));

			cardGenerater.GenerateJoker(generateJokerList, player_.JokerList_DE);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}


