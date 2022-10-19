using System.ComponentModel.Design;

namespace HashTable
{
    internal class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("\n\n---- Welcome To HashTable ----");

        Home:
            Menu();
            Console.Write("\n\nEnter Your Choice : ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 0:
                    break;

                case 1:
                    MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
                    hash.Add("0", "To");
                    hash.Add("1", "be");
                    hash.Add("2", "or");
                    hash.Add("3", "not");
                    hash.Add("4", "To");
                    hash.Add("5", "be");
                    hash.GetFrequency("To");
                    hash.GetFrequency("be");
                    hash.GetFrequency("or");
                    hash.GetFrequency("not");
                    goto Home;
                    break;
                case 2:

                    MyMapNode<string, string> hash1 = new MyMapNode<string, string>(20);
                    String sentence = "Paranoids are not paranoid because they are" +
                        " paranoid but because they keep putting themselves deliberately" +
                        " into paranoid avoidable situations";

                    //split is splitting a string into an array of substrings separated by a character
                    string[] Phrase = sentence.Split(' ');

                    int SLength = Phrase.Length;
                    // Itreating along each word and adding it to hash set
                    for (int i = 0; i < SLength; i++)
                    {
                        hash1.Add(Convert.ToString(i), Phrase[i]);
                    }
                    //iterating through each loop to get the frequency of each word in the sentence
                    foreach (string word in Phrase)
                    {
                        hash1.GetFrequency(word);
                    }
                    goto Home;

                    break;
                default:
                    Console.WriteLine("Wrong Input !");
                    goto Home;
                    break;

            }

        }
        public static void Menu()
        {
            Console.WriteLine("\n\n1) Get Frequency Of Words From Sentence");
            Console.WriteLine("2) Get Frequency Of Words From Paragraph");

            Console.WriteLine("\n\nPress 0 To Exit !");
        }

    }
}