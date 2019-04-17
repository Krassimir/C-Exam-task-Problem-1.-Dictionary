using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordDictionary = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" | ").ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                string[] description = input[i].Split(": ").ToArray();
                string name = description[0];
                string element = description[1];

                if (!wordDictionary.ContainsKey(name))
                {
                    wordDictionary.Add(name, new List<string> {element});
                }
                else
                {
                    wordDictionary[name].Add(element);
                }
            }

            var secondWordLine = new List<string>();
            string[] seconddString = Console.ReadLine().Split(" | ").ToArray();
            for (int j = 0; j < seconddString.Length; j++)
            {
                string newWord = seconddString[j];
                secondWordLine.Add(newWord);
            }

            string command = Console.ReadLine();

            var listOfWordForPrint = new List<string>();
            if (command == "List")
            {
                foreach (var item in wordDictionary.OrderBy(x => x.Key))
                {
                    listOfWordForPrint.Add(item.Key);
                }

                Console.WriteLine(string.Join(" ", listOfWordForPrint));
            }
            if (command == "End")
            {
                for (int k = 0; k < secondWordLine.Count; k++)
                {
                    string findedWord = secondWordLine[k];
                    if (wordDictionary.ContainsKey(findedWord))
                    {
                        Console.WriteLine(findedWord);
                        foreach (var kvp in wordDictionary[findedWord].OrderByDescending(x => x.Length))
                        {
                            Console.WriteLine($" -{kvp}");
                        }
                    }
                }
            }
        }
    }
}
