using System;
using System.Collections.Generic;
using System.IO;

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
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    // Search, case insensitive, if the currentLine contains the searched keyword
                    if (currentLine.IndexOf(Header, StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        yield return currentLine;
                    }
                }
            }
        }
    }
}
