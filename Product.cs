using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace exec_cap13_fix_2
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        
        List<Product> List = new List<Product>();

        public Product()
        {
        }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double Total()
        {
           return Price * Quantity;
        }

        public void Read()
        {
            string filePath = @"C:\temp\myfolder\file.csv";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string s in lines)
            {
                string[] x = s.Split(',');
                string name = x[0];
                double price = double.Parse(x[1], CultureInfo.InvariantCulture);
                int quantity = int.Parse(x[2]);
                List.Add(new Product(name, price, quantity));
            }
        }

        public void Write()
        {
            string targetPath = @"C:\temp\myfolder\out";
            string targetFile = @"C:\temp\myfolder\out\summary.csv";
            Directory.CreateDirectory(targetPath);
            File.CreateText(targetFile).Close();
            foreach (Product product in List)
            {
                File.AppendAllText(targetFile, product.ToString());
                File.AppendAllText(targetFile, "\n");
            }
        }

        public override string ToString()
        {
            return Name + ", " + Total().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
