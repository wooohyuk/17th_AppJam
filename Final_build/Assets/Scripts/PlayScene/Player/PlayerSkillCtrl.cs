using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillCtrl : MonoBehaviour {


    public float[] maxCoolTimes = new float[4];

    public float[] coolTimes = new float[4];

    [SerializeField]
    Image[] coolImgs;

    void Start()
    {
        maxCoolTimes[0] = 1.0f;
        maxCoolTimes[1] = 3.0f;
        maxCoolTimes[2] = 5.0f;

        maxCoolTimes[3] = 2.0f;

        for (int i = 0; i < 4; i++)
            coolTimes[i] = maxCoolTimes[i];
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            coolTimes[i] -= Time.deltaTime;
            if (coolTimes[i] <= 0.0f)
                coolTimes[i] = 0.0f;
            coolImgs[i].fillAmount = coolTimes[i] / maxCoolTimes[i];
        }
    }

}
