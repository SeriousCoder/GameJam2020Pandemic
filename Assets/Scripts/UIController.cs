using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Text _textHP;
    private Text _textCharge;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        var _panel = transform.Find("Canvas").transform.Find("Panel");
        _textHP = _panel.Find("TextHP").GetComponentInChildren<Text>();
        _textCharge = _panel.Find("TextCharge").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _textHP.text = "HP: " + _playerController.GetCurrentHP();
        _textCharge.text = "Charge: " + _playerController.GetCurrentCharge();
    }
}
