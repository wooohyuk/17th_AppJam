using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : AudioController
{

	public static SoundEffectController instance;
	protected override void Awake ()
	{
		base.Awake ();
		instance = GetComponent<SoundEffectController> ();
	}

	public void PlaySoundEffect (AudioClip clip, float volumeScale = 1)
	{
		audioSource.PlayOneShot (clip: clip, volumeScale: volumeScale);
	}

}
