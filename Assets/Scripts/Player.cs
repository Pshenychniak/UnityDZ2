using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    public event UnityAction<int> CoinPickUp;
    public event UnityAction<int> CoinRemove;
    public event UnityAction<int> AntiCoinPickUp;
    public event UnityAction<int> AntiCoinRemove;

   
    private List<Coin> _coins;

    private void Start()
    {
        _coins = new List<Coin>(FindObjectsOfType<Coin>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _score+= coin.Value;
            _coins.Remove(_coins[_coins.Count-1]);

            CoinPickUp?.Invoke(_score);
            CoinRemove?.Invoke(_coins.Count);
        }
        if (other.gameObject.TryGetComponent(out AntiCoin antiCoin))
        {
            antiCoin.gameObject.SetActive(false);
            _score-= antiCoin.Value;

            AntiCoinPickUp?.Invoke(_score);
            AntiCoinRemove?.Invoke(_coins.Count);
        }
    }
}
