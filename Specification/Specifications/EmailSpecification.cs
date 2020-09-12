using System.Net.Mail;
using Specification.Specifications;

namespace Specification.Specifications
{
	public class EmailSpecification : CompositeSpecification<string>
	{
		public override bool IsSatisfiedBy(string email)
		{
			try
			{
				var mailAddress = new MailAddress(email);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}