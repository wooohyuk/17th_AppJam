using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateShot : MonoBehaviour {

    [SerializeField]
    Vector3 pos1;

    [SerializeField]
    Vector3 pos2;

    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    AnimationCurve curve2;

    [SerializeField]
    GameObject back;

    [SerializeField]
    GameObject hitBox;

    IEnumerator Move()
    {
        float t = 0.0f;

        Vector3 start = transform.localPosition;
        while(t <= 2.0f)
        {
            t += Time.deltaTime;

            if(t <= 1.0f)
            {
                transform.localPosition = Vector3.Lerp(start, pos1, curve.Evaluate(t / 1.0f));
            }
            else if (t <= 1.5f)
            {
                transform.localPosition = Vector3.Lerp(pos1, pos2, (t - 1.0f) / 0.5f);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(pos2, pos2 + new Vector3(-1000.0f, 0.0f, 0.0f), curve2.Evaluate((t - 1.5f) / 0.5f));
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(0.25f);

        back.SetActive(true);
        hitBox.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        hitBox.SetActive(false);

        t = 0.0f;
        Image img = back.GetComponent<Image>();
        while(t <= 0.5f)
        {
            t += 0.01f;
            Color c = img.color;
            c.a = Mathf.Lerp(1.0f, 0.0f, t / 0.5f);
            img.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        back.SetActive(false);

        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StartCoroutine(Move());
    }
}
