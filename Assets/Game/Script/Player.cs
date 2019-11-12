using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand;
    public Field field;
    public Deck deck_;
    public Sutehuda sutehuda;
    public TurnTimer timer;
	public CardList cardList;

	//持てる最大のカードの枚数
	private int maxHandCount = 7;
	//存在できるフィールドのユニットの数
	private int maxFieldCount = 5;

	//カードドロー
	public void Draw()
    {
		//現在の手札が所持できる枚数かどうか
		if (hand.cardList.Count == maxHandCount)
		{
			Debug.Log("手札が満タンです。これ以上ドローできません。");
			return;
		}

		//デッキをシャッフルする
		DeckShuffle();

		//デッキの何番目のカードを対象に
		Card card = deck_.Pull(0);

		//引くときにランダムなカードを引く
		//Card card = deck_.Pull(UnityEngine.Random.Range(0,deck_.cardList.Count));

		//手札に移動
		hand.Add(card);

		Debug.Log("1枚ドロー");
    }

	//デッキのシャッフル
	public void DeckShuffle()
	{
		//システム起動後のミリ秒単位の経過時間を取得
		int seed = Environment.TickCount;

		//seedに従い、ランダムな値を取得できるようにする
		System.Random _random = new System.Random(seed);

		int n = deck_.cardList.Count;

		//仮のゲームオブジェクト
		Card myGO;

		//リストの入れ替え(質問のリンク)
		//https://teratail.com/questions/222345
		for (int i = 0; i < n; i++)
		{
			int r = i + (int)(_random.NextDouble() * (n - i));
			myGO = deck_.cardList[r];
			deck_.cardList[r] = deck_.cardList[i];
			deck_.cardList[i] = myGO;
		}
	}

	//カードをフィールドに出す(仮)
    public void MainPhaseAction()
    {
		//フィールドが満タンかどうか
		if(field.cardList.Count == maxFieldCount)
		{
			Debug.Log("フィールドが満タンです。これ以上出せません。");
			return;
		}
        Card card = hand.Pull(0);
        //カードの拡大
        Vector3 fieldUnitScale = new Vector3(1.4f, 1.4f, 1.4f);
        card.transform.localScale = fieldUnitScale;
		//フィールドへ移動
        field.Add(card);

		Debug.Log("1体フィールドへ出した。");
    }
}