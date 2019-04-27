using System.Collections;
using System.Collections.Generic;
using Lobby;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour {


    public void OnStartGameButtonClick()
    {
        LobbySceneManager.Instance.MoveToGameScene();
    }


}
