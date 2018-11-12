using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class Anagrams
{
    string[] testCase1 = { "incest", "insect" };
    string[] testCase2 = { "listen", "silent" };
    string[] testCase3 = { "poor", "car" };
    string[] testCase4 = { "ayyo", "sting" };

    [Test]
    public void UniqueCharactersSimplePasses() {
        Assert.That(IsAnagram(testCase1[0], testCase1[1]) == true);
        Assert.That(IsAnagram(testCase2[0], testCase2[1]) == true);
        Assert.That(IsAnagram(testCase3[0], testCase3[1]) == false);
        Assert.That(IsAnagram(testCase4[0], testCase4[1]) == false);
    }

    public bool IsAnagram(string _word1, string _word2)
    {
        if(_word1 == null || _word2 == null)
        {
            return false;
        }
        if(_word1.Length != _word2.Length)
        {
            return false;
        }
        foreach(char c in _word1)
        {
            int ix = _word2.IndexOf(c);

            if(ix==-1)
            {
                return false;
            }
        }
        return true;
    }
}
