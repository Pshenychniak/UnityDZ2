using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinPickUp += OnCoinPickUp;
        _player.AntiCoinPickUp += OnCoinPickUp;
    }
    private void OnDisable()
    {
        _player.CoinPickUp -= OnCoinPickUp;
        _player.AntiCoinPickUp -= OnCoinPickUp;
    }
    private void OnCoinPickUp(int scoreValue)
    {
        _scoreText.text = scoreValue.ToString();
    }
}
