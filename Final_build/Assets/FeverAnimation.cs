using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverAnimation : MonoBehaviour {

    IEnumerator IEAnimation()
    {
        float t = 0.0f;

        Image back = GetComponent<Image>();

        while(t <= 1.0f)
        {
            t += Time.deltaTime;

            if(t <= 0.5f)
            {
                Color c = back.color;
                c.a = Mathf.Lerp(0.0f, 1.0f, t / 0.5f);
                back.color = c;
            }
            else
            {
                Color c = back.color;
                c.a = Mathf.Lerp(1.0f, 0.0f, (t - 0.5f) / 0.5f);
                back.color = c;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        gameObject.SetActive(false);
    }


    void OnEnable()
    {
        StartCoroutine(IEAnimation());
    }
}
