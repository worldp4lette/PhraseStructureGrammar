namespace PhraseStructureGrammar;

public class Rule
{
    public List<Symbol> Lhs { get; private init; }
    public List<Symbol> Rhs { get; private init; }

    private Rule(List<Symbol> lhs, List<Symbol> rhs)
    {
        if (lhs.Count == 0 || rhs.Count == 0)
        {
            throw new InvalidOperationException("Rule must contain at least one symbol on both lhs and rhs.");
        }

        if (rhs.Count >= 2 && rhs.Contains(SpecialSymbols.Epsilon))
        {
            throw new InvalidOperationException(
                "Rhs is invalid. Rhs should either be a single epsilon, or a string without an epsilon.");
        }

        if (!lhs.Exists(s => s.IsNonTerminal))
        {
            throw new InvalidOperationException("Lhs is invalid. Lhs should contain at least one non-terminal symbol.");
        }

        Lhs = lhs;
        Rhs = rhs;
    }

    public Rule(string lhsString, string rhsString) : this(GetFormattedString(lhsString), GetFormattedString(rhsString))
    {
    }

    private static List<Symbol> GetFormattedString(string rawString)
    {
        var result = new List<Symbol>();

        if (rawString.Length == 0)
        {
            result.Add(SpecialSymbols.Epsilon);
            return result;
        }

        result.AddRange(rawString.Select(c => char.IsUpper(c) ? new Symbol(c, false) : new Symbol(c, true)));

        return result;
    }

    private bool IsRhsEpsilon() => Rhs[0].Equals(SpecialSymbols.Epsilon);

    public override string ToString()
    {
        var lhsString = string.Join(string.Empty, Lhs.Select(l => l.Value));
        var rhsString = IsRhsEpsilon() ? "ε" : string.Join(string.Empty, Rhs.Select(r => r.Value));
        return $"{lhsString} -> {rhsString}";
    }
}