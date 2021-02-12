using System;

namespace Base64Converter
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a text to encode (Base64):");
            var textToEncode = Console.ReadLine();

            var encodedText = Base64Converter.ConvertTextToBase64(textToEncode);
            var decodedText = Base64Converter.ConvertTextFromBase64(encodedText);

            Console.WriteLine("\nText to encode:");
            Console.WriteLine(textToEncode);
            Console.WriteLine("Encoded text (Base64):");
            Console.WriteLine(encodedText);
            Console.WriteLine("Decoded text:");
            Console.WriteLine(decodedText);

            //EncodeDecodeBinaryFileExample();

            Console.WriteLine("\nPress enter do exit.");
            Console.ReadLine();
        }

        private static void EncodeDecodeBinaryFileExample()
        {
            const string inputFileName = "sun.png";
            const string encodedFileName = "sun.txt";
            const string decodedFileName = "sun_decoded.png";

            Base64Converter.ConvertFileToBase64(inputFileName, encodedFileName);
            Base64Converter.ConvertFileFromBase64(encodedFileName, decodedFileName);
        }
    }
}
