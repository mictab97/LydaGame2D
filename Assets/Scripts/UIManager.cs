using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private Image _livesImg;

    [SerializeField]
    private Sprite[] _liveSprites;

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
        // updates the score text in the Canvas UI
        _scoreText.SetText("Score: " + score);
    }

    public void UpdateLives(int lives)
    {
        // update the lives image to match the lives number
        _livesImg.sprite = _liveSprites[lives];

        // if the lives are zero
        // start the game over sequence
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