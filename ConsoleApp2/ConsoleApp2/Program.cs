using System;
using System.Globalization;
using System.IO;

namespace ConsoleApp2;
class Program
{
    static void Main(string[] args)
    {
        double total = 0;
        string source = @"c:\Users\cezar\source\repos\relatorio.csv";
        Directory.CreateDirectory(@"c:\Users\cezar\source\repos\out");
        string saida = @"c:\Users\cezar\source\repos\out\saida.csv";


        try
        {
            string[] lines = File.ReadAllLines(source);



            using (StreamWriter sw = new StreamWriter(saida))
            {
                foreach (string line in lines)
                {
                string[] linha = line.Split(',');

                string produto = linha[0];
                double preco = double.Parse(linha[1], CultureInfo.InvariantCulture);
                int qntd = int.Parse(linha[2]);

                total = preco * qntd;

                string final = produto + ", " + preco;
                Product prod = new Product(produto, preco, qntd);
                
                    sw.WriteLine(prod);
                }
                total = 0;
            }
        }   
        catch (Exception ex) 
        {
            Console.WriteLine("Erro ocorreu " + ex.Message);
        }       
    }
}



