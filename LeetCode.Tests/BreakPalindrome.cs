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
            var charsLengthInHalf = chars.Length / 2;
            for (var i = 0; i < charsLengthInHalf; i++)
            {
                if (chars[i] == 'a')
                {
                    continue;
                }
                chars[i] = 'a';
                return new string(chars);
            }

            chars[chars.Length - 1] = 'b';
            return new string(chars);
        }

        return "";
    }

    public bool IsPalindrome(string words)
    {
        if (words.Length == 1)
        {
            return false;
        }

        var middle = words.Length / 2;
        if (words.Length % 2 == 0)
        {
            return words.Substring(0, middle) ==
                   new string(words.Substring(middle, middle).Reverse().ToArray());
        }

        return words.Substring(0, middle) ==
               new string(words.Substring(middle + 1, middle).Reverse().ToArray());
    }
}
