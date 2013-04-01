using System.Collections.Generic;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using Nest.Resolvers;

namespace Nest
{
	public class AttachmentMapping : IElasticType
	{
		[JsonIgnore]
		public TypeNameMarker TypeNameMarker { get; set; }

		[JsonProperty("type")]
		public virtual TypeNameMarker Type { get { return new TypeNameMarker { Name = "attachment" }; } }

		[JsonProperty("fields"), JsonConverter(typeof(ElasticCoreTypeConverter))]
		public IDictionary<string, IElasticCoreType> Fields { get; set; }

		public AttachmentMapping()
		{
			this.Fields = new Dictionary<string, IElasticCoreType>();
		}

	}
}