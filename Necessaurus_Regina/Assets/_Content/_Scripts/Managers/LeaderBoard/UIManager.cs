using Manager.LeaderBoard.Communication;
using TMPro;
using UnityEngine;

namespace Manager.LeaderBoard.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("U�Elements")]
        [SerializeField] private GameObject _boardParent;
        [SerializeField] private TextMeshProUGUI[] _names;
        [SerializeField] private TextMeshProUGUI[] _scores;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _newRecordEntry;
        [SerializeField] private TextMeshProUGUI _playerScoreText;

        [Header("Color")]
        [SerializeField] private Color _newLeaderColor;
        private Color _standartColor;
        private int _maxNameSize { get; } = 12;

        private string _namelessName { get; } = "______";

        private string _playerName; 

        private int _playerScore;

        private int _playerRankInLeaderBoard;

        SLeader[] _leaders;


        private void Start()
        {
            _standartColor = _names[0].color;
            EventHub.Event_PlayerEndGameScore += GameOverPlayerScore;
        }
        private void OnDestroy()
        {
            EventHub.Event_PlayerEndGameScore -= GameOverPlayerScore;
        }

        private void GameOverPlayerScore(int score)
        {
            _playerScore = score;
            _playerScoreText.text = score.ToString();
            _newRecordEntry.SetActive(false);
            LeaderBoardManager.Instance.GetLeaderBoard(GetLeaderBoard);
        }

        private void GetLeaderBoard(SLeader[] leaders)
        {
            _boardParent.SetActive(true);
            _leaders = leaders;
            ResetLastEntryColor();

            if (_playerScore > leaders[9].Score)
            {
                _newRecordEntry.SetActive(true);
                DecideRank();
                SetUIElementColor(_newLeaderColor, _playerRankInLeaderBoard);
                SetUIValuesWithPlayerRank();
            }
            else
            {
                _playerRankInLeaderBoard = 100;
                _newRecordEntry.SetActive(false);
                SetUIValuesWithoutPlayerRank();
            }
        }

        private void DecideRank()
        {
            for(int i = 0;i < 10;i++)
            {
                if (_leaders[i].Score < _playerScore)
                {
                    _playerRankInLeaderBoard = i;
                    return;
                }
            }
            _playerRankInLeaderBoard = 100;
        }

        private void SetUIValuesWithPlayerRank()
        {
            for (int i = 0; i < _playerRankInLeaderBoard; i++)
            {
                SetAnUIValue(_leaders[i], i);
            }
            SetAnUIValue(new SLeader(_namelessName, _playerScore), _playerRankInLeaderBoard);
            for (int i = _playerRankInLeaderBoard + 1; i < 10; i++) 
            {
                SetAnUIValue(_leaders[i - 1], i);
            }
        }
        private void SetUIValuesWithoutPlayerRank()
        {
            for (int i = 0; i < 10; i++)
            {
                SetAnUIValue(_leaders[i], i);
            }
        }
        private void SetAnUIValue(SLeader leader, int index)
        {
            _names[index].text = leader.Name;
            _scores[index].text = leader.Score.ToString();
        }

        private void SetUIElementColor(Color color, int index)
        {
            _names[index].color = color;
            _scores[index].color = color;
        }
        private void ResetLastEntryColor()
        {
            if (_playerRankInLeaderBoard > 9)
                return;

            SetUIElementColor(_standartColor, _playerRankInLeaderBoard);
        }
        public void HighScoreSubmit()
        {
            LeaderBoardManager.Instance.SubmitScore(new SLeader(_playerName, _playerScore));
            _newRecordEntry.SetActive(false);
        }

        public void InputFieldTextChanged()
        {
            string newText = _inputField.text;

            if (newText.Length > _maxNameSize)
            {
                _playerName = newText.Substring(0, _maxNameSize);
                _inputField.text = _playerName;
            }
            else
            {
                _playerName = newText;
            }

            if(_playerRankInLeaderBoard < 10) 
            {
                _names[_playerRankInLeaderBoard].text = _playerName;
            }
        }
    }
}
