using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net;

namespace TestLibrary.Common
{
    /// <summary>
    /// 資料驗證
    /// </summary>
    public class Validations
    {
        /// <summary>
        /// 驗證數字
        /// </summary>
        /// <param name="strNumber">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumber(string strValue)
        {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strValue);
        }

        /// 驗證日期
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsDate(string strDate)
        {
            DateTime dt;
            return DateTime.TryParse(strDate, out dt);
        }

        /// <summary>
        /// 驗證非負整數(正整數 & 0)
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUnMinusInt(string strValue)
        {
            return new Regex(@"\d+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證正整數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsPlusInt(string strValue)
        {
            return new Regex("^[0-9]*[1-9][0-9]*$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證非正整數 (負整數 & 0) 
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUnPlusInt(string strValue)
        {
            return new Regex(@"^((-\d+)|(0+))$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證負整數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsMinusInt(string strValue)
        {
            return new Regex(@"\d+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證整數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsInt(string strValue)
        {
            return new Regex(@"^-?\d+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證非負浮點數 (正浮點數 + 0)
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUnMinusFloat(string strValue)
        {
            return new Regex(@"^\d+(\.\d+)?$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證正負浮點數 (正、負浮點數 及 0)
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsPlusMinusFloat(string strValue)
        {
            return new Regex(@"^-?\d+(\.\d+)?$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證正浮點數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsPlusFloat(string strValue)
        {
            return new Regex(@"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證非正浮點數 (負浮點數 & 0)
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUnPlusFloat(string strValue)
        {
            return new Regex(@"^((-\d+(\.\d+)?)|(0+(\.0+)?))$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證負浮點數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsMinusFloat(string strValue)
        {
            return new Regex(@"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證浮點數
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsFloat(string strValue)
        {
            return new Regex(@"^(-?\d+)(\.\d+)?$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由26個英文字母組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsLetter(string strValue)
        {
            return new Regex("^[A-Za-z]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由中文組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsChinese(string strValue)
        {
            return new Regex(@"^[\u4E00-\u9FA5\uF900-\uFA2D]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由26個英文字母的大寫組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUpperLetter(string strValue)
        {
            return new Regex("^[A-Z]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由26個英文字母的小寫組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsLowerLetter(string strValue)
        {
            return new Regex("^[a-z]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由數字和26個英文字母組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumericOrLetter(string strValue)
        {
            return new Regex("^[A-Za-z0-9]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由數字組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumeric(string strValue)
        {
            return new Regex("^[0-9]+$").IsMatch(strValue);
        }
        /// <summary>
        /// 驗證由數字和26個英文字母或中文組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumericOrLetterOrChinese(string strValue)
        {
            return new Regex(@"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證由數字、26個英文字母或者下劃線組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsNumericOrLetterOrUnderline(string strValue)
        {
            return new Regex(@"^\w+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證Email
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsEmail(string strValue)
        {
            return new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證URL
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsUrl(string strValue)
        {
            return new Regex(@"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證電話號碼
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsTelephone(string strValue)
        {
            return new Regex(@"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證手機號碼
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsMobile(string strValue)
        {
            return new Regex("^0{0,1}13[0-9]{9}$").IsMatch(strValue);
        }

        /// <summary>
        /// 驗證IP
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>是否通過驗證</returns>
        public static bool IsIP(string strValue)
        {
            return new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$").IsMatch(strValue);
        }

    }
}