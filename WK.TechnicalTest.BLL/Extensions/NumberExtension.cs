using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.TechnicalTest.BLL.Extensions
{
    public static class NumberExtension
    {
        public static string ToMoneyString(this decimal value)
        {
            NumberFormatInfo varFormatNum = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            varFormatNum.NumberDecimalSeparator = ",";
            varFormatNum.NumberGroupSeparator = ".";

            return value.ToString("N2", varFormatNum);
        }
    }
}
