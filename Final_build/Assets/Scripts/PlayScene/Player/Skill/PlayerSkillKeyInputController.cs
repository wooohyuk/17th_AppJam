using UnityEngine;
using PlayScene.Player.Skill;
using PlayScene.Player;
namespace PlayScene.Player
{
    public class PlayerSkillKeyInputController : MonoBehaviour {

        [SerializeField]
        GameObject qSkill;

        [SerializeField]
        GameObject[] eSkill;

        [SerializeField]
        GameObject fSkill;

        [SerializeField]
        PlayerSkillCtrl skillCtrl;

        [SerializeField]
        GameObject rSkill;

        [SerializeField]
        CameraShake camShake;


        void Update()
        {
            ReadSkillKeys();
        }

        void ReadSkillKeys()
        {
            if (Input.GetKeyDown(KeyCode.Q) && skillCtrl.coolTimes[0] < 0.01f)
            {
                qSkill.SetActive(true);
                qSkill.GetComponent<SkillAnimation>().StartAni(0.4f);
                skillCtrl.coolTimes[0] = skillCtrl.maxCoolTimes[0];

                camShake.ShakeCam(0.5f, 0.05f);
                PlayerEffectSoundManager.Instance.PlaySkill_Q();


            }

            if (Input.GetKeyDown(KeyCode.E) && skillCtrl.coolTimes[1] < 0.01f)
            {
                eSkill[0].SetActive(true);
                eSkill[0].GetComponent<SkillAnimation>().StartAni(0.4f);

                eSkill[1].SetActive(true);
                eSkill[1].GetComponent<SkillAnimation>().StartAni(0.4f);

                skillCtrl.coolTimes[1] = skillCtrl.maxCoolTimes[1];

                camShake.ShakeCam(2.5f, 0.1f);
                PlayerEffectSoundManager.Instance.PlaySkill_E();

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerEffectSoundManager.Instance.PlaySkill_R();
                rSkill.SetActive(true);

            }

            if (Input.GetKeyDown(KeyCode.F) && skillCtrl.coolTimes[2] < 0.01f)
            {
                var pipe = Instantiate(fSkill, transform.parent);
                pipe.transform.position = transform.position;
                pipe.GetComponent<PipeMovement>().dirVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                

                skillCtrl.coolTimes[2] = skillCtrl.maxCoolTimes[2];
                PlayerEffectSoundManager.Instance.PlaySkill_F();

            }

        }

    }
}
