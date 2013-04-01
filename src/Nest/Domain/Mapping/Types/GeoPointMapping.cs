using System.Collections.Generic;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using Nest.Resolvers;

namespace Nest
{
	public class GeoPointMapping : IElasticType
	{
		[JsonIgnore]
		public TypeNameMarker TypeNameMarker { get; set; }

		[JsonProperty("type")]
		public virtual TypeNameMarker Type { get { return new TypeNameMarker { Name = "geo_point" }; } }

		[JsonProperty("lat_lon")]
		public bool? IndexLatLon { get; set; }

		[JsonProperty("geohash")]
		public bool? IndexGeoHash { get; set; }

		[JsonProperty("geohash_precision")]
		public int? GeoHashPrecision { get; set; }
	}
}