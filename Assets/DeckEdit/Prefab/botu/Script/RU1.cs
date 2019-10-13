using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RU1
{
    public class RU1 : MonoBehaviour
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
            カ //カエル
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
        string name = "ナイトメアシープ";
        CardType rarity = CardType.ユ;
        CardColor color = CardColor.赤;
        CardRace race = CardRace.獣;
        CardRace race2 = CardRace.なし;
        int cp = 1;
        int bp1 = 3000;
        int bp2 = 4000;
        int bp3 = 5000;

        string effect = "■レッド・クロック あなたのターン開始時、あなたの赤属性ユニットを１体選ぶ。それのレベルを＋１する。";

        string flavor = "実験中の大事故、クロックパラドクスの影響を受けた居眠り好きの珍獣。赤のクロックを制御する機能をその身に宿した。";

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