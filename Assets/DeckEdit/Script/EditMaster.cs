/*
 * ここでカードの生成するコードを書く
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMaster : MonoBehaviour
{
	public ReadText readText;
	CardGenerater_DE cardGenerater;
	Deck_DE deck_;


	// Start is called before the first frame update
	void Start()
	{
		cardGenerater = GetComponent<CardGenerater_DE>();

		//クリックされたときに呼び出す。
		//カードの表示だけ行う
		List<CardData_DE> generateCardList = new List<CardData_DE>()
		{
			 new CardData_DE(132,"name0",1,1,1,0,1000,1000,2000,"asd","このユニットはテスト用です。効果なんてないよおおおおお"),
			 new CardData_DE(133,"name0",1,1,1,0,1000,1000,2000,"asd","このユニットはテスト用です。効果なんてないよおおおおお"),
			 new CardData_DE(134,"name0",1,1,1,0,1000,1000,2000,"asd","このユニットはテスト用です。効果なんてないよおおおおお"),
			 new CardData_DE(135,"name0",1,1,1,0,1000,1000,2000,"asd","このユニットはテスト用です。効果なんてないよおおおおお"),
			 new CardData_DE(136,"name0",1,1,1,0,1000,1000,2000,"asd","このユニットはテスト用です。効果なんてないよおおおおお"),
		};

		cardGenerater.Generate(generateCardList, deck_);
	}

	// Update is called once per frame
	void Update()
	{

	}
}


