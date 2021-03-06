﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(StringFielddata))]
	public interface IStringFielddata : IFielddata
	{
		[DataMember(Name ="format")]
		StringFielddataFormat? Format { get; set; }
	}

	public class StringFielddata : FielddataBase, IStringFielddata
	{
		public StringFielddataFormat? Format { get; set; }
	}

	public class StringFielddataDescriptor
		: FielddataDescriptorBase<StringFielddataDescriptor, IStringFielddata>, IStringFielddata
	{
		StringFielddataFormat? IStringFielddata.Format { get; set; }

		public StringFielddataDescriptor Format(StringFielddataFormat? format) => Assign(format, (a, v) => a.Format = v);
	}
}
