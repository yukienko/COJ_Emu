using UnityEngine;

public class LogDisplayTest : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
			print("Zを押しました");
		if (Input.GetKeyDown(KeyCode.X))
			Debug.Log("Xを押しました");
		if (Input.GetKeyDown(KeyCode.C))
			Debug.LogWarning("Cを押しました");
	}
}