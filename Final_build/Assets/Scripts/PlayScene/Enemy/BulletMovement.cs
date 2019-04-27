using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    
    public Vector3 DirVector { get; set; }

    public float AttackDamage { get; set; }

    public bool canStart { get; set; }


    void Start()
    {
        canStart = false;

        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        transform.localPosition += DirVector * 0.25f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag.Equals("Player"))
        {
            coll.GetComponent<PlayerHealth>().Damaged(AttackDamage);
            Destroy(gameObject);
        }
    }

}
