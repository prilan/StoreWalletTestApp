using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public enum CurrencyType
    {
        [Description("Coins")]
        Coins,
        [Description("Crystals")]
        Crystals
    }

    public static class CurrencyTypeUtility
    {
        public static string GetCurrencyByCurrencyType(CurrencyType currencyType)
        {
            return currencyType.ToString();
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis) {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            throw new Exception("Not found");
        }
    }
}
