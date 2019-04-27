using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMasterController : MonoBehaviour
{


	const string masterVolumeSettingsKey = "MasterVolume";
	public static float MasterVolumePrefs {
		get {
			return PlayerPrefs.GetFloat (masterVolumeSettingsKey, 0.35f);
		}
		set {
			PlayerPrefs.SetFloat (masterVolumeSettingsKey, value);
		}
	}




	public static AudioMasterController instance;
	void Awake ()
	{
		instance = GetComponent<AudioMasterController> ();
	}




	#region Fading
	public float fadeSpeed = 0.8f;  // the fading speed
	public bool isFading;
	public void StartFading (SceneFadeType fadeType, Action onFadingComplete)
	{
		// Debug.LogError ($"StartFading fadeType = {fadeType.ToString ()}");
		isFading = true;
		float fadeStartVolume;
		float fadeTargetVolume;
		if (fadeType == SceneFadeType.FadeIn) {
			fadeStartVolume = MasterVolumePrefs;
			fadeTargetVolume = 0;
		} else {
			fadeStartVolume = 0;
			fadeTargetVolume = MasterVolumePrefs;
		}
		// Debug.LogError ($"fadeStartVolume = {fadeStartVolume}, fadeTargetVolume = {fadeTargetVolume}");
		LeanTween.value (this.gameObject, (float volume) => { AudioListener.volume = volume; }, fadeStartVolume, fadeTargetVolume, fadeSpeed);
		StartCoroutine (FadeTimerOperation (fadeSpeed, onFadingComplete));
	}


	private IEnumerator FadeTimerOperation (float duration, System.Action onFadeComplete = null)
	{
		yield return new WaitForSeconds (duration);

		if (onFadeComplete != null) {
			onFadeComplete ();
		}
	}


	#endregion

}
