using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text levelText;
    int level;
    int cp;
    string name;

    public int cp;
    public int color;
    public int race1;
    public int race2;
    public int bp1;
    public int bp2;
    public int bp3;
    public int level;
    public string effectText;

    public void Load(CardData _cardData)
    {
        level = _cardData.level;
        levelText.text = level.ToString();
        cp = _cardData.cp;
        name = _cardData.name;
    }
}