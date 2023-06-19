using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GameController : MonoBehaviour
{

    public TMP_Text _scoreText;
    public float _score;
    private PlayerLocomotion _player;

    public int _coinScore;
    public TMP_Text _coinText;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!_player._isDead)
        {
            //esta variavel contabiliza a pontuação por tempo
        _score += Time.deltaTime * 1f;
        //esta variavel ela aredonda o valor
        _scoreText.text = Mathf.Round(_score).ToString() + "m";
        }
    }

    public void AddCoin()
    {
        _coinScore ++;
        _coinText.text = _coinScore.ToString();
    }
}
