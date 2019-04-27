﻿using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtility
{

	const string assetFilePerfix = ".asset";

	/// <summary>
	//	This makes it easy to create, name and place unique new ScriptableObject asset files.
	/// </summary>
	public static T CreateAsset<T> (bool overrideName = false, string nameToOverride = null) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T> ();

		string path = AssetDatabase.GetAssetPath (Selection.activeObject);
		if (path == "") {
			path = "Assets";
		} else if (Path.GetExtension (path) != "") {
			path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
		}

		string assetName;

		if (overrideName) {
			assetName = nameToOverride + assetFilePerfix;
		} else {
			assetName = "New " + typeof (T).ToString ();
		}

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + assetName);// + assetFilePerfix);


		AssetDatabase.CreateAsset (asset, assetPathAndName);

		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;

		return asset;
	}
}