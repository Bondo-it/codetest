using System.Collections.Generic;

namespace codetest.Models.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}