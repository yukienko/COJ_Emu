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
        //デッキの何番目のカードを対象に
        Card card = deck_.Pull(0);
        //手札に移動
        hand.Add(card);

		Debug.Log("1枚ドロー");
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