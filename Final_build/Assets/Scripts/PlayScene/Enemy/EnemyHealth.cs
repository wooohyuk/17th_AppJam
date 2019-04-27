using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHPManager
{
    private static EnemyHPManager instance = null;
    private EnemyHPManager() { enemyList = new List<EnemyHealth>(); }
    public static EnemyHPManager GetInstance()
    {
        if (instance == null)
            instance = new EnemyHPManager();
        return instance;
    }


    public List<EnemyHealth> enemyList { get; set; }
}


public class EnemyHealth : MonoBehaviour {

    public float EnemyHP { get; set; }
    public float MaxEnemyHP { get; set; }

    public bool isDead { get; set; }

    [SerializeField]
    Image barImage;

    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isDead = false;
    }


    void Die()
    {
        isDead = true;
        EnemyHPManager.GetInstance().enemyList.Remove(this);
        anim.SetTrigger("isDead");
        Invoke("Delete", 0.9f);
        PlayDataManager.Instance.GameScore += 10;
    }

    public void Damaged(float value)
    {
        EnemyHP -= value;
        if(!PlayerManager.GetInstance().isFeverTime)
            PlayerManager.GetInstance().playerFeverGauge += 2.5f;
        if (EnemyHP <= 0.0f)
        {
            Die();
        }
    }

    
    void Update()
    {
        barImage.fillAmount = EnemyHP / MaxEnemyHP;
    }

    void Delete()
    {
        Destroy(transform.parent.gameObject);
    }

}
