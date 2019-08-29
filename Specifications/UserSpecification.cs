using codetest.Models;

namespace codetest.Specifications
{
    public class UserSpecification : CompositeSpecification<User>
    {
        public override bool IsSatisfiedBy(User user)
        {
            if (!new NameSpecification().IsSatisfiedBy(user.Name))
            {
                return false;
            }

            if (!new EmailSpecification().IsSatisfiedBy(user.Email))
            {
                return false;
            }

            if (!new PhoneSpecification().IsSatisfiedBy(user.PhoneNumber))
            {
                return false;
            }

            return true;
        }
    }
}