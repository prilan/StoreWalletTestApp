using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] Button coinsIncrementButton;

    private void Awake()
    {
        coinsIncrementButton.onClick.AddListener(OnCoinsIncrementnButtonClick);
    }

    private void OnCoinsIncrementnButtonClick()
    {
        
    }
}
