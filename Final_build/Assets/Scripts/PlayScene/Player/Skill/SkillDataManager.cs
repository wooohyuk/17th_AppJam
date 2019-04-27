using System.Collections.Generic;
using UnityEngine;

namespace PlayScene.Player.Skill
{

    public class SkillDataManager: MonoBehaviour
    {


        public List<SkillData> skillDataList = new List<SkillData>();


        public static SkillDataManager Instance;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ResetAllSkillCooltime();
        }


        private void Update()
        {
            AutoUpdateCooltime();
        }

        // TODO Optimize `List.Find`
        // Only allowed in `Update` function in this instance
        void AutoUpdateCooltime()
        {
            foreach (var skillData in skillDataList)
            {
                var newCooltime = skillData.CoolTime - Time.deltaTime;
                UpdateSkillCooltime(skillData.SkillType, newCooltime);
            }
        }

        public void ResetAllSkillCooltime()
        {
            foreach (var skillData in skillDataList)
            {
                skillData.ResetCooltime();
                Debug.Log(skillData);

            }
        }

        public void UpdateSkillCooltime(SkillType skillType, float newCoolTime)
        {
            if (newCoolTime <= 0)
            {
                newCoolTime = 0;
            }
            FindSkillDataByType(skillType).CoolTime = newCoolTime;
        }

        public SkillData FindSkillDataByType(SkillType skillType)
        {
            var skillData = skillDataList.Find(i => i.SkillType == skillType);
            return skillData;
        }

    }

}