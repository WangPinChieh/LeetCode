using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace LeetCode.Tests;

public class BreakPalindromeTests
{
    private BreakPalindromeSolution _breakPalindromeSolution;

    [SetUp]
    public void Setup()
    {
        _breakPalindromeSolution = new BreakPalindromeSolution();
    }

    [Test]
    public void input_a_character_should_return_empty_result()
    {
        Assert.AreEqual(string.Empty, _breakPalindromeSolution.BreakPalindrome("a"));
    }


    [Test]
    public void abccba_return_aaccba()
    {
        Assert.AreEqual("aaccba", _breakPalindromeSolution.BreakPalindrome("abccba"));
    }

    [Test]
    public void aa_return_ab()
    {
        Assert.AreEqual("ab", _breakPalindromeSolution.BreakPalindrome("aa"));
    }

    [Test]
    public void cc_return_ac()
    {
        Assert.AreEqual("ac", _breakPalindromeSolution.BreakPalindrome("cc"));
    }

    [Test]
    public void aba_return_abb()
    {
        Assert.AreEqual("abb", _breakPalindromeSolution.BreakPalindrome("aba"));
    }
    
    [Test]
    public void bbb_return_abb()
    {
        Assert.AreEqual("abb", _breakPalindromeSolution.BreakPalindrome("bbb"));
    }
    
    [Test]
    public void aaaa_return_aaab()
    {
        Assert.AreEqual("aaab", _breakPalindromeSolution.BreakPalindrome("aaaa"));
    }
    
   [Test]
    public void cggc_return_aggc()
    {
        Assert.AreEqual("aggc", _breakPalindromeSolution.BreakPalindrome("cggc"));
    }
   
   
    [Test]
    public void isPalindrome_aa_return_true()
    {
        Assert.AreEqual(true, _breakPalindromeSolution.IsPalindrome("aa"));
    }

    [Test]
    public void isPalindrome_ac_return_false()
    {
        Assert.AreEqual(false, _breakPalindromeSolution.IsPalindrome("ab"));
    }

    [Test]
    public void isPalindrome_aca_return_true()
    {
        Assert.AreEqual(true, _breakPalindromeSolution.IsPalindrome("aca"));
    }
    
    [Test]
    public void isPalindrome_abb_return_true()
    {
        Assert.AreEqual(false, _breakPalindromeSolution.IsPalindrome("abb"));
    }
    
   
}

public class BreakPalindromeSolution
{
    public string BreakPalindrome(string palindrome)
    {
        if (palindrome.Length != 1)
        {
            var chars = palindrome.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'a' && i != chars.Length - 1)
                {
                    continue;
                }
                var potentialAnswerChars = palindrome.ToCharArray();
                potentialAnswerChars[i] = 'a';
                if (!IsPalindrome(new string(potentialAnswerChars)))
                {
                    return new string(potentialAnswerChars);
                }

                if (i == chars.Length - 1)
                {
                    potentialAnswerChars[i] = (char) (potentialAnswerChars[i] + 1);
                    return new string(potentialAnswerChars);
                }
            }
        }

        return "";
    }

    public bool IsPalindrome(string words)
    {
        if (words.Length == 1)
        {
            return false;
        }

        if (words.Length % 2 == 0)
        {
            return words.Substring(0, words.Length / 2) ==
                   new string(words.Substring(words.Length / 2, words.Length / 2).Reverse().ToArray());
        }

        return words.Substring(0, words.Length / 2) ==
               new string(words.Substring(words.Length / 2 + 1, words.Length / 2).Reverse().ToArray());
    }
}
