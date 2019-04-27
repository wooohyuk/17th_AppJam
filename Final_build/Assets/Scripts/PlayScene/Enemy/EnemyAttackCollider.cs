using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour {

    public float AttackDamage { get; set; }

    Rigidbody2D rigid2D;

    bool canAttack = false;

    public void SetCanAttack(bool b)
    {
        canAttack = b;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag.Equals("Player") && canAttack)
        {
            coll.GetComponent<PlayerHealth>().Damaged(AttackDamage);
            canAttack = false;
        }
    }


    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigid2D.IsSleeping())
            rigid2D.WakeUp();
    }

}
