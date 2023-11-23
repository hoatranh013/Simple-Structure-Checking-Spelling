// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using Autofac;
using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class ExtensionMethod
{
    public Dictionary<string, List<string>> _hashSet = new Dictionary<string, List<string>>();
    public void AddStringToDictionary(string key)
    {
        List<Tuple<char, int>> initial = new List<Tuple<char, int>>();
        List<Tuple<int, Tuple<char, int>>> tupleBuilder = new List<Tuple<int, Tuple<char, int>>>();
        var getArray = key.ToCharArray();
        var groupedArray = getArray.GroupBy(x => x);
        var getCharacters = getArray.Select(x => new Tuple<char, int>(x, groupedArray.FirstOrDefault(a => a.Key == x).Count()));
        var alphabeticallyCharacters = "qwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();

        foreach (var character in getCharacters)
        {
            var getNumberOfElement = Array.IndexOf(alphabeticallyCharacters,character.Item1);
            tupleBuilder.Add(new Tuple<int, Tuple<char, int>>(getNumberOfElement, character));
        }
        StringBuilder dictionaryBuilder = new StringBuilder();
        for (int i = 0; i < alphabeticallyCharacters.Length; i++)
        {
            if (tupleBuilder.Select(x => x.Item2.Item1).Contains(alphabeticallyCharacters[i]))
            {
                var getNumberAppend = tupleBuilder.Select(x => x.Item2).FirstOrDefault(a => a.Item1 == alphabeticallyCharacters[i]).Item2;
                dictionaryBuilder.Append(getNumberAppend);
            }
            else
            {
                dictionaryBuilder.Append("0");
            }
        }
        if (_hashSet.ContainsKey(dictionaryBuilder.ToString()))
        {
            _hashSet.TryGetValue(dictionaryBuilder.ToString(), out var list);
            list.Add(key);
        }
        else
        {
            _hashSet.Add(dictionaryBuilder.ToString(), new List<string> { key });
        }

    }

}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        var example = new ExtensionMethod();
        example.AddStringToDictionary("battle");
        example.AddStringToDictionary("ablett");
        example.AddStringToDictionary("lbttae");
        example.AddStringToDictionary("tatble");
        var abc = example._hashSet;
        Console.WriteLine(example._hashSet);


    }
}