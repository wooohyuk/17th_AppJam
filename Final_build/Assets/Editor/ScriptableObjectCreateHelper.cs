using PlayScene.Player.Skill;
using UnityEngine;
using UnityEditor;


public class ScriptableObjectCreateHelper
{
	const string baseDirectory = "Assets/Create/CustomData/";



	#region licencseManagement

	[MenuItem (baseDirectory + "SkillData")]
	public static void CreateArtistDataAsset ()
	{
		ScriptableObjectUtility.CreateAsset<SkillData> ();
	}

	#endregion

/*

	[MenuItem (licencseManagementDataDirectory + "ArtModelData")]
	public static void CreateArtDataAsset ()
	{
		ScriptableObjectUtility.CreateAsset<ArtModel> ();
	}


	[MenuItem (licencseManagementDataDirectory + "LicenseData")]
	public static void CreateLicenseDataAsset ()
	{
		ScriptableObjectUtility.CreateAsset<LicenseModel> ();
	}
	#endregion

*/


	/*
	    [MenuItem(baseDirectory + "TutorialSegmentData")]
	    public static void CreateTutorialSegmentDataAsset()
	    {
		    ScriptableObjectUtility.CreateAsset<TutorialSegmentData>();
	    }*/


}