using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour
{
	public Text Loading;
	private string loading = "Now Loading";
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
		Loading.text = loading;
		SceneManager.LoadScene("DeckEdit");
	}

	public void MoveToGame()
	{
		Loading.text = loading;
		SceneManager.LoadScene("Game");
	}

	public void MoveToTitle()
	{
		Loading.text = loading;
		SceneManager.LoadScene("Title");
	}
}
