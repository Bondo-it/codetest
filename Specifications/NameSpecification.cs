using System.Net.Mail;
using System.Text.RegularExpressions;
using codetest.Models;

namespace codetest.Specification
{
    public class NameSpecification : CompositeSpecification<string>
    {
        public static Regex _nameRegex = new Regex(
                @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$",
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