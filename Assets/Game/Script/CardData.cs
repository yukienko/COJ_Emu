using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
{
    public int id;
    public string name;
    public int level;
    public int cost;
    

    public CardData(int _id, string _name, int _level, int _cost)
    {
        id = _id;
        name = _name;
        cost = _cost;
        level = _level;
    }
}