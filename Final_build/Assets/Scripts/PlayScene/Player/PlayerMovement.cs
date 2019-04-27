using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayScene.Player;
public class PlayerMovement : Singleton<PlayerMovement> {
    
    float speed = 0.2f;

    bool canDash = true;

    float dashCharging = 0.0f;

    Animator anim;

    bool shouldStop = false;

    public bool CanGetDamage { get; set; }

    [SerializeField]
    GameObject dashEff;

    [SerializeField]
    PlayerSkillCtrl playerSkill;

    [SerializeField]
    CameraShake camShake;

    [SerializeField]
    SkillAnimation fever;
    [SerializeField]
    GameObject back;


    void Start()
    {
        anim = GetComponent<Animator>();
        CanGetDamage = true;
    }


    void DashAttack(Vector2 a, Vector2 b)
    {
        RaycastHit2D[] rays;

        rays = Physics2D.LinecastAll(a, b);

        for(int i = 0; i < rays.Length; i++)
        {
            if (!rays[i].collider.tag.Equals("Enemy"))
                continue;

            float damage = 30.0f;
            if (PlayerManager.GetInstance().isFeverTime)
                damage = 100.0f;

            rays[i].collider.gameObject.GetComponentInChildren<EnemyHealth>().Damaged(damage);
        }
        PlayerEffectSoundManager.Instance.PlaySkill_Dash();

    }

    IEnumerator IEDashMotion(Vector3 a, Vector3 b)
    {
        float t = 0.0f;
        while(t <= 0.1f)
        {
            t += Time.deltaTime;

            Vector3 movement = Vector3.Lerp(a, b, t / 0.1f);

            movement.x = Mathf.Clamp(movement.x, -14f, 14f);
            movement.y = Mathf.Clamp(movement.y, -11f, 4.35f);

            transform.position = movement;
            yield return null;
        }

        yield return new WaitForSeconds(0.25f);

        CanGetDamage = true;
    }

    IEnumerator DashEffFade()
    {
        float t = 0.0f;

        UnityEngine.UI.Image img = dashEff.GetComponentInChildren<UnityEngine.UI.Image>();

        while (t <= 0.25f)
        {
            t += Time.deltaTime;
            Color c = img.color;
            c.a = Mathf.Lerp(1.0f, 0.0f, t / 0.25f);
            img.color = c;
            yield return null;
        }

        dashEff.SetActive(false);
    }

    void Dash()
    {
        camShake.ShakeCam(1.5f, 0.2f);
        playerSkill.coolTimes[3] = playerSkill.maxCoolTimes[3];

        if (PlayerManager.GetInstance().isFeverTime)
        {
            dashCharging = 4.0f;
        }

        CanGetDamage = false;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= Vector3.forward * mousePos.z + Vector3.forward;

        Vector3 dirVec = (mousePos - transform.position).normalized;

        dashEff.SetActive(true);

        Vector3 newEuler = Vector3.zero;
        if (transform.localEulerAngles.y == 180f)
            newEuler.y = 180f;
        newEuler.z = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;

        dashEff.transform.localEulerAngles = newEuler;

        StartCoroutine(DashEffFade());

        Vector3 prevPos = transform.position - Vector3.up * 0.5f;

        Vector3 newPos = transform.position + dirVec * dashCharging * 2.5f - Vector3.up * 0.5f;
        
        if(dashCharging > 1.0f)
            StartCoroutine(IEDashMotion(prevPos, newPos));

        dashCharging = 0f;
        canDash = false;
        Invoke("DashReset", 0.1f);

        DashAttack(prevPos, newPos);
    }

    void DashReset()
    {
        canDash = true;
    }

    void Update () {
        PlayerManager.GetInstance().playTime += Time.deltaTime;


        if(PlayerManager.GetInstance().playerFeverGauge >= 100f && !PlayerManager.GetInstance().isFeverTime)
        {
            PlayerManager.GetInstance().isFeverTime = true;
            fever.gameObject.SetActive(true);
            fever.StartAni(1.0f);
            back.SetActive(true);
            PlayerEffectSoundManager.Instance.PlaySkill_Fever();

        }

        if (PlayerManager.GetInstance().isFeverTime)
            PlayerManager.GetInstance().playerFeverGauge -= Time.deltaTime * 20f;
        if (PlayerManager.GetInstance().playerFeverGauge <= 0.0f)
        {
            PlayerManager.GetInstance().playerFeverGauge = 0.0f;
            PlayerManager.GetInstance().isFeverTime = false;
        }

        // Looking Direction
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.localPosition.x)
            transform.localEulerAngles = Vector3.up * 180f;
        else
            transform.localEulerAngles = Vector3.zero;



        // Movement
        float h = Input.GetAxis("Horizontal"),
            v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0)
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);


        if (Input.GetMouseButton(1) && canDash)
        {
            dashCharging = Mathf.Clamp(dashCharging + Time.deltaTime * 2, 0.0f, 4.0f);
        }
        else if (Input.GetMouseButtonUp(1) && canDash && (playerSkill.coolTimes[3] < 0.01f || PlayerManager.GetInstance().isFeverTime))
        {
            Dash();
        }

        Vector3 movement = transform.position + new Vector3(h * speed, v * speed, 0.0f);

        movement.x = Mathf.Clamp(movement.x, -14f, 14f);
        movement.y = Mathf.Clamp(movement.y, -11f, 4.35f);

        transform.position = movement;
    }

    void SpeedReset()
    {
        canDash = true;
    }
}
