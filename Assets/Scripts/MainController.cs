using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] Button coinsIncrementButton;
    [SerializeField] Button coinsZeroButton;

    [SerializeField] Button crystsalsIncrementButton;
    [SerializeField] Button crystsalsZeroButton;

    private void Awake()
    {
        coinsIncrementButton.onClick.AddListener(OnCoinsIncrementnButtonClick);
        coinsZeroButton.onClick.AddListener(OnCoinsZeroButtonClick);
    }

    private void OnCoinsIncrementnButtonClick()
    {
        
    }

    private void OnCoinsZeroButtonClick()
    {

    }
}
