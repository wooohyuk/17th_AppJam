using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float AttackDamage { get; set; }

    bool canAttack = true;

    [SerializeField]
    EnemyAttackCollider attackCollider;

    float attackDelay = 1.0f;

    void Start()
    {
        attackCollider.AttackDamage = AttackDamage;
    }

    public void Attack()
    {
        if (!canAttack)
            return;

        attackDelay = 1.0f;
        canAttack = false;
        attackCollider.SetCanAttack(true);
    }


    void Update()
    {
        attackDelay -= Time.deltaTime;
        if(attackDelay <= 0.0f)
        {
            attackDelay = 0.0f;
            canAttack = true;
        }
    }

}
