using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePreloader : MonoBehaviour
{

	Action<float> onPreloadRateChanged;
	Action onPreloadComplete;
	public AsyncOperation sceneLoader;
	public bool isPreloadCompleted;


	public void StartPreloadingScene (SceneType sceneType, LoadSceneMode loadSceneMode, Action<float> onPreloadRateChanged = null, Action onPreloadComplete = null)
	{
		this.onPreloadComplete = onPreloadComplete;
		this.onPreloadRateChanged = onPreloadRateChanged;
		StartCoroutine (PreloadSceneOperation (sceneType, loadSceneMode));
	}


	public IEnumerator PreloadSceneOperation (SceneType sceneType, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		print ("PreloadSceneOperation sceneType = " + sceneType.ToString () + ", index = " + (int)sceneType);
		sceneLoader = SceneManager.LoadSceneAsync (sceneType.ToString (), loadSceneMode);
		sceneLoader.allowSceneActivation = false;

		while (!sceneLoader.isDone) {
			yield return null;
			if (sceneLoader.progress >= 0.9f) {
				print ("onPreloadComplete");
				isPreloadCompleted = true;
				if (onPreloadComplete != null) {
					onPreloadComplete ();
				}
				break;
			} else {
				if (onPreloadRateChanged != null) {
					onPreloadRateChanged (sceneLoader.progress);
				}
			}
		}
	}

	public void ActivateSceneWhenReady ()
	{

		sceneLoader.allowSceneActivation = true;

	}


	public void AddOnPreloadCompleteAndTriggerIfLoaded (Action onPreloadComplete)
	{
		AddOnPreloadComplete (onPreloadComplete);
		if (isPreloadCompleted) {
			print ("isAlreadyLoadedTrigeringCallback");
			onPreloadComplete ();
		}
	}

	public void AddOnPreloadComplete (Action onPreloadComplete)
	{
		this.onPreloadComplete += onPreloadComplete;
	}

	public void SetOnLoadProgressValueChanged (Action<float> onLoadProgressValueChanged)
	{
		this.onPreloadRateChanged = onLoadProgressValueChanged;
	}


}
