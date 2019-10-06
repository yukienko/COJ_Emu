using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RU14
{
    public class RU14 : MonoBehaviour
    {
        //今のデッキ枚数
        Text DeckCount;
        //デッキの枚数上限
        private const int deckLimit = 40;
        //オブジェクトプール用の親
        GameObject OP_Card;
        //デッキのContents
        GameObject Deck_Contents;
        //カードのContents
        GameObject Cards_Contents;
        //(clone)の文字列
        string clone = "(Clone)";

        void Start()
        {
            DeckCount = GameObject.Find("DeckCount").GetComponent<Text>();
            OP_Card = GameObject.Find("ObjectPool_Card");
            Deck_Contents = GameObject.Find("Content_Deck");
            Cards_Contents = GameObject.Find("Content_Cards");
        }

        public void Click()
        {
            //クラスの生成
            test t;
            t = new test();
            //デッキリストから選択したカードを除外する
            if (Input.GetKey(KeyCode.D) && gameObject.transform.parent == Deck_Contents.transform)
            {
                Debug.Log("カード除外");
                gameObject.transform.parent = OP_Card.transform;
                gameObject.transform.position = Vector3.zero;

                DeckCount.text = (Deck_Contents.transform.childCount).ToString();
            }
            //説明を表示
            else if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("カード説明");
                t.Des();
            }
            //クリックしたカードをデッキリストに表示
            else if (gameObject.transform.parent == Cards_Contents.transform)
            {
                Debug.Log("カード追加");
                if (int.Parse(DeckCount.text) < deckLimit)
                {
                    foreach (Transform childTransform in OP_Card.transform)
                    {
                        if (childTransform.name == gameObject.name + clone)
                        {
                            childTransform.transform.parent = Deck_Contents.transform;
                            break;
                        }
                    }
                    DeckCount.text = (Deck_Contents.transform.childCount).ToString();
                }
            }
        }
    }

    class test
    {
        public enum CardRace
        {
            なし,
            獣,
            戦士,
            珍獣,
            悪魔,
            巨人,
            精霊,
            機械,
            侍,
            ドラゴン,
            魔導士,
            天使,
            神,
            不死,
            忍者,
            海洋,
            英雄,
            神獣,
            舞姫,
            盗賊,
            昆虫,
            道化師,
            四聖獣,
            武神
        }
        public enum CardType
        {
            ユ,
            進,
            イ,
            ト,
            J,
            ウ,
            カ
        };
        public enum CardColor
        {
            無,
            赤,
            黄,
            青,
            緑,
            紫
        };

        //仮置き用のオブジェクト

        //カードの情報
        string name = "絶望の天魔アザゼル";
        CardType rarity = CardType.進;
        CardColor color = CardColor.赤;
        CardRace race = CardRace.天使;
        CardRace race2 = CardRace.なし;
        int cp = 4;
        int bp1 = 6000;
        int bp2 = 7000;
        int bp3 = 8000;

        string effect = "■堕天使の鎮魂歌\nこのユニットがフィールドに出た時、対戦相手のトリガーゾーンにあるカードを２枚ランダムで破壊する。対戦相手のトリガーゾーンにカードがない場合、あなたのデッキからランダムで１枚トリガーゾーンにインターセプトカードをセットする。このユニットがアタックした時、対戦相手の全てのレベル２以上のユニットに６０００ダメージを与える。あなたのレベル２以上のユニットに【スピードムーブ】を与える。";

        string flavor = "人々に絶望を与える堕天使。弱き者からは抗う術を奪い、強き者にはその漆黒の剣で煉獄の制裁を与える。";

        Text Name = GameObject.Find("CardName").GetComponent<Text>();
        Text Color = GameObject.Find("CardColor").GetComponent<Text>();
        Text Rarity = GameObject.Find("CardRarity").GetComponent<Text>();
        Text Race = GameObject.Find("CardRace").GetComponent<Text>();
        Text Race2 = GameObject.Find("CardRace2").GetComponent<Text>();
        Text CP = GameObject.Find("CardCP").GetComponent<Text>();
        Text BP1 = GameObject.Find("CardBP1").GetComponent<Text>();
        Text BP2 = GameObject.Find("CardBP2").GetComponent<Text>();
        Text BP3 = GameObject.Find("CardBP3").GetComponent<Text>();
        Text Effect = GameObject.Find("CardEffect").GetComponent<Text>();
        Text Flavor = GameObject.Find("CardFlavor").GetComponent<Text>();

        public void Des()
        {
            Name.text = name;
            Color.text = color.ToString();
            Rarity.text = rarity.ToString();
            Race.text = race.ToString();
            Race2.text = race2.ToString();
            CP.text = cp.ToString();
            BP1.text = bp1.ToString();
            BP2.text = bp2.ToString();
            BP3.text = bp3.ToString();
            Effect.text = effect.ToString();
            Flavor.text = flavor.ToString();
        }
    }
}