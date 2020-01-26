using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private Image _livesImg;

    [SerializeField]
    private Sprite[] _livesSprites;

    [SerializeField]
    private GameObject _gameOverText;

    [SerializeField]
    private GameObject _restartText;

    void Start() 
        {
            SetScoreText(0);
            _gameOverText.SetActive(false);
            _restartText.SetActive(false);
        }

        public void SetScoreText(int score)
        {
            _scoreText.SetText("Score: " + score);
        }

        public void UpdateLives(int lives)
        {
            _livesImg.sprite = _liveSprites[lives];

            if (lives < 1)
            {
                GameOverSequence();
            }
        }

        private void GameOverSequence()
        {
            _gameOverText.SetActive(true);
            _restartText.SetActive(true);

            StartCoroutine(GameOverFlickerRoutine());
        }

        IEnumerator GameOverFlickerRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                _gameOverText.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                _gameOverText.SetActive(true);
            }
        }
}
