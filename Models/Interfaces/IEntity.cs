using System;

namespace codetest.Models.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? AddedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}