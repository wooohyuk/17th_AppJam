using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyType
{
    TYPE1,
    TYPE2,
    TYPE3,
    _COUNT
}

public class EnemyCtrl : MonoBehaviour {
    
    public EEnemyType EnemyType;

    [Space(10)]

    [SerializeField]
    EnemyAttack attackCtrl;
    [SerializeField]
    EnemyMovement moveCtrl;
    [SerializeField]
    EnemyHealth healthCtrl;

    void Start()
    {
        switch(EnemyType)
        {
            case EEnemyType.TYPE1:
                attackCtrl.AttackDamage = 1f;
                moveCtrl.MoveSpeed = 0.05f;
                healthCtrl.EnemyHP = healthCtrl.MaxEnemyHP = 100f;
                break;
            case EEnemyType.TYPE2:
                attackCtrl.AttackDamage = 1f;
                moveCtrl.MoveSpeed = 0.075f;
                healthCtrl.EnemyHP = healthCtrl.MaxEnemyHP = 100f;
                break;
            case EEnemyType.TYPE3:
                attackCtrl.AttackDamage = 1f;
                moveCtrl.MoveSpeed = 0.1f;
                healthCtrl.EnemyHP = healthCtrl.MaxEnemyHP = 100f;
                break;
        }
    }

}
