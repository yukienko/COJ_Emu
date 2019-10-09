using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand;
    public Field field;
    public Deck deck;
    public Sutehuda sutehuda;

    public void Draw()
    {
        //デッキの何番目のカードを引く
        Card card = deck.Pull(0);
        hand.Add(card);
    }
}