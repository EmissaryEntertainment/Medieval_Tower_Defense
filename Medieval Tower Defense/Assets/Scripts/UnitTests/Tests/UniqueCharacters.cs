using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UniqueCharacters
{
    string test1 = "Hello";
    string test2 = "Joe";
    string test3 = "Kevin";
    string test4 = "Geek";

    [Test]
    public void UniqueCharactersSimplePasses()
    {
        Assert.That(uniqueChars(test1) == false);
        Assert.That(uniqueChars(test2) == true);
        Assert.That(uniqueChars(test3) == true);
        Assert.That(uniqueChars(test4) == false);
    }

    bool uniqueChars(string _word)
    {
        for(int i = 0; i<_word.Length;i++)
        {
            for(int j = i+1;j<_word.Length;j++)
            {
                if(_word[i] == _word[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
