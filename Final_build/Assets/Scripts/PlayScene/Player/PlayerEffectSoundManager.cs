using UnityEngine;

namespace PlayScene.Player
{
    public class PlayerEffectSoundManager : Singleton<PlayerEffectSoundManager>
    {
        public AudioSource audioSource;
        public AudioClip AudioClip_Q;
        public AudioClip AudioClip_E;
        public AudioClip AudioClip_R;
        public AudioClip AudioClip_F;
        public AudioClip AudioClip_FVoice;
        public AudioClip AudioClip_Dash;
        public AudioClip AudioClip_normSkill;
        public AudioClip AudioClip_Fever;


        void Start()
        {
            //audioSource.minu
        }

        public void PlaySkill_Q()
        {
            audioSource.PlayOneShot(AudioClip_Q);
        }


        public void PlaySkill_E()
        {
            audioSource.PlayOneShot(AudioClip_E);
        }

        public void PlaySkill_R()
        {
            audioSource.PlayOneShot(AudioClip_R);
        }

        public void PlaySkill_F()
        {
            audioSource.PlayOneShot(AudioClip_F);
            audioSource.PlayOneShot(AudioClip_FVoice);
        }


        public void PlaySkill_Dash()
        {
            audioSource.PlayOneShot(AudioClip_Dash);

        }


        public void PlaySkill_NormalAttack()
        {
            audioSource.PlayOneShot(AudioClip_normSkill);
        }


        public void PlaySkill_Fever()
        {
            audioSource.PlayOneShot(AudioClip_Fever);
        }

    }
}