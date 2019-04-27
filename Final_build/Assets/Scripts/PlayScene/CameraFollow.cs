using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform target;

    void Update()
    {
        Vector3 newPos = target.localPosition;

        newPos.x = Mathf.Clamp(newPos.x, -6.5f, 7.0f);
        newPos.y = Mathf.Clamp(newPos.y, -8.1f, 4.0f);
        newPos.z = -10;

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 15f);
    }

}
