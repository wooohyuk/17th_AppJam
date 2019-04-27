using PlayScene.Player.Skill;
using UnityEngine;
using UnityEngine.UI;

namespace PlayScene.UIScripts
{
    public class SkillItemView : MonoBehaviour
    {

        public Image skillImage;
        public Image skillColltimeImage;
        public Text skillColltimeText;
        public SkillData SkillData;

        private void Start()
        {
            if (SkillData != null) skillImage.sprite = SkillData.SkillUISprite;
            SubscribeCooltimeUpdatedEvent();
        }

        public void SubscribeCooltimeUpdatedEvent()
        {
            SkillData.OnCooltimeUpdated += f => { UpdateCooltimeDisplay(SkillData.CoolTime, f); };
        }

        public void UpdateCooltimeDisplay(float cooltimeLeft, float fullCooltime)
        {
            skillColltimeImage.fillAmount = cooltimeLeft / fullCooltime;

            skillColltimeText.text = cooltimeLeft.ToString("#.0");
        }

    }
}