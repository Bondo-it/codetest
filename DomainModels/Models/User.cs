using DomainModels.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
	[Serializable]
	public class User : IEntity
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		[Display(Name = "Full Name")]
		public string Name { get; set; }


		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		[Display(Name = "Name")]
		public string UserName { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email address")]
		public string Email { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		[Display(Name = "Address")]
		public string Address { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		public DateTime? CreatedAt { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		public DateTime? AddedAt { get; set; }

		[BsonIgnoreIfDefault]
		[BsonIgnoreIfNull]
		public DateTime? ModifiedAt { get; set; }

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append(this.GetType());
			stringBuilder.Append("\n");
			foreach (var propertyInfo in this.GetType().GetProperties())
			{
				stringBuilder.Append($"\t{propertyInfo.Name}: {propertyInfo.GetValue(this, null)}\n");
			}

			return stringBuilder.ToString();
		}
	}
}