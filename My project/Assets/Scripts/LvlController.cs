using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LvlController : MonoBehaviour
{
    private GameObject _player;
    private Canvas _canvas;
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>().gameObject;
        _canvas = FindAnyObjectByType<Canvas>();
        _scoreText = _canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore()
    {
        _scoreText.text = "Score: " + _player.GetComponent<PlayerController>().PlayerModel.Score;
    }
}
