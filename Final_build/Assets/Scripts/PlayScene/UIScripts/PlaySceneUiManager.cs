using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace PlayScene.UIScripts
{
    public class PlaySceneUiManager :Singleton<PlayDataManager>
    {


        public Text GameScoreText;
        public Text PlayTimeText;


        private void Start()
        {
            PlayDataManager.Instance.SubscribeOnPlaytimeUpdated(UpdatePlayTimeText);
            PlayDataManager.Instance.SubscribeOnGamescoreUpdated(UpdateGameScoreText);
        }

        void UpdateGameScoreText(int value)
        {
            GameScoreText.text = value.ToString();
        }

        void UpdatePlayTimeText(float value)
        {
            PlayTimeText.text = value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
