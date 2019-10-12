/*

CardDataから送られてきた情報をもとにカードの生成を行う。
生成されたカードはDeckGeneraterにてデッキに生成される。

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text levelText;
    public Text CPText;
    public Text BPText;
    int id;
    new string name;
    int cp;
    int color;
    int[] race = new int[2];
    int[] bp = new int[3];
    int level;
    string effectText;

    //DeckGeneraterの中でしか起こらないのでレベルに対応したBp変化はいらない
    public void Load(CardData _cardData)
    {
        id = _cardData.id;
        name = _cardData.name;
        cp = _cardData.cp;
        CPText.text = cp.ToString();
        color = _cardData.color;
        race[0] = _cardData.race1;
        race[1] = _cardData.race2;
        bp[0] = _cardData.bp1;
        bp[1] = _cardData.bp2;
        bp[2] = _cardData.bp3;
        BPText.text = bp[0].ToString();
        level = _cardData.level;
        levelText.text = level.ToString();
    }
}