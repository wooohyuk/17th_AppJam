using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioController : MonoBehaviour
{

	public AudioSource audioSource;

	protected virtual void Awake ()
	{
		audioSource = GetComponent<AudioSource> ();
	}



	// Use this for initialization
	void Start ()
	{

	}

}
