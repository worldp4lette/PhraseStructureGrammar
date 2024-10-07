using System.Collections.Immutable;

namespace PhraseStructureGrammar;

public class PhraseStructureGrammar : IPhraseStructureGrammar
{
    public required ImmutableHashSet<Symbol> Alphabet { get; init; }
    public required ImmutableHashSet<Symbol> NonTerminals { get; init; }
    public required List<Rule> ProductionRules { get; init; }
    public required Symbol StartSymbol { get; init; }
    
    public void LeftFactor()
    {
        throw new NotImplementedException();
    }

    public void RemoveLeftRecursion()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        foreach (var rule in ProductionRules)
        {
            Console.WriteLine(rule);
        }
    }
}

public record Symbol(char Value, bool IsTerminal)
{
    public bool IsNonTerminal => !IsTerminal;
}

public static class SpecialSymbols
{
    public static readonly Symbol Epsilon = new Symbol('\0', true);
}