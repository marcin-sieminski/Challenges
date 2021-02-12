using System;

namespace Base64Converter
{
    public class Program
    {
        public static void Main()
        {
            var runAgain  = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose an option: \n1. Encode text \n2. Encode binary file \n3. Exit");
                var option = Console.ReadKey();
                Console.WriteLine();

                switch (option.KeyChar)
                {
                    case '1':
                        EncodeDecodeText();
                        break;
                    case '2':
                        EncodeDecodeBinaryFile();
                        break;
                    default:
                        runAgain = false;
                        break;
                }
            } while (runAgain);
        }

        private static void EncodeDecodeText()
        {
            Console.Clear();
            Console.WriteLine("Enter a text to encode (Base64):");
            var textToEncode = Console.ReadLine();

            var encodedText = Base64Converter.ConvertTextToBase64(textToEncode);
            var decodedText = Base64Converter.ConvertTextFromBase64(encodedText);

            Console.WriteLine("\nText to encode:");
            Console.WriteLine(textToEncode);
            Console.WriteLine("\nEncoded text (Base64):");
            Console.WriteLine(encodedText);
            Console.WriteLine("\nDecoded text:");
            Console.WriteLine(decodedText);

            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
        }

        private static void EncodeDecodeBinaryFile()
        {
            Console.Clear();
            Console.WriteLine("Enter an input file name to encode (Base64):");
            var inputFileName = Console.ReadLine();

            var encodedFileName = inputFileName + ".txt";
            var decodedFileName = "decoded_" + inputFileName;

            Base64Converter.ConvertFileToBase64(inputFileName, encodedFileName);
            Base64Converter.ConvertFileFromBase64(encodedFileName, decodedFileName);

            Console.WriteLine("\nFile successfully encoded.");

            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
        }
    }
}
