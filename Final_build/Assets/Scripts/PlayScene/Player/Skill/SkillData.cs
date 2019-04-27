using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayScene.Player.Skill
{
//    [CreateAssetMenu (menuName = "SkillData", fileName = "new SkillItemData")]
    public class SkillData: ScriptableObject
    {
        [SerializeField]
        public SkillType SkillType;
        [SerializeField]
        public string SkillName;
        [SerializeField]
        public Sprite SkillUISprite;

        [SerializeField] public float DefaultCooltime;
        private float _coolTime;
        public float CoolTime
        {
            get { return _coolTime; }
            set
            {
                _coolTime = value;
                if (OnCooltimeUpdated != null) OnCooltimeUpdated(value);
            }
        }



        public Action<float> OnCooltimeUpdated;

        public void ResetCooltime()
        {
            CoolTime = DefaultCooltime;
            Debug.Log("Reset Cooltime" + _coolTime);
        }
    }


    public enum SkillType
    {
        Q,
        E,
        R,
        F,
        Dash
    }
}