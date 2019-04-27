using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FeverDisplayController : Singleton<FeverDisplayController> {

    public GameObject FeverContainer;
//    public Animation FeverAnimation;
    public Animator feverAnimator;
    private const string animName = "FeverAnimation";


    private void Start()
    {
        SubscribeFeverData();
    }

    public void SubscribeFeverData()
    {
        PlayDataManager.Instance.SubscribeFeverGazeUpdate(DetectFeverStart);
        PlayDataManager.Instance.ResetFeverGaze();
    }

    void DetectFeverStart(float feverGaze)
    {
        if (feverGaze >= 1)
        {
            StartPlayFever();

        }

    }

    public void StartPlayFever()
    {
        StartCoroutine(PlayFever());
    }

    public IEnumerator PlayFever()
    {
        ShowFever();
        yield return new WaitForSeconds(1);
        EndFever();
    }

    public void ShowFever()
    {
        FeverContainer.SetActive(true);
        PlayFeberAnimation();
    }

    public void EndFever()
    {
        FeverContainer.SetActive(false);
    }

    public void PlayFeberAnimation()
    {
        feverAnimator.SetTrigger("start");
    }
}
