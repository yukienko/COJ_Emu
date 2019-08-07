using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckEdit_Card : MonoBehaviour
{
    //デッキに入れられる数
    private const int limit = 3;
    //今何枚デッキに入っているか
    private int count;
    //今のデッキ枚数
    public Text DeckCount;
    //デッキの枚数上限
    private const int deckLimit = 40;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        if (!Input.GetKey(KeyCode.Q))
        {
            if (count < 3)
            {
                if (int.Parse(DeckCount.text) < deckLimit)
                {
                    count++;
                    DeckCount.text = (int.Parse(DeckCount.text) + 1).ToString();

                }
            }
        }
        //説明を表示
        else
        {

        }
    }
}
