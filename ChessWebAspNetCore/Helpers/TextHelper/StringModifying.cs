using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers.TextHelper
{
    public static class StringModifying
    {
        public static string GetStringWithEmptyCharacters(string value,int neededLength)
        {
            StringBuilder stringBuilder = new StringBuilder(neededLength);
            int initialWhiteCharacters = (neededLength - value.Length) / 2;
            for (int i = 0; i < initialWhiteCharacters; i++)
            {
                stringBuilder.Append(" ");
            }
            for (int i = initialWhiteCharacters , j = 0; i < neededLength; i++ , j++)
            {
                if (j < value.Length)
                {
                    stringBuilder.Append(value[j]);
                }
                else
                {
                    stringBuilder.Append(" ");
                }
            }
            return stringBuilder.ToString();
        }
        public static string ConcadinateWordsLikeTableRow(int columnLengt ,params string[] words)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string item in words)
            {
                stringBuilder.Append(GetStringWithEmptyCharacters(item,columnLengt));
            }
            return stringBuilder.ToString();
        }
    }
}
