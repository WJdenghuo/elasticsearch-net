using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(DateRangeAggregation))]
	public interface IDateRangeAggregation : IBucketAggregation
	{
		[DataMember(Name ="field")]
		Field Field { get; set; }

		[DataMember(Name ="format")]
		string Format { get; set; }

		[DataMember(Name ="ranges")]
		IEnumerable<IDateRangeExpression> Ranges { get; set; }

		[DataMember(Name ="time_zone")]
		string TimeZone { get; set; }
	}

	public class DateRangeAggregation : BucketAggregationBase, IDateRangeAggregation
	{
		internal DateRangeAggregation() { }

		public DateRangeAggregation(string name) : base(name) { }

		public Field Field { get; set; }
		public string Format { get; set; }
		public IEnumerable<IDateRangeExpression> Ranges { get; set; }
		public string TimeZone { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.DateRange = this;
	}

	public class DateRangeAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<DateRangeAggregationDescriptor<T>, IDateRangeAggregation, T>
			, IDateRangeAggregation
		where T : class
	{
		Field IDateRangeAggregation.Field { get; set; }

		string IDateRangeAggregation.Format { get; set; }

		IEnumerable<IDateRangeExpression> IDateRangeAggregation.Ranges { get; set; }

		string IDateRangeAggregation.TimeZone { get; set; }

		public DateRangeAggregationDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public DateRangeAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public DateRangeAggregationDescriptor<T> Format(string format) => Assign(format, (a, v) => a.Format = v);

		public DateRangeAggregationDescriptor<T> Ranges(params IDateRangeExpression[] ranges) =>
			Assign(ranges.ToListOrNullIfEmpty(), (a, v) => a.Ranges = v);

		public DateRangeAggregationDescriptor<T> TimeZone(string timeZone) => Assign(timeZone, (a, v) => a.TimeZone = v);

		public DateRangeAggregationDescriptor<T> Ranges(params Func<DateRangeExpressionDescriptor, IDateRangeExpression>[] ranges) =>
			Assign(ranges?.Select(r => r(new DateRangeExpressionDescriptor())).ToListOrNullIfEmpty(), (a, v) => a.Ranges = v);

		public DateRangeAggregationDescriptor<T> Ranges(IEnumerable<Func<DateRangeExpressionDescriptor, IDateRangeExpression>> ranges) =>
			Assign(ranges?.Select(r => r(new DateRangeExpressionDescriptor())).ToListOrNullIfEmpty(), (a, v) => a.Ranges = v);
	}
}
