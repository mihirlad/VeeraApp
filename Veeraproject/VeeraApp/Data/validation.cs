using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MihirValid
{
    class validation
    {
        public static bool isPANNo(string inputNumber)
        {
            Regex regex = new Regex("[a-zA-Z]{5}\\d{4}[a-zA-Z]{1}");

            if (regex.IsMatch(inputNumber) && inputNumber.Length == 10)
                return (true);
            else
                return (false);
        }
        public static bool InToNumber(string inputNumber)
        {
            Regex regex = new Regex(@"^[0-9][0-9]*(\[0-9]*)?$");///"^([0-9]{11})$");
            Regex regex1 = new Regex(@"^[0-9][0-9]*\,([0-9]*)?$");
            Regex regex2 = new Regex(@"^[0-9][0-9]*(\.[0-9]*)?$");
            if (regex.IsMatch(inputNumber) && inputNumber.Length < 20)
                return (true);
            else if (regex1.IsMatch(inputNumber) && inputNumber.Length < 20)
                return (true);
            else
                return (false);
        }
        public static string chkCamelChars(string input)
        {

            var rx = new System.Text.RegularExpressions.Regex(@"(?<=\w)\w");
            var newString = rx.Replace(input, new MatchEvaluator(m => m.Value.ToLowerInvariant()));
            return newString;
        }
        public static bool chkSpecialChars(string input)
        {
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
            for (var i = 0; i < input.Length; i++)
            {
                if (iChars.IndexOf(input[i]) != -1)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool chkSpecialCharsWithoutDot(string input)
        {
            var iChars = "!@#$%^&*()+=-[]\\\';{}|\":<>?";
            for (var i = 0; i < input.Length; i++)
            {
                if (iChars.IndexOf(input[i]) != -1)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool chkSpecialCharsAddress(string input)
        {
            var iChars = "!@#$%^&*()+=-[]\\\';{}|\\:<>?";
            for (var i = 0; i < input.Length; i++)
            {
                if (iChars.IndexOf(input[i]) != -1)
                {
                    return false;
                }
            }
            return true;
        }
        //|(^\d{1,2}([.]\d{1,2})?)$
        public static bool isyear(string inputNumber)
        {
            Regex regex = new Regex("^([12]{1})([0-9]{3})$");

            if (regex.IsMatch(inputNumber))
                return (true);
            else
                return (false);
        }
        public static bool ispercentage(string inputNumber)
        {
            Regex regex = new Regex("^([0-9]{2})([.]{1})([0-9]{2})$");
            Regex regex1 = new Regex("^([0-9]{2})$");
            Regex regex2 = new Regex("^([0-9]{2})([.]{1})([0-9]{1})$");
            Regex regex3 = new Regex("^([0-9]{1})([.]{1})([0-9]{1})$");
            Regex regex4 = new Regex("^([0-9]{1})([.]{1})([0-9]{1})$");
            Regex regex5 = new Regex("^([0-9]{1})$");
            if (regex.IsMatch(inputNumber))
                return (true);
            else if (regex1.IsMatch(inputNumber))
                return (true);
            else if (regex2.IsMatch(inputNumber))
                return (true);
            else if (regex3.IsMatch(inputNumber))
                return (true);
            else if (regex4.IsMatch(inputNumber))
                return (true);
            else if (regex5.IsMatch(inputNumber))
                return (true);
            else
                return (false);
        }
        public static bool isEmail(string inputEmail)
        {
            //  inputEmail = string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        //public bool phone(string no)
        //{
        //    Regex expr = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
        //    if (expr.IsMatch(no))
        //    {
        //        return true;
        //    }
        //    else return false;
        //}

        public static bool isMobileNumber(string inputNumber)
        {
            Regex regex = new Regex("^([0123456789]{1})([0-9]{9})$");

            if (regex.IsMatch(inputNumber))
                return (true);
            else
                return (false);
        }
        public static bool isPhoneNumber(string inputNumber)
        {
            Regex regex = new Regex("^([0123456789]{1})([0-9]{10})$");

            if (regex.IsMatch(inputNumber))
                return (true);
            else
                return (false);
        }

        public static bool isNumber(string inputNumber)
        {
            Regex regex = new Regex(@"^[0-9][0-9]*(\[0-9]*)?$");///"^([0-9]{11})$");
            Regex regex1 = new Regex(@"^[0-9][0-9]*\,([0-9]*)?$");
            Regex regex2 = new Regex(@"^[0-9][0-9]*(\[0-9]*)?$");
            if (regex.IsMatch(inputNumber) && inputNumber.Length < 15)
                return (true);
            else if (regex1.IsMatch(inputNumber) && inputNumber.Length < 15)
                return (true);
            else
                return (false);
        }

        public static bool isNumberWithoutComa(string inputNumber)
        {
            Regex regex = new Regex(@"^[0-9][0-9]*(\[0-9]*)?$");///"^([0-9]{11})$");

            if (regex.IsMatch(inputNumber) && inputNumber.Length < 15)
                return (true);

            else
                return (false);
        }

        public static bool isFileNumber(string inputNumber)
        {
            Regex regex = new Regex(@"^[0-9][0-9]*(\.[0-9]*)?$");///"^([0-9]{11})$");

            if (regex.IsMatch(inputNumber) && inputNumber.Length < 18)
                return (true);
            else
                return (false);
        }

        public static bool chkChars(string input)
        {
            Regex regex = new Regex(@"^[a-z A-Z]+$");

            if (regex.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static string RSC(string XmlOut)
        {
            string Xml = XmlOut.Replace("&", "&amp;");


            return Xml;
        }
    }
}
