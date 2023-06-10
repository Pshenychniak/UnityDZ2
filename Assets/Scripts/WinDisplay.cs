using TMPro;
using UnityEngine;

public class WinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private Player _player;


    private void OnEnable()
    {
        _player.CoinRemove += PlayerOnCoinRemove;
    }
    private void OnDisable()
    {
        _player.CoinRemove -= PlayerOnCoinRemove;
    }

    private void PlayerOnCoinRemove(int coinsCount)
    {
        if (coinsCount == 0)
        {
            _winText.gameObject.SetActive(true);
        }
    }
}
