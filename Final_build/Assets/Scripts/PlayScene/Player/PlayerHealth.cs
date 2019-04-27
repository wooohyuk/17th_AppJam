using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private static PlayerManager instance = null;
    private PlayerManager()
    {
        playerHP = 100f;
        playerSkillCoolTime = new float[4];
        isFeverTime = false;
        playTime = killCount = 0;
    }
    public static PlayerManager GetInstance()
    {
        if (instance == null)
            instance = new PlayerManager();
        return instance;
    }

    public float playTime { get; set; }
    public int killCount { get; set; }

    // Max == 100
    public float playerHP { get; set; }

    public float playerFeverGauge { get; set; }
    public bool isFeverTime { get; set; }

    public float[] playerSkillCoolTime { get; set; }
    public float playerUltimateGauge { get; set; }

}

public class PlayerHealth : MonoBehaviour {

    PlayerMovement moveCtrl;

    [SerializeField]
    UnityEngine.UI.Image hpBar;

    [SerializeField]
    PlayScene.UIScripts.ScoreDisplayController end;


    void Start()
    {
        moveCtrl = GetComponent<PlayerMovement>();
    }


    void Die()
    {
        //end.OnGameEnd();
        PlayScene.UIScripts.ScoreDisplayController.Instance.OnGameEnd();
    }

    public void Damaged(float dmg)
    {
        if (!moveCtrl.CanGetDamage)
            return;

        PlayerManager.GetInstance().playerHP -= dmg;
        if(PlayerManager.GetInstance().playerHP <= 0.0f)
        {
            Die();
        }
    }

    void Update()
    {
        hpBar.fillAmount = PlayerManager.GetInstance().playerHP / 100f;
    }

}
