using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using codetest.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace codetest.Models
{
    [Serializable]
    public class User : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        [Display(Name = "Fulde navn")]
        public string Name { get; set; }


        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adresse")]
        public string Email { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon nummer")]
        public string PhoneNumber { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
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

        override public string ToString()
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