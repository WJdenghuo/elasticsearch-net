using System.Collections.Generic;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using Nest.Resolvers;

namespace Nest
{
	public class IPMapping : IElasticType
	{
		[JsonIgnore]
		public TypeNameMarker TypeNameMarker { get; set; }


		[JsonProperty("index_name")]
		public string IndexName { get; set; }

		[JsonProperty("type")]
		public virtual TypeNameMarker Type { get { return new TypeNameMarker { Name = "ip" }; } }

		[JsonProperty("store"), JsonConverter(typeof(YesNoBoolConverter))]
		public bool? Store { get; set; }

		[JsonProperty("index"), JsonConverter(typeof(YesNoBoolConverter))]
		public bool? Index { get; set; }

		[JsonProperty("precision_step")]
		public int? PrecisionStep { get; set; }

		[JsonProperty("boost")]
		public double? Boost { get; set; }

		[JsonProperty("null_value")]
		public string NullValue { get; set; }

		[JsonProperty("include_in_all")]
		public bool? IncludeInAll { get; set; }
	}
}