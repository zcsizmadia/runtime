// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace System.Text.Json.Serialization
{
    /// <summary>
    /// Specifies the property order in JSON when serializing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class JsonPropertyOrderByNameAttribute : JsonAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="JsonPropertyOrderByNameAttribute"/> with the specified property order.
        /// </summary>
        /// <param name="stringComparison">Property name comparison type.</param>
        public JsonPropertyOrderByNameAttribute(StringComparison stringComparison)
        {
            StringComparison = stringComparison;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="JsonPropertyOrderByNameAttribute"/> with the specified property order.
        /// </summary>
        public JsonPropertyOrderByNameAttribute()
            : this(StringComparison.Ordinal)
        {
        }

        /// <summary>
        /// Property name string comparison type.
        /// </summary>
        public StringComparison StringComparison { get; }
    }
}
