using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePreloadController : MonoBehaviour
{

	// public List<ScenePreloader> scenePreloaders = new List<ScenePreloader> ();

	public static ScenePreloadController instance;
	void Awake ()
	{
		instance = GetComponent<ScenePreloadController> ();
	}



	public ScenePreloader CreateNewScenePreloader ()
	{
		var newlyCreatdScenePreloader = this.gameObject.AddComponent<ScenePreloader> ();
		return newlyCreatdScenePreloader;
	}




}
