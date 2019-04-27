using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiSceneMusicStreamer : MusicController
{

	public List<SceneSoundTrackData> sceneSoundTracks = new List<SceneSoundTrackData> ();

	public override bool doPlayAutomatically {
		get {
			return false;
		}
	}



	public static new MultiSceneMusicStreamer instance;
	protected override void Awake ()
	{
		//
		// do not call base.Awake();
		//

		if (instance == null) {
			instance = this;
			MusicController.instance = this;
			SceneManager.activeSceneChanged += OnSceneChanged;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}



	public SceneSoundTrackData currentSceneSoundTrackData;
	public void SetSceneSoundTrack (SceneSoundTrackData currentSceneSoundTrackData)
	{
		Debug.Log ("SetSceneSoundTrack data = " + currentSceneSoundTrackData.name);
		this.currentSceneSoundTrackData = currentSceneSoundTrackData;
		base.SoundTrack = currentSceneSoundTrackData.soundTrack;
	}



	void OnSceneChanged (Scene previousScene, Scene changedScene)
	{
		Debug.Log (SceneHelper.CurrentScene.ToString ());
		var previousSceneSoundTrackData = currentSceneSoundTrackData;
		var changedSceneType = SceneHelper.GetSceneTypeByScene (changedScene);
		Debug.Log ("OnSceneChanged changedScene = " + changedSceneType.ToString ());

		var changedSceneSoundtrackData = sceneSoundTracks.Where (s => s.soundTrackScene == changedSceneType).FirstOrDefault ();
		if (changedSceneSoundtrackData != null) {
			SetSceneSoundTrack (changedSceneSoundtrackData); // = 1

			if (previousSceneSoundTrackData == null) {
				base.PlayNewSoundTrackLooped (); // = 2
			} else {

				foreach (var prev in previousSceneSoundTrackData.allowedScenes) {
					Debug.Log ("Allowed Scenes = " + prev.ToString ());
				}

				if (previousSceneSoundTrackData.allowedScenes.Contains (changedSceneType)) {
					// dont stop music  = 0
					// change sound track to changed scenes = 1
					Debug.Log ("current scene allowed. dont stop the music");

				} else {
					// change sound track to changed scenes = 1
					// stop previouse soundTrack = 2
					// play changed soundtrack = 2
					Debug.Log ("current scene NOT allowed. stop the music");

					base.PlayNewSoundTrackLooped (); // = 2
				}
			}
		}
	}
}
