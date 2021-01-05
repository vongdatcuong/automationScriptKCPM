using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using AutomationTest;

namespace AddNewProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateData genData = new GenerateData();  // Tao class generate data
            ArrayList data = genData.automationScriptData(2);   // Tao bo test sample tu genData
            AddNewProductTest addNewProduct = new AddNewProductTest();  // Goi ham Test
            addNewProduct.SetUp(0, "toanhuuvuong.com@gmail.com", "1234567");    // Set (Login) voi tai khoan Admin
            foreach (Item item in data)
            {
                addNewProduct.addNewProduct(item);  // Chay Test voi moi item trong bo sample test
            }
            genData.generateExcelJmeter(100, 10, @"C:\Users\vdcuo\OneDrive\Desktop\Nam 4\Kiem thu phan mem\FinalTerm\PerformanceScript\data.xlsx");
        }
    }
}
