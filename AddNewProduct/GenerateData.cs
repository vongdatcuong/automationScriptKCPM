using System;
using System.Text;
using System.Collections;
using AutomationTest;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace Utils
{
    class GenerateData
    {
        private Random random;
        public GenerateData()
        {
            random = new Random();
        }

        public string randomString(int length, int type)
        {
            // Type: 0 Capital, 1: UPPER CASE, 2: lower case
            var builder = new StringBuilder();
            char offset = (type == 1) ? 'A' : 'a';
            const int range = 26;
            for (int i = 0; i < length; i++)
            {
                var randomChar = (char)random.Next(offset, offset + range);
                builder.Append(randomChar);
            }
            if (type == 1)
            {
                return builder.ToString().ToUpper();
            } else
            {
                string str = builder.ToString();
                if (type == 0)
                {
                    return char.ToUpper(str[0]) + str.Substring(1);
                }
                return str;
            }
        }

        public int randomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        // Test Sample for Automation Script
        public ArrayList automationScriptData(int size)
        {
            string[] stalls = { "Giày 2020", "điện thoại", "Nón", "Laptop", "Thắt lưng", "Thời trang" };
            string[] brands = { "Adidas", "New Balance", "Nike", "Puma", "Magie", "Jordan" };
            string[] images = { @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\AddNewProduct\AddNewProduct\images\Giay_1.jpg",
                @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\AddNewProduct\AddNewProduct\images\Giay_2.jpg" ,
                @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\AddNewProduct\AddNewProduct\images\Giay_3.jpg" ,
                @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\AddNewProduct\AddNewProduct\images\Giay_4.jpg" ,
                @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\AddNewProduct\AddNewProduct\images\Giay_5.jpg" };
            ArrayList data = new ArrayList(size);
            for (int i = 0; i < size; i++)
            {
                data.Add(new Item(
                    stalls[randomNumber(0, stalls.Length - 1)],
                    brands[randomNumber(0, brands.Length - 1)],
                    randomString(10, 0),
                    randomNumber(1, 10000).ToString(),
                    randomNumber(1, 10000).ToString(),
                    randomNumber(1, 10000).ToString(),
                    randomString(300, 0),
                    images[randomNumber(0, images.Length - 1)]
                ));
            }
            return data;    // Tra ve List Item
        }

        // Generate excel file for Jmeter
        public void generateExcelJmeter(int sampleSize, int keywordSize,  string filePath)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Sheet1";
            dt.Columns.Add("keywords", typeof(string));
            for (int i = 1; i <= sampleSize; i++)
            {
                dt.Rows.Add(randomString(keywordSize, 2));
                dt.AcceptChanges();
            }
            using (XLWorkbook wb = new XLWorkbook(filePath))
            {
                //Add DataTable in worksheet  
                wb.Worksheet(1).Cell(1, 1).InsertData(dt.Rows);
                wb.Save();
            }
        }

        private void File(byte[] v1, string v2, object fileName)
        {
            throw new NotImplementedException();
        }
    }
}
