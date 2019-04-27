using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager {
    // Add 'Root Level' controls here

    public const string VersionName = "Initial";
    public const int VersionCode = 1;

}




// Match Unity's SceneName use when loading scene.
// E.g.         SceneManager.LoadScene(SceneType.Lobby.ToString());
public enum SceneType{
    Lobby,
    PlayScene,
    Ending,
}
