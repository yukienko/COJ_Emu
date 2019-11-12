using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sutehuda : MonoBehaviour
{
	public Hand hand;
	public List<Card> cardList = new List<Card>();
	//捨て札の1ページに入りきるカードの枚数
	private int pageMaxCard = 30;
	//今何ページ目使っているのかカウント用(1ページ目は１)
	int pageCount = 1;
	public Text Page;
	public Text PageCount;
	public GameObject SutehudaPanel;
	GameObject Panel;
	public GameObject tmp;

	//仮
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Card card = Pull(0);
			Debug.Log("削除:" + card.name);
			card.gameObject.SetActive(true);
			card.transform.SetParent(tmp.transform);
		}
	}

	//捨て札に追加
	public void Add(Card _card)
    {
		//現在の捨て札が満タンかどうか
		if (cardList.Count < pageMaxCard)
		{
			Debug.Log("カードを捨て札に追加");
		}
		else
		{
			//1枚追加すると仮定して"+1"を付けている。ついてなかったら現在のページが何ページまであるか示している。
			Debug.Log(Mathf.CeilToInt(((float)cardList.Count + 1) / pageMaxCard) + "ページ目として非表示で追加します。");
		}
		//追加
		_card.transform.SetParent(SutehudaPanel.transform);
		cardList.Add(_card);

		//捨て札の更新
		SutehudaUpdate(pageCount);
	}

	//カードの取り出し
	//==========今は親を移動させているだけなので直すこと！===========
    public Card Pull(int _position)
    {
		Debug.Log("カード捨てる:" + cardList[_position]);
        Card card = cardList[_position];
        cardList.Remove(card);

		//ちょうど取り除いたカードがそのページの最後の1枚だったら
		if (cardList.Count != 0 && Mathf.CeilToInt(((float)cardList.Count) / pageMaxCard) < pageCount)
			pageCount--;

			//捨て札の更新
			SutehudaUpdate(pageCount);
		return card;
    }

	public void SutehudaUpdate(int page)
	{
		Debug.Log("捨て札更新");
		//カードの移動があるたびに最初の30枚の表示化
		int c = (page - 1) * pageMaxCard;
		var hoge = 0;
		foreach (Card g in cardList)
		{
			if (hoge >= (page - 1) * pageMaxCard && c < pageMaxCard * page)
			{
				g.gameObject.SetActive(true);
				c++;
			}
			else
			{
				g.gameObject.SetActive(false);
			}
			hoge++;
		}

		//テキストの更新
		PageCount.text = Mathf.CeilToInt(((float)cardList.Count) / pageMaxCard).ToString();
		if (int.Parse(PageCount.text) == 0)
			PageCount.text = "1";
		Page.text = page.ToString();
	}

	//現在の捨て札のページ数を読み取り、テキストに表示、このオブジェクトの表示、非表示も
	public void SutehudaOpenClose()
	{
		Debug.Log("捨て札オープンorクローズ");
		//開閉するたびに初期化
		Page.text = "1";
		//捨て札の更新
		pageCount = int.Parse(Page.text);
		SutehudaUpdate(pageCount);

		//このオブジェクトの表示、非表示
		if (isActiveAndEnabled)
			gameObject.SetActive(false);
		else
			gameObject.SetActive(true);
	}

	public void Dump()
	{
		Debug.Log("カード捨てる");
		Card card = hand.Dump();
		Add(card);
	}

	public void PageNext()
	{
		if (Mathf.CeilToInt(((float)cardList.Count) / pageMaxCard) > pageCount)
		{
			pageCount++;
			Page.text = pageCount.ToString();
		}
		else
		{
			Debug.Log("次ページがない");
			return;
		}
		Debug.Log("次のページへ");
		SutehudaUpdate(pageCount);
	}

	public void PageBack()
	{
		if (pageCount != 1)
		{
			pageCount--;
			Page.text = pageCount.ToString();
		}
		else
		{
			Debug.Log("前ページがない");
			return;
		}
		Debug.Log("前のページへ");
		SutehudaUpdate(pageCount);
	}
}