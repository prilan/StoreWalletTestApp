using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WalletUtility;

namespace MainApp
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] TMP_Text coinsText;
        [SerializeField] Button coinsIncrementButton;
        [SerializeField] Button coinsZeroButton;

        [SerializeField] TMP_Text crystsalsText;
        [SerializeField] Button crystsalsIncrementButton;
        [SerializeField] Button crystsalsZeroButton;

        private void Awake()
        {
            coinsIncrementButton.onClick.AddListener(OnCoinsIncrementnButtonClick);
            coinsZeroButton.onClick.AddListener(OnCoinsZeroButtonClick);

            crystsalsIncrementButton.onClick.AddListener(OnCrystsalsIncrementnButtonClick);
            crystsalsZeroButton.onClick.AddListener(OnCrystsalsZeroButtonClick);

            Initialize();
        }

        private void Initialize()
        {
            Wallet.Instance.CreateCurrency(CurrencyTypeUtility.GetCurrencyByCurrencyType(CurrencyType.Coins));
            Wallet.Instance.CreateCurrency(CurrencyTypeUtility.GetCurrencyByCurrencyType(CurrencyType.Crystals));
        }

        private void OnCoinsIncrementnButtonClick()
        {
            ActionWithCurrency(CurrencyType.Coins, coinsText, Wallet.Instance.IncrementCurrency);
        }

        private void OnCoinsZeroButtonClick()
        {
            ActionWithCurrency(CurrencyType.Coins, coinsText, Wallet.Instance.ZeroCurrency);
        }
        
        private void OnCrystsalsIncrementnButtonClick()
        {
            ActionWithCurrency(CurrencyType.Crystals, crystsalsText, Wallet.Instance.IncrementCurrency);
        }

        private void OnCrystsalsZeroButtonClick()
        {
            ActionWithCurrency(CurrencyType.Crystals, crystsalsText, Wallet.Instance.ZeroCurrency);
        }

        private void ActionWithCurrency(CurrencyType currencyType, TMP_Text currencyText, Action<string> action)
        {
            string currencyString = CurrencyTypeUtility.GetCurrencyByCurrencyType(currencyType);
            action(currencyString);
            Currency currency = Wallet.Instance.GetCurrency(currencyString);
            if (currency != null)
            {
                UpdateText(currencyText, currency.CurrencyValue);
            }

            AppModel.Instance.UpdateDataState();
            SaveStateManager.Instance.SaveSystem.SaveDataState(AppModel.Instance.SaveDataState);
        }

        private void UpdateText(TMP_Text targetText, int value)
        {
            targetText.text = value.ToString();
        }
    }
}
