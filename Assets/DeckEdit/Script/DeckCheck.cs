using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCheck : MonoBehaviour
{
    private static int deck_x = 40;
    private static int deck_y = 4;
    //[デッキの何番目,Ver1\Ver2\番号]
    public static int[,] deck = new int[deck_x, deck_y];
    //一つ前のカードを保存しておくための変数
    int[] bCard = new int[deck_y];
    //カードのContents
    GameObject Cards_Contents;
    //デッキのContents
    GameObject Deck_Contents;

    // Start is called before the first frame update
    void Start()
    {
        Cards_Contents = GameObject.Find("Content_Cards");
        Deck_Contents = GameObject.Find("Content_Deck");

    }

    // Update is called once per frame
    void Update()
    {

    }

    //セーブのときにソートしてカードを全部保存する
    public void Save()
    {
        //配列の初期化
        deck = new int[deck_x, deck_y];

        var x = 0;
        foreach (Transform child in Deck_Contents.transform)
        {
            var y = 0;
            /*1_2_001(clone)
            　　　　↓
           1
           2
           001
           clone)
            */
            string[] stringArray = child.name.Split('_', '(');
            int asd = 0;
            foreach (var value in stringArray)
            {
                deck[x, y] = int.Parse(value);
                y++;

                bCard[asd] = int.Parse(value);



                if (y == deck_y - 1)
                {

                    break;
                }
            }
            x++;
        }
        if (deck[deck_x - 1, deck_y - 1] != 0)
        {
            Debug.Log("OK");
            Sort();
            for (int i = 0; i < 40; i++)
            {
                Debug.Log(deck[i, 2]);
            }
        }
        else
        {
            Debug.Log("デッキを40枚にしてください。");

        }
    }

    //デッキ内のソート（バージョン順）
    public void Sort()
    {
        List<Transform> objList = new List<Transform>();

        // 子階層のGameObject取得
        var childCount = Deck_Contents.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            objList.Add(transform.GetChild(i));
        }

        // オブジェクトを名前で昇順ソート
        objList.Sort((obj1, obj2) => string.Compare(obj1.name, obj2.name));

        // ソート結果順にGameObjectの順序を反映
        foreach (var obj in objList)
        {
            obj.SetSiblingIndex(childCount - 1);
        }
    }

    public static int[,] getDeck()
    {
        return deck;
    }
}
