using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinModel _coinModel;

    public float CoinValue;
    private void Awake()
    {
        _coinModel = new CoinModel();
        _coinModel.Value = CoinValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerController _player = collision.gameObject.GetComponent<PlayerController>();

            if (this.CompareTag("Coin"))
            {
                _player.PlayerModel.Score += CoinValue;
                FindAnyObjectByType<LvlController>().GetComponent<LvlController>().UpdateScore();
                Destroy(gameObject);
            }
            else
            {
                _player.PlayerModel.Score += CoinValue;
                _player.PlayerModel.BoxCollected++;
                FindAnyObjectByType<LvlController>().GetComponent<LvlController>().UpdateScore();
                if(_player.PlayerModel.BoxCollected >= _player.PlayerModel.NeedBoxes)
                {
                    FindAnyObjectByType<LvlController>().GetComponent<LvlController>().ShowPicture();
                }
                Destroy(gameObject);
            }
        }
    }
}
