using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemInputManager : Singleton<GameSystemInputManager> {


	// Update is called once per frame
	void Update ()
	{
		ReadSystemInput();
	}



	void ReadSystemInput()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			print("ESC");
		}
	}
}
