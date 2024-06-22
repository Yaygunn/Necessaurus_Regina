using BallGame.Player.Controller;
using Component.ObstacleType;
using System;
using UnityEngine;

public static class EventHub 
{
    #region Player Events
    public static event Action<float> Event_MoveSpeed;
    public static void MoveSpeed(float speed)
    {
        Event_MoveSpeed?.Invoke(speed);
    }

    public static event Action<float> Event_MoveSpeedRate;
    public static void MoveSpeedRate(float speed)
    {
        Event_MoveSpeedRate?.Invoke(speed);
    }

    public static event Action Event_PlayerStep;
    public static void PlayerStep()
    {
        Event_PlayerStep?.Invoke();
    }

    public static event Action Event_PlayerJump;
    public static void PlayerJump()
    {
        Event_PlayerJump?.Invoke();
    }

    public static event Action<EObsType> Event_PlayerCollided;
    public static void PlayerCollided(EObsType type)
    {
        Event_PlayerCollided?.Invoke(type);
    }

    #endregion

    #region Ball Events

    public static event Action Event_BallWallHit;
    public static void BallWallHit()
    {
        Event_BallWallHit?.Invoke();
    }

    public static event Action Event_BallBirdHit;
    public static void BallBirdHit()
    {
        Event_BallBirdHit?.Invoke();
    }

    public static event Action Event_BallFloorHit;
    public static void BallFloorHit()
    {
        Event_BallFloorHit?.Invoke();
    }

    public static event Action<E_HitVersions> Event_BallHitPlayer;
    public static void BallHitPlayer(E_HitVersions hitVersion)
    {
        Event_BallHitPlayer?.Invoke(hitVersion);
    }

    #endregion

    #region LevelStart

    public static event Action Event_StartMenu;
    public static void StartMenu()
    {
        Event_StartMenu?.Invoke();
    }

    public static event Action Event_StartScrollerLevel;
    public static void StartScrollerLevel()
    {
        Event_StartScrollerLevel?.Invoke();
    }

    public static event Action Event_StartBallGameLevel;
    public static void StartBallGameLevel()
    {
        Event_StartBallGameLevel?.Invoke();
    }

    #endregion

    #region Score

    public static event Action<int> Event_PlayerScore;
    public static void PlayerScore(int score)
    {
        Event_PlayerScore?.Invoke(score);
    }

    public static event Action<int> Event_PlayerEndGameScore;
    public static void PlayerEndGameScore(int score)
    {
        Event_PlayerEndGameScore?.Invoke(score);
    }

    #endregion

    #region General

    public static event Action<float> Event_ParallaxMove;
    public static void ParallaxMove(float moveAmount)
    {
        Event_ParallaxMove?.Invoke(moveAmount);
    }

    #endregion

    #region UI

    public static event Action Event_UIHower;
    public static void UIHower()
    {
        Event_UIHower?.Invoke();
    }

    public static event Action Event_UIOK;
    public static void UIOK()
    {
        Event_UIOK?.Invoke();
    }

    public static event Action Event_UIBack;
    public static void UIBack()
    {
        Event_UIBack?.Invoke();
    }

    #endregion

    public static event Action Event_StartGame;
    public static void StartGame()
    {
        Event_StartGame?.Invoke();
    }
    public static event Action Event_EndGame;
    public static void EndGame()
    {
        Event_EndGame?.Invoke();
    }
    public static event Action<float> Event_RemainingTime;
    public static void RemainingTime(float time)
    {
        Event_RemainingTime?.Invoke(time);
    }
}
