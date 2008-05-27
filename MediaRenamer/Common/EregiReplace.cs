using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace MediaRenamer.Common
{
    public class Eregi
    {
        /// <summary>
        /// Replace regular expression in string
        /// </summary>
        /// <param name="pat">Search pattern</param>
        /// <param name="newStr">New String. \\0..\\n for found values</param>
        /// <param name="input">Inputstring</param>
        /// <returns>modified String</returns>
        public static String replace(String pat, String newStr, String input)
        {
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.None);
            Match m = null;
            String newStrTmp = "";
            while (true)
            {
                m = reg.Match(input);
                newStrTmp = newStr;
                if (m.Success)
                {
                    for (int i = 0; i < m.Groups.Count; i++)
                    {
                        newStrTmp = newStrTmp.Replace("\\" + i, m.Groups[i].Captures[0].Value);
                    }
                    input = input.Replace(m.Groups[0].Captures[0].Value, newStrTmp);
                }
                else break;
            }
            return input;
        }
    }
}
