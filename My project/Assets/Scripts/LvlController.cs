using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    private GameObject _player;
    private Canvas _canvas;
    private TextMeshProUGUI _scoreText;
    private RawImage _boxesPicture;
    private bool _canHidePictuire;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>().gameObject;
        _canvas = FindAnyObjectByType<Canvas>();
        _scoreText = _canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _boxesPicture = _canvas.transform.GetChild(1).GetComponent<RawImage>();
        _canHidePictuire = false;
    }

    private void Update()
    {
        if(_boxesPicture.gameObject.activeSelf && Input.anyKey && _canHidePictuire)
        {
            _boxesPicture.gameObject.SetActive(false);
        }
    }

    public void UpdateScore()
    {
        _scoreText.text = "Score: " + _player.GetComponent<PlayerController>().PlayerModel.Score;
    }

    public void ShowPicture()
    {
        _boxesPicture.gameObject.SetActive(true);
        Invoke("HidePicture", 2f);
    }

    public void HidePicture()
    {
        _canHidePictuire = true;
    }
}
