using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_Long : MonoBehaviour {

    public float AttackDamage { get; set; }

    [SerializeField]
    GameObject bulletPrefab;

    bool canAttack = true;

    float attackDelay = 1.0f;


    void Start()
    {
        AttackDamage = GetComponent<EnemyAttack>().AttackDamage;
    }


    public void Attack(Vector3 dir)
    {
        if (!canAttack)
            return;

        canAttack = false;
        attackDelay = 1.0f;

        var bullet = Instantiate(bulletPrefab, transform.parent.parent);
        bullet.transform.position = transform.position;
        bullet.GetComponent<BulletMovement>().AttackDamage = AttackDamage;
        bullet.GetComponent<BulletMovement>().DirVector = dir;
        bullet.GetComponent<BulletMovement>().canStart = true;
        Debug.Log(dir);
    }


    void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay <= 0.0f)
        {
            attackDelay = 0.0f;
            canAttack = true;
        }
    }

}
