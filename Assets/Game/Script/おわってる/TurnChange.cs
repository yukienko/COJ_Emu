using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChange : MonoBehaviour
{
    int turncount;
    int order;
    public Text turn;
    public GameObject image;
	Color blue	 = new Color(0.1176471f, 0.6936585f, 1, 0.7490196f);
	Color orange = new Color(1, 0.6380112f, 0.1179245f, 0.7490196f);
	Color white  = new Color(1, 1, 1, 0.7490196f);

	// Start is called before the first frame update
	void Start()
    {
        turncount = 1;
        image.GetComponent<Image>().color = blue;
    }

    public void Button()
    {
        if (order == 0)
        {
            order++;
            image.GetComponent<Image>().color = orange;
        }
        else
        {
            if (turncount == 10)
            {
				image.GetComponent<Image>().color = white;
                turn.text = "END";
                return;
            }
            order--;
            turncount++;
            turn.text = turncount.ToString();
			image.GetComponent<Image>().color = blue;
        }
    }
}
