using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
{
    public int id;
    public string name;
    public int cp;
    public int color;
    public int race1;
    public int race2;
    public int bp1;
    public int bp2;
    public int bp3;
    public int level;
    public string effectText;
    

    public CardData(int _id, string _name, int _cp, int _color, int _race1, int _race2, int _level, int _bp1, int _bp2, int _bp3, string _effectText)
    {
        id = _id;
        name = _name;
        cp = _cp;
        color = _color;
        race1 = _race1;
        race2 = _race2;
        level = _level;
        bp1 = _bp1;
        bp2 = _bp2;
        bp3 = _bp3;
        effectText = _effectText;
    }
}