using BallGame.Player.Controller;
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
}
