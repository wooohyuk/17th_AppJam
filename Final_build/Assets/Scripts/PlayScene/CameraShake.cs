using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    float power = 1.0f;

    float delta = 0.05f;

    bool shouldShake = false;


    public void ShakeCam(float p, float d)
    {
        shouldShake = true;
        power = p;
        delta = d;
    }

    void Update()
    {
        if (!shouldShake)
            return;

        transform.position = (Vector2)transform.position + Random.insideUnitCircle * power;
        power -= delta;
        if (power <= 0.0f)
            shouldShake = false;

        Vector3 pos = transform.localPosition;
        pos.z = -10f;
        transform.localPosition = pos;
    }

}
