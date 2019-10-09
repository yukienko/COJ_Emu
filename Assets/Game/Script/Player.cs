using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand;
    public Field field;
    public Deck deck;
    public Sutehuda sutehuda;
    public TurnTimer timer;

    public void Draw()
    {
        //デッキの何番目のカードを対象に
        Card card = deck.Pull(0);
        //手札に移動
        hand.Add(card);
    }

    public void MainPhaseAction()
    {
        Card card = hand.Pull(0);
        field.Add(card);
    }
}