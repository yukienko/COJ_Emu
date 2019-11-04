/*

Cardより受け取った情報をもとにカードの生成を行い、デッキに追加する。

 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeckGenerater : MonoBehaviour
{
    public GameObject cardPrefab;
    Sprite sprite;
    string cardImagePath;


    public void Generate(List<CardData> _cardDataList, Deck _deck)
    {
        for (int i = 0; i < _cardDataList.Count; i++)
        {
            GameObject cardObj = Instantiate(cardPrefab);
            cardObj.name = _cardDataList[i].name;
            GameObject cardImage = cardObj.transform.Find("Image").gameObject;
            cardImagePath = Environment.CurrentDirectory + "\\cardImage\\units\\unit (" + _cardDataList[i].id.ToString() + ").jpg";
            Debug.Log(cardImagePath);

            Texture Card_texture = cardImage.GetComponent<Texture>();
            if (!File.Exists(cardImagePath))
            {
                Debug.Log("error");
            }
            else
            {
                Card_texture = ReadTexture(cardImagePath, 93, 140);
            }
            // テクスチャーを適用
            cardImage.GetComponent<Renderer>().material.mainTexture = Card_texture;
            // 下地の色は白にしておく (そうしないと下地の色と乗算みたいになる)
            cardImage.GetComponent<Renderer>().material.color = Color.white;


            Card card = cardObj.GetComponent<Card>();
            card.Load(_cardDataList[i]);
            _deck.Add(card);
        }
    }

    //フォルダ内のJPGを読み込む
    Texture ReadTexture(string path, int width, int height)
    {
        byte[] readBinary = ReadJpgFile(path);

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }

    byte[] ReadJpgFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

}