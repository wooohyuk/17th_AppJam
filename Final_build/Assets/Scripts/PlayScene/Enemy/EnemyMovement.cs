using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float MoveSpeed { get; set; }

    EnemyAttack attackCtrl;
    EnemyAttack_Long attackLongCtrl;

    EnemyHealth healthCtrl;

    [SerializeField]
    Transform target;

    EEnemyType enemyType;
    float dist = 0.7f;

    bool readyToFollow = true;

    Animator anim;

    public void SetTarget(Transform t)
    {
        target = t;
        readyToFollow = true;
    }


    void Start()
    {
        attackCtrl = GetComponentInChildren<EnemyAttack>();
        attackLongCtrl = GetComponentInChildren<EnemyAttack_Long>();
        healthCtrl = GetComponentInChildren<EnemyHealth>();
        anim = GetComponent<Animator>();
        enemyType = GetComponent<EnemyCtrl>().EnemyType;

        if (enemyType != EEnemyType.TYPE1)
            dist = 7.5f;
    }

    void Update()
    {
        if (!readyToFollow || healthCtrl.isDead)
            return;

        if(target.position.x > transform.localPosition.x)
            transform.localEulerAngles = Vector3.up * 180f;
        else
            transform.localEulerAngles = Vector3.zero;

        Vector3 distance = target.position - transform.localPosition;

        Vector3 dirVec = distance.normalized;

        if (distance.magnitude > dist)
        {
            transform.localPosition += dirVec * MoveSpeed;
            anim.SetBool("isAttacking", false);
        }
        else if (enemyType == EEnemyType.TYPE1)
        {
            attackCtrl.Attack();
            anim.SetBool("isAttacking", true);
        }
        else
        {
            attackLongCtrl.Attack(dirVec);
            anim.SetBool("isAttacking", true);
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag.Equals("PlayerAttack"))
        {
            healthCtrl.Damaged(50.0f);
        }
        else if(coll.tag.Equals("Buwaaang"))
        {
            healthCtrl.Damaged(100.0f);
        }
    }

}
