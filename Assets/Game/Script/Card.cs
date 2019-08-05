using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private Vector3 oldV3;
    private Vector3 moveTo;
    private bool beRay = false;
    new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        oldV3 = transform.position;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }

        if (beRay)
        {
            MovePoisition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            beRay = false;
            FieldCheck();
        }
    }

    private void FieldCheck()
    {
        float lineX = 9.0f;
        float lineY = 2.0f;

        //マウスで離された先がフィールドだったら
        if(Mathf.Abs(transform.position.x) < lineX && Mathf.Abs(transform.position.y) < lineY)
        {

        }
        else
        {
            transform.position = oldV3;
        }
    }

    private void RayCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == gameObject.GetComponent<Collider>())
        {
            beRay = true;
        }
        else
        {
            beRay = false;
        }

    }

    private void MovePoisition()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = moveTo;

    }
}
