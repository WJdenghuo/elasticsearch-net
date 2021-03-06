﻿using System;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.Integration;
using static Nest.Infer;

namespace Tests.Aggregations.Metric.Cardinality
{
	public class CardinalityAggregationUsageTests : AggregationUsageTestBase
	{
		public CardinalityAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object AggregationJson => new
		{
			state_count = new
			{
				cardinality = new
				{
					field = "state",
					precision_threshold = 100
				}
			}
		};

		protected override Func<AggregationContainerDescriptor<Project>, IAggregationContainer> FluentAggs => a => a
			.Cardinality("state_count", c => c
				.Field(p => p.State)
				.PrecisionThreshold(100)
			);

		protected override AggregationDictionary InitializerAggs =>
			new CardinalityAggregation("state_count", Field<Project>(p => p.State))
			{
				PrecisionThreshold = 100
			};

		protected override void ExpectResponse(SearchResponse<Project> response)
		{
			response.ShouldBeValid();
			var projectCount = response.Aggregations.Cardinality("state_count");
			projectCount.Should().NotBeNull();
			projectCount.Value.Should().Be(3);
		}
	}
}
