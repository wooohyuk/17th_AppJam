using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDataManager: MonoBehaviour
{



    public static PlayDataManager Instance;
    void Awake()
    {
        Instance = this;

    }


    private float _playtime;
    public float Playtime
    {
        get { return _playtime; }
        set
        {
            if (OnPlaytimeUpdate != null) OnPlaytimeUpdate(value);
            _playtime = value;
        }
    }

    private int _gameScore;
    public int GameScore
    {
        get { return _gameScore; }
        set
        {
            if (OnGameScoreUpdate != null) OnGameScoreUpdate(value);

            _gameScore = value;
        }
    }

    private float _feverGage;

    public float feverGage
    {
        get { return _feverGage; }
        set
        {
            _feverGage = value;
            OnFeverGageUpdate(value);
        }
    }

    public Action<float> OnPlaytimeUpdate;
    public Action<int> OnGameScoreUpdate;
    public Action<float> OnFeverGageUpdate;
//    public void AddOn


    public void SubscribeOnPlaytimeUpdated(Action<float> action)
    {
        OnPlaytimeUpdate += action;
    }


    public void SubscribeOnGamescoreUpdated(Action<int> action)
    {
        OnGameScoreUpdate += action;
    }

    public void SubscribeFeverGazeUpdate(Action<float> action)
    {
        OnFeverGageUpdate += action;
    }

    public void ResetFeverGaze()
    {
        feverGage = 0;
    }

    public void AddFever(float feverToAdd)
    {
        feverGage += feverToAdd;
    }



    private void Update()
    {
        Playtime += Time.deltaTime;
        GiveTimeScoreBonus();
    }


    private float lastTimeScoreBonus;
    private int BonusInterval = 15;
    public void GiveTimeScoreBonus()
    {
        if (Playtime > lastTimeScoreBonus + BonusInterval)
        {
            lastTimeScoreBonus = Playtime;
            GameScore = (int)(GameScore* 1.5);
        }
    }

    public void UpdateGameScore(int newScore)
    {
        GameScore += newScore;
    }

    public void AddGameScore(int scoreToAdd)
    {
        GameScore += scoreToAdd;
    }





}
