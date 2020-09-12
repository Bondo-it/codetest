using System.Text.RegularExpressions;
using Specification.Specifications;

namespace Specification.Specifications
{
	public class PhoneSpecification : CompositeSpecification<string>
	{
		public static Regex PhoneRegex = new Regex(@"^(0045|\+45)?[2-9][0-9][1-9][0-9]([0-9]){4}$");

		public override bool IsSatisfiedBy(string phone)
		{
			return PhoneRegex.IsMatch(phone);
		}
	}
}