using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : AudioController
{

	public List<AudioClip> m_soundTrack;
	virtual public List<AudioClip> SoundTrack { get { return m_soundTrack; } set { m_soundTrack = value; } }

	const string musicVolumeSettingsKey = "MusicVolume";
	public static float MusicVolumePrefs {
		get {
			return PlayerPrefs.GetFloat (musicVolumeSettingsKey, 1f);
		}
		set {
			PlayerPrefs.SetFloat (musicVolumeSettingsKey, value);
		}
	}


	public static MusicController instance;
	protected override void Awake ()
	{
		base.Awake ();
		instance = this;

	}


	public bool m_doPlayAutomatically;
	virtual public bool doPlayAutomatically {
		get { return m_doPlayAutomatically; }
		set { m_doPlayAutomatically = value; }
	}
	void Start ()
	{
		if (doPlayAutomatically) {
			PlayNewSoundTrackLooped ();
		}
	}


	Coroutine soundTrackRoutine;
	public void PlayNewSoundTrackLooped ()
	{
		Debug.Log ("PlayNewSoundTrackLooped");
		if (soundTrackRoutine != null) {
			StopCoroutine (soundTrackRoutine);
		}
		soundTrackRoutine = StartCoroutine (PlaySoundtrackLoopedOperation ());
	}

	IEnumerator PlaySoundtrackLoopedOperation ()
	{
		Debug.Log ("PlaySoundtrackLoopedOperation");

		while (true) {
			if (SoundTrack.Count > 0) {
				AudioClip randomMusic = SoundTrack [UnityEngine.Random.Range (0, SoundTrack.Count)];
				yield return StartCoroutine (PlayMusicOperation (randomMusic));
			} else {
				Debug.Log ("no sound track available. beak;");

				break;
			}
		}
	}


	IEnumerator PlayMusicOperation (AudioClip music)
	{
		Debug.Log ("PlayMusicOperation music = " + music.name);

		audioSource.clip = music;
		audioSource.Play ();
		yield return new WaitForSecondsRealtime (music.length);
	}


	public void PlayNextMusic ()
	{
		throw new NotImplementedException ();

	}

	// < = >
	public void PlayPreviousMusic ()
	{
		throw new NotImplementedException ();

	}

	public void PlayNewRandomMusic ()
	{
		PlayNewMusic (null);
		throw new NotImplementedException ();
	}

	public void PlayNewMusic (AudioClip newMusicToPlay)
	{
		// stop current music
		audioSource.Stop ();

	}

}
