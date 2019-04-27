using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAnimation : MonoBehaviour {

    [SerializeField]
    Sprite[] skillImgs;

    [SerializeField]
    Image effImage;

    IEnumerator IESkillAni(float time)
    {
        float t = 0.0f;
        int i = 0;
        while(t<=time)
        {
            t += time / skillImgs.Length;
            effImage.sprite = skillImgs[i];
            i = (i + 1) % skillImgs.Length;
            yield return new WaitForSeconds(time / skillImgs.Length);
        }
        gameObject.SetActive(false);
    }

    public void StartAni(float time)
    {
        StartCoroutine(IESkillAni(time));
    }

}
