using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Beer.Source.Repositories
{
	public class BeerModelJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException("Not implemented yet");
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return string.Empty;
			}
			else if (reader.TokenType == JsonToken.String)
			{
				return serializer.Deserialize(reader, objectType);
			}
			else
			{
				JObject obj = JObject.Load(reader);
				if (obj["name"] != null)
					return obj["name"].ToString();
				else
					return serializer.Deserialize(reader, objectType);
			}
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override bool CanConvert(Type objectType)
		{
			return false;
		}
	}
}