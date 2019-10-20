using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

	public GameObject activeLife;
	public GameObject unActiveLife;
	public Text lifeCount;
	public List<Transform> activeLifeList = new List<Transform>();
	public List<Transform> unActiveLifeList = new List<Transform>();
	int life = 8;
	private const int maxLife = 8;

    // Start is called before the first frame update
    void Start()
    {
		//リストへ子を格納
		foreach (Transform g in activeLife.transform.GetComponentInChildren<Transform>())
		{
			activeLifeList.Add(g);
		}
		foreach (Transform g in unActiveLife.transform.GetComponentInChildren<Transform>())
		{
			unActiveLifeList.Add(g);
		}
		LifeUpdate();
	}

	public void OneUpLife()
	{
		if (life >= maxLife)
			return;
		life++;
		LifeUpdate();
	}

	public void OneDownLife()
	{
		if (life <= 0)
			return;
		life--;
		LifeUpdate();
	}

	public void LifeChange(int n)
	{
		if (n > maxLife)
			LifeUp(n);
		else if (n < 0)
			LifeDown(n);
		LifeUpdate();
	}


	public void LifeUp(int n)
	{
		life += n;
		if (life <= maxLife)
			life = maxLife;
	}

	public void LifeDown(int n)
	{
		life += n;
		if (life <= 0)
			life = 0;
	}

	void LifeUpdate()
	{
		for (int i = 0; i < life; i++)
		{
			activeLifeList[i].gameObject.SetActive(true);
		}
		for (int i = 0; i < maxLife - life; i++)
		{
			activeLifeList[maxLife - i - 1].gameObject.SetActive(false);
		}
		lifeCount.text = life.ToString();
	}
}
