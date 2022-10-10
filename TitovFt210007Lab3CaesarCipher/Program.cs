using System;


namespace TitovFt210007Lab3CaesarCipher
{
    internal class Program
    {
        public static string Incode(string mes, string alph, int key)
        {
            char[] charsA = alph.ToCharArray();

            mes.ToLower();
            char[] charsM = mes.ToCharArray();

            //проверка допустимого языка
            for (int i =0; i < charsM.Length; i++)
            {
                if (alph.IndexOf(charsM[i]) == -1)
                {
                    Console.WriteLine("Wrong lang/message has spaces!");
                    return null;
                }
            }

            //поиск позиции символа из сообщенияя
            int n = 0;
            for (int i = 0; i < charsM.Length; i++)
            {
                for (int j = 0; j < charsA.Length; j++)
                {
                    if (j != charsA.Length - 1)
                    {
                        if (charsM[i] == charsA[j])
                        {
                            n = j;
                            break;
                        }
                    }
                }

                //шифрование
                for (int k = key; k > 0; k--)
                {
                    n += 1;
                    if (n > charsA.Length - 1)
                    {
                        n = 0;
                    }
                }

                charsM[i] = charsA[n];

            }

            return new string(charsM);

        }

        public static string Decode(string mes, string alph, int key)
        {
            char[] charsA = alph.ToCharArray();

            mes.ToLower();
            char[] charsM = mes.ToCharArray();

            //проверка допустимого языка
            for (int i = 0; i < charsM.Length; i++)
            {
                if (alph.IndexOf(charsM[i]) == -1)
                {
                    Console.WriteLine("Wrong lang/message has spaces!");
                    return null;
                }
            }


            //поиск позиции символа из сообщенияя
            int n = 0;
            for (int i = 0; i < charsM.Length; i++)
            {
                for (int j = 0; j < charsA.Length; j++)
                {
                    if (j != charsA.Length - 1)
                    {
                        if (charsM[i] == charsA[j])
                        {
                            n = j;
                            break;
                        }
                    }
                }

                //расшифровка
                for (int k = key; k > 0; k--)
                {
                    n -= 1;
                    if (n < 0)
                    {
                        n = charsA.Length - 1;
                    }
                    
                }
                charsM[i] = charsA[n];  
            }
            

            return new string(charsM);

        }

        public static void Main()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            Console.WriteLine("Enter the message(eng): ");
            string message = Console.ReadLine();
            Console.WriteLine("Enter 0 to incode/ enter 1 to decode: ");
            int mode = int.Parse(Console.ReadLine());

            while (true)
            {
                if (mode == 0)
                {
                    Console.WriteLine("Enter the key: ");
                    int key = int.Parse(Console.ReadLine());
                    if (key > alphabet.Length)
                    {
                        Console.WriteLine("Wrog key! Key must be less then alphabet length.");
                        continue;
                    }
                    Console.WriteLine(Incode(message, alphabet, key));
                    break;
                }
                else if (mode == 1)
                {
                    Console.WriteLine("Enter the key: ");
                    int key = int.Parse(Console.ReadLine());
                    if (key > alphabet.Length)
                    {
                        Console.WriteLine("Wrog key! Key must be less then alphabet length.");
                        continue;
                    }
                    Console.WriteLine(Decode(message, alphabet, key));
                }
            }
        }
    }
}
