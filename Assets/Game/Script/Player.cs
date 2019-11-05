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

	public void Draw()
    {
        //デッキの何番目のカードを対象に
        Card card = deck_.Pull(0);
        //手札に移動
        hand.Add(card);
    }

    public void MainPhaseAction()
    {
        Card card = hand.Pull(0);
        //カードの拡大
        Vector3 fieldUnitScale = new Vector3(1.4f, 1.4f, 1.4f);
        card.transform.localScale = fieldUnitScale;
        field.Add(card);
    }
}