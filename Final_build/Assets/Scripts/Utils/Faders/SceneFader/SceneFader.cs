using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum SceneFadeType
{
	FadeIn = 1,
	FadeOut = -1
}


public class SceneFader : MonoBehaviour
{

	public static SceneFader Instance;
	void Awake ()
	{
		Instance = this;

		// StartFadeOut
		StartFading (SceneFadeType.FadeOut, null);

	}


	public void LoadSceneWhenFadingComplete (SceneType sceneType)
	{
		// 1. start Fading
		// 2. on fading complete, LoadScene
		StartFading
		(
			fadeType: SceneFadeType.FadeIn,
			onFadingComplete: () => {
				SceneManager.LoadScene (sceneType.ToString ());
			}
		);

	}

	public void LoadSceneWhenFadingCompleteAsync (ScenePreloader scenePreloader)
	{
		// 1 start preloading scene
		// 2 on preloading complete, start fading
		// 3 on fading complete LoadScene


		scenePreloader.AddOnPreloadCompleteAndTriggerIfLoaded (
			onPreloadComplete: () => {
				StartFading (
					fadeType: SceneFadeType.FadeIn,
					onFadingComplete: () => {
						scenePreloader.ActivateSceneWhenReady ();
					}
				);
			}
		);

	}

	private void StartFading (SceneFadeType fadeType, Action onFadingComplete)
	{
		Debug.LogWarning ("StartFAding ");
		ScreenFader.instance.BeginFade (fadeType, onFadingComplete);
		AudioMasterController.instance.StartFading (fadeType, null);
	}


}