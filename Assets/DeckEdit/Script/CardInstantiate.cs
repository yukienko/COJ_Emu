using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstantiate : MonoBehaviour
{

    //オブジェクトプール用の親
    private GameObject OP_Card;

    // Start is called before the first frame update
    void Start()
    {
        var cardMAX = 3; //存在できるカード上限
        OP_Card = GameObject.Find("ObjectPool_Card");

        // 子オブジェクトを全て取得する
        foreach (Transform childTransform in this.transform)
        {
            Debug.Log(childTransform.gameObject.name);
            for (int i = 0; i < cardMAX; i++)
            {
                GameObject card = (GameObject)Instantiate(childTransform.gameObject, transform.position, Quaternion.identity);
                card.transform.parent = OP_Card.transform;
                card.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
