using SaveState;
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

            LoadCurrenciesFromSavedState();
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
            if (currency != null) {
                UpdateText(currencyText, currency.CurrencyValue);
            }

            SaveCurrenciesState();
        }

        private static void SaveCurrenciesState()
        {
            AppModel.Instance.UpdateDataState();
            SaveStateManager.Instance.SaveSystem.SaveDataState(AppModel.Instance.SaveDataState);
        }

        private void LoadCurrenciesFromSavedState()
        {
            if (SaveStateManager.Instance.SaveSystem.HasSaveDataState()) {
                AppModel.Instance.SaveDataState = SaveStateManager.Instance.SaveSystem.LoadDataState();
                foreach (var currencyItem in AppModel.Instance.SaveDataState.SaveData.currencies) {
                    Currency currency = Wallet.Instance.GetCurrency(currencyItem.currencyType);
                    currency.SetValue(currencyItem.value);
                    CurrencyType currencyType = CurrencyTypeUtility.GetEnumValueFromDescription<CurrencyType>(currency.CurrencyName);
                    TMP_Text textMesh = GetTextMeshByCurrencyType(currencyType);
                    UpdateText(textMesh, currency.CurrencyValue);
                }
            }
        }

        private TMP_Text GetTextMeshByCurrencyType(CurrencyType currencyType)
        {
            switch (currencyType) {
                case CurrencyType.Coins:
                    return coinsText;
                case CurrencyType.Crystals:
                    return crystsalsText;
                default:
                    return null;
            }
        }

        private void UpdateText(TMP_Text targetText, int value)
        {
            targetText.text = value.ToString();
        }
    }
}
