using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using System;

namespace Manager.LeaderBoard.Communication
{
    public struct SLeader
    {
        public string Name;
        public int Score;
        public SLeader(string name, int score)
        {
            Name = name; Score = score;
        }
    }
    public class LeaderBoardManager : MonoBehaviour
    {
        public static LeaderBoardManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
                EventHub.Event_StartBallGameLevel += OnStartBallGame;
                EventHub.Event_StartScrollerLevel += OnStartScrollGame;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        readonly private string _scrollerId = "scrollerBoard";
        readonly private string _ballGameId = "ballGame";
        string _currentID = "scrollerBoard";

        private Action<SLeader[]> _returnLeaderBoard;

        private void OnStartBallGame()
        {
            _currentID = _ballGameId;
        }

        private void OnStartScrollGame()
        {
            _currentID = _scrollerId;
        }

        private void Initialize()
        {
            LootLockerSDKManager.StartGuestSession("player", (response) =>
            {
                if (response.success)
                {
                    Debug.Log("ReachDataServer");
                }
                else
                {
                    Debug.Log("Did Not Reach data server");
                }
            });
        }

        public void SubmitScore(SLeader leader)
        {
            LootLockerSDKManager.SubmitScore(leader.Name, leader.Score, _currentID, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("submited score");
                }
                else
                {
                    Debug.Log("failed to submit score");
                }
            });
        }

        public void GetLeaderBoard(Action<SLeader[]> returnLeaderBoard)
        {
            _returnLeaderBoard = returnLeaderBoard;
            GetBoard();
        }

        private void GetBoard()
        {
            LootLockerSDKManager.GetScoreList(_currentID, 10, 0, (response) =>
            {
                if (response.success)
                {
                    LootLockerLeaderboardMember[] members = response.items;
                    Debug.Log(members.Length);
                    SLeader[] leader = new SLeader[10];
                    for (int i = 0; i < 10; i++)
                    {
                        leader[i].Name = response.items[i].member_id;
                        leader[i].Score = response.items[i].score;
                    }
                    _returnLeaderBoard(leader);
                }
                else
                {
                    Debug.Log("Failed to Get LeaderBoard");
                }
            });
        }
    }
}
