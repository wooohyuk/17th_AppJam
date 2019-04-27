using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayScene.Player;
public class PlayerAttack : MonoBehaviour {

    Animator anim;

    [SerializeField]
    GameObject weaponObj;
    [SerializeField]
    Image weapon;

    [SerializeField]
    Sprite[] weaponSprites;

    void Start()
    {
        anim = GetComponent<Animator>();
        weaponObj.SetActive(false);
    }


    IEnumerator IEWeaponAni()
    {
        weaponObj.SetActive(true);
        float t = 0.0f;
        int i = 0;
        while(t < 0.4f)
        {
            t += 0.4f / 5f;
            weapon.sprite = weaponSprites[i];
            i = (i + 1) % 5;
            yield return new WaitForSeconds(0.4f / 5f);
        }
        weaponObj.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsInvoking("ResetBool"))
        {
            anim.SetBool("isAttacking", true);
            StartCoroutine(IEWeaponAni());
            PlayerEffectSoundManager.Instance.PlaySkill_NormalAttack();

            Invoke("ResetBool", 0.4f);
        }
    }

    void ResetBool()
    {
        anim.SetBool("isAttacking", false);
    }

}
