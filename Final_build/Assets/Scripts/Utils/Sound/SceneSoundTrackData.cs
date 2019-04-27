using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Sound/SceneSoundTrackData", fileName = "new SceneSoundTrackData")]
public class SceneSoundTrackData : ScriptableObject
{

	/// <summary>
	/// Main default scene this soundTrack will be played
	/// </summary>
	public SceneType soundTrackScene;

	/// <summary>
	/// The allowed scenes. if is allowedScene, dont stop the music
	/// </summary>
	public List<SceneType> allowedScenes;

	public List<AudioClip> soundTrack;


}
