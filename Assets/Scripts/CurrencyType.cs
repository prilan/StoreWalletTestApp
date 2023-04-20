using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public enum CurrencyType
    {
        Coins,
        Crystals
    }

    public static class CurrencyTypeUtility
    {
        public static string GetCurrencyByCurrencyType(CurrencyType currencyType)
        {
            return currencyType.ToString();
        }
    }
}
