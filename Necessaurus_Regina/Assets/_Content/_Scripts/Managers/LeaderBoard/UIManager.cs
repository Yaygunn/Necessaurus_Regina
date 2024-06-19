using Manager.LeaderBoard.Communication;
using TMPro;
using UnityEngine;

namespace Manager.LeaderBoard.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UýElements")]
        [SerializeField] private TextMeshProUGUI[] _names;
        [SerializeField] private TextMeshProUGUI[] _scores;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _newRecordEntry;
        [SerializeField] private TextMeshProUGUI _playerScoreText;

        private int _maxNameSize { get; } = 15;

        private string _playerName; 

        private int _score;

        [Header("testing")]
        [SerializeField] bool Set;
        [SerializeField] int Score;


        private void Update()
        {
            if (Set)
            {
                Set = false;
                GameOverPlayerScore(Score);
            }
        }

        private void GameOverPlayerScore(int score)
        {
            _score = score;
            _playerScoreText.text = score.ToString();
            _newRecordEntry.SetActive(false);
            LeaderBoardManager.Instance.GetLeaderBoard(GetLeaderBoard);
        }

        private void GetLeaderBoard(SLeader[] leaders)
        {
            for(int i = 0; i < 10; i++)
            {
                _names[i].text = leaders[i].Name;
                _scores[i].text = leaders[i].Score.ToString();
            }
            if (_score > leaders[9].Score)
            {
                _newRecordEntry.SetActive(true);
            }
            else
            {
                _newRecordEntry.SetActive(false);
            }
        }
        public void HighScoreSubmit()
        {
            LeaderBoardManager.Instance.SubmitScore(new SLeader(_playerName, _score));
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
        }
    }
}
