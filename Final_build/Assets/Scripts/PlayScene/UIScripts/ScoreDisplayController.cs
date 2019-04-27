using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayScene.UIScripts
{
    public class ScoreDisplayController : Singleton<ScoreDisplayController>
    {
        public GameObject scoreBoardContainer;
        public Text scoreText;
        public Text timeText;

        public void OnGameEnd()
        {
            LoadDataToDisplay();
            ShowScorebordController();
        }

        void LoadDataToDisplay()
        {
            scoreText.text = PlayDataManager.Instance.GameScore.ToString();
            timeText.text = PlayDataManager.Instance.Playtime.ToString();
        }

        void ShowScorebordController()
        {
            scoreBoardContainer.SetActive(true);
        }

        private void HideScoreBoardcontroller()
        {
            scoreBoardContainer.SetActive(false);
        }

        public void RestartGame()
        {
            SceneFader.Instance.LoadSceneWhenFadingComplete(SceneType.PlayScene);
        }

        public void MoveToMainMenu()
        {
            SceneFader.Instance.LoadSceneWhenFadingComplete(SceneType.Lobby);
        }

    }
}