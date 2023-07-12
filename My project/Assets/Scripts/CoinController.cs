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
            collision.gameObject.GetComponent<PlayerController>().PlayerModel.Score += CoinValue;
            FindAnyObjectByType<LvlController>().GetComponent<LvlController>().UpdateScore();
            Destroy(gameObject);
        }
    }

}
