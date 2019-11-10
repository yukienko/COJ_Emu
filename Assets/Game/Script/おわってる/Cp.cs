using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cp : MonoBehaviour
{
	public GameObject activeCp;
	public GameObject unActiveCp;
	public Text cpCount;
	public List<Transform> activeCpList = new List<Transform>();
	List<Transform> unActiveCpList = new List<Transform>();
	private const int maxCp = 12;
	public int cp = 10;


    void Start()
    {
		//リストへ子を格納
		foreach(Transform g in activeCp.transform.GetComponentInChildren<Transform>())
		{
			activeCpList.Add(g);
		}
		foreach (Transform g in unActiveCp.transform.GetComponentInChildren<Transform>())
		{
			unActiveCpList.Add(g);
		}
		CpUpdate();
	}
	public void OneUpCp()
	{
		if (cp >= maxCp)
			return;
		cp++;
		CpUpdate();
	}
	public void OneDownCp()
	{
		if(cp <= 0)
			return;
		cp--;
		CpUpdate();
	}

	public void CpChange(int n)
	{
		if (n > maxCp)
			CpUp(n);
		else if (n < 0)
			CpDown(n);
		CpUpdate();
	}

	public void CpUp(int n)
	{
		cp += n;
		if (cp <= maxCp)
			cp = maxCp;
	}

	public void CpDown(int n)
	{
		cp += n;
		if (cp <= 0)
			cp = 0;
	}

	public void CpUpdate()
	{
		cpCount.text = 0.ToString();
		for (int i = 0; i < cp; i++)
		{
			activeCpList[i].gameObject.SetActive(true);
		}
		for (int i = 0; i < maxCp - cp; i++)
		{
			activeCpList[maxCp - i - 1].gameObject.SetActive(false);
		}
		cpCount.text = cp.ToString();
	}
}