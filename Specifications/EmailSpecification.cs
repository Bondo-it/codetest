using System.Net.Mail;
using System.Text.RegularExpressions;
using codetest.Models;

namespace codetest.Specification
{
    public class EmailSpecification : CompositeSpecification<string>
    {
        public override bool IsSatisfiedBy(string email)
        {
            try
            {
                new MailAddress(email);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}