using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToDeckEdit()
    {
        SceneManager.LoadScene("DeckEdit");
    }

    //public void test()
    //{
    //    scenemanager.loadscene("test");
    //}
}
