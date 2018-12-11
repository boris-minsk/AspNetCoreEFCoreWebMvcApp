using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataReader : IDataReader
    {
        private const string Header = "Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color";

        public IEnumerable<string> ReadLines(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (currentLine.IndexOf(Header, StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        yield return currentLine;
                    }
                }
            }
        }

        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return "No file exist";

            string[] readText = ReadLines(filePath).ToArray();
            StringBuilder builder = new StringBuilder();
            foreach (string s in readText)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }
    }
}
