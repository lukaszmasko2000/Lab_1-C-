using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var inputFilePath = @"..\input.csv";        //plik do odczytu
            var outputFilePath = @"..\output.html";     //plik do zapisu
            
            if (!File.Exists(inputFilePath))   //warunek czy plik istnieje
            {
                Console.WriteLine($"Plik {inputFilePath} nie istnieje.");   
                return;                                                     
            }

            var lines = File.ReadAllLines(inputFilePath);   //wczytywanie wszystkich plików do lines

            if (lines.Length == 0)  //warunek czy plik jest pusty
            {
                Console.WriteLine($"Plik {inputFilePath} jest pusty."); 
                return; 
            }


            //dodanie szkieletu html do zmiennej htmlContent
            var
            htmlContent = "" +
            "<!DOCTYPE html>" +
            "\n<html>" +
            "\n<head>" +
            "\n" +
            "<style>\n" +
            "table " +
            "{ " +
            "border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; " +
            "}\n" +
            "th, td " +
            "{ " +
            "border: 1px solid #dddddd; text-align: left; padding: 8px; " +
            "}\n" +
            "th { " +
            "background-color: #04AA6D; color: white; " +
            "}\n" +
            ".even { " +
            "background-color: #f2f2f2; " +     //klasa z innym kolorem
            "}\n" +
            ".odd { " +
            "background-color: #ffffff; " +     //klasa z innym kolorem
            "}\n" +
            "</style>\n" +
            "</head>\n" +
            "<body>\n" +
            "<table>\n";

            var headerColumns = lines[0].Split(';');       //wykrywanie separatora, może być jako "," , "." 
            htmlContent += "<tr>\n";
            
            foreach (var column in headerColumns) {         //nagłówek tabelki
                htmlContent += $"<th>{column.Trim()}</th>\n";    
            }
            htmlContent += "</tr>\n";

            for (var i = 1; i < lines.Length; i++)      //dodanie pozostałych danych do poniższych kolumn
            {
                var columns = lines[i].Split(';');
                var rowClass = (i % 2 == 0) ? "even" : "odd";   //jeśli parzyste to even, jeśli nieparzyste to odd 

                htmlContent += $"<tr class=\"{rowClass}\">\n";  //dodanie odpowieniej zmiennej klasy żeby zmienić kolor
                foreach (string column in columns)
                {
                    htmlContent += $"<td>{column.Trim()}</td>\n";   //wypisanie danych do danego wiersza
                }
                htmlContent += "</tr>\n";   
            }
            htmlContent += 
                "</table>\n<" +
                "/body>\n" +
                "</html>";
            File.WriteAllText(outputFilePath, htmlContent);    //zapisanie danych htmlContent do outputFilePath
            Console.WriteLine($"Konwersja zakończona! Wynik zapisano w pliku: {outputFilePath}");
        }
    }
}
