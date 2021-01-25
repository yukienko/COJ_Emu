using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UNET6_Player : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!isLocalPlayer)
			return;

		// Escapeキーで切断する
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// 切断は、サーバーもクライアントもStopHost()でOK
			NetworkManager.singleton.StopHost();
		}
	}
}
