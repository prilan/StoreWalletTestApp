using DataModel;
using SaveState;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using WalletUtility;

namespace MainApp
{
    public class AppModel : AbstractSingleton<AppModel>
    {
        public SaveDataState SaveDataState = new SaveDataState();

        public void UpdateDataState()
        {
            SaveDataState.SaveData.currencies = new List<CurrencyFormat>();

            foreach (Currency currency in Wallet.Instance.Currencies) {
                CurrencyFormat currencyFormat = new CurrencyFormat();
                currencyFormat.currencyType = currency.CurrencyName;
                currencyFormat.value = currency.CurrencyValue;
                SaveDataState.SaveData.currencies.Add(currencyFormat);
            }
        }

        public void LoadSavedState()
        {
            
        }
    }
}
