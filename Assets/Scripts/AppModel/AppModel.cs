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

            /*for (int index = 0; index < Wallet.Instance.Currencies; index++) {

                CurrencyFormat currencyFormat = new CurrencyFormat();

                SaveDataState.SaveData.currencies.Add(currencyFormat);
            }*/
        }

        public void LoadSavedState()
        {
            
        }
    }
}
