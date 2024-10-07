using PhraseStructureGrammar;

namespace PhraseStructureGrammarTest;

public class RuleTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var rule1 = new Rule("S", "abA");
        Assert.That(rule1.ToString(), Is.EqualTo("S -> abA"));

        Assert.Throws<InvalidOperationException>(() =>
        {
            var rule2 = new Rule("aa", "abbA");
        });
    }
}