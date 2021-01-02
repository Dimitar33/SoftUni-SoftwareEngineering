using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../", $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\zippp.zip");

            ZipFile.ExtractToDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\zippp.zip", $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\extract");
        }
    }
}
