using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lobby
{
    public class LobbySceneManager : MonoBehaviour
    {

        public static LobbySceneManager Instance;
        private void Awake()
        {
            Instance = this;
        }


        public void MoveToGameScene()
        {
            SceneFader.Instance.LoadSceneWhenFadingComplete(SceneType.PlayScene);
//            SceneManager.LoadScene(SceneType.PlayScene.ToString());
        }

    }
}

