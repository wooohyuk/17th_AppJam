using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCtrl : MonoBehaviour {


	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("일시정지");
        }
	}
}
