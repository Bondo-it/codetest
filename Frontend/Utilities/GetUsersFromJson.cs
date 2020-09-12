using DomainModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Frontend.Utilities
{
	public class GetUsersFromJson
	{
		readonly string _path;

		public GetUsersFromJson(string path)
		{
			_path = path;
		}

		public IList<User> Execute()
		{
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			var directory = Path.Combine(baseDirectory, _path);
			using (var reader = new StreamReader(directory))
			{
				string json = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<IList<User>>(json);
			}
		}
	}
}