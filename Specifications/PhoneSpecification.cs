using System.Net.Mail;
using System.Text.RegularExpressions;
using codetest.Models;

namespace codetest.Specification
{
    public class PhoneSpecification : CompositeSpecification<string>
    {
        public static Regex _phoneRegex = new Regex(@"^(0045|\+45)?\?[2-9][0-9]\?[1-9][0-9]\?([0-9]\?){4}$");

        public override bool IsSatisfiedBy(string phtone)
        {
            return _phoneRegex.IsMatch(phtone);
        }
    }
}