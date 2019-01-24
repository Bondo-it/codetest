using System.Net.Mail;
using System.Text.RegularExpressions;
using codetest.Models;

namespace codetest.Specification
{
    public class NameSpecification : CompositeSpecification<string>
    {
        public static Regex _nameRegex = new Regex(
                "^(\\b[A-Za-z]*\\b\\s+\\b[A-Za-z]*\\b+\\.[A-Za-z])$",
                RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
            );

        public override bool IsSatisfiedBy(string name)
        {
            return _nameRegex.IsMatch(name);
        }
    }
}