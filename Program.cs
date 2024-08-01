using Ficheiros.Entities;
using System.Globalization;


try
{
    Console.WriteLine("Please input a full path");
    string sourcePath = Console.ReadLine();

    Path.GetFullPath(sourcePath); // Obtém o caminho completo para garantir que o sourcePath seja válido

    string newFolder = Path.GetDirectoryName(sourcePath) + "\\out"; // Obtém o diretório pai de um caminho.

    Directory.CreateDirectory(newFolder); // Cria um diretório e toda a sua hierarquia se necessário.

    newFolder += "\\summary.csv"; // novo arquivo que conterá somente o ProductName e valor total

    string[] lines = File.ReadAllLines(sourcePath);
    FileInfo file = new FileInfo(newFolder);

    using (StreamWriter sw = file.CreateText()) {

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                string produtoName = fields[0];
                double price = double.Parse(fields[1],CultureInfo.InvariantCulture);
                int qte = int.Parse(fields[2]);
                
                Product prod = new Product(produtoName, price, qte);
                
                sw.WriteLine(produtoName + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                
            }
        }
}
catch(IOException e) 

{
    Console.WriteLine("Error!");
    Console.WriteLine(e.Message);
}