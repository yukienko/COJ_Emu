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

	public void MoveToUNET()
	{
		Loading.text = loading;
		SceneManager.LoadScene("UNET");
	}

	public void MoveToUNET2()
	{
		Loading.text = loading;
		SceneManager.LoadScene("UNET2");
	}

	public void MoveToUNET3()
	{
		Loading.text = loading;
		SceneManager.LoadScene("UNET3");
	}

	public void MoveToUNET4()
	{
		Loading.text = loading;
		SceneManager.LoadScene("UNET4");
	}

	public void MoveToUNET5()
	{
		Loading.text = loading;
		SceneManager.LoadScene("UNET5");
	}
}