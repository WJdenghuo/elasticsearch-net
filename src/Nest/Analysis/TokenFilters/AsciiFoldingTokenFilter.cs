﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	/// <summary>
	/// A token filter of type asciifolding that converts alphabetic, numeric, and symbolic Unicode characters which are
	/// <para> not in the first 127 ASCII characters (the “Basic Latin” Unicode block) into their ASCII equivalents, if one exists.</para>
	/// </summary>
	public interface IAsciiFoldingTokenFilter : ITokenFilter
	{
		[DataMember(Name ="preserve_original")]
		[JsonFormatter(typeof(NullableStringBooleanFormatter))]
		bool? PreserveOriginal { get; set; }
	}

	/// <inheritdoc />
	public class AsciiFoldingTokenFilter : TokenFilterBase, IAsciiFoldingTokenFilter
	{
		public AsciiFoldingTokenFilter() : base("asciifolding") { }

		public bool? PreserveOriginal { get; set; }
	}

	/// <inheritdoc />
	public class AsciiFoldingTokenFilterDescriptor
		: TokenFilterDescriptorBase<AsciiFoldingTokenFilterDescriptor, IAsciiFoldingTokenFilter>, IAsciiFoldingTokenFilter
	{
		protected override string Type => "asciifolding";

		bool? IAsciiFoldingTokenFilter.PreserveOriginal { get; set; }

		/// <inheritdoc />
		public AsciiFoldingTokenFilterDescriptor PreserveOriginal(bool? preserve = true) => Assign(preserve, (a, v) => a.PreserveOriginal = v);
	}
}
