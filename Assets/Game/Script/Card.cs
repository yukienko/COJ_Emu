using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text levelText;
    int level;
    int cost;
    int cp;
    string name;

    public void Load(CardData _cardData)
    {
        level = _cardData.level;
        levelText.text = level.ToString();
        cost = _cardData.cost;
        name = _cardData.name;
    }
}