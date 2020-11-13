// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Text.Json.Serialization
{
    /// <summary>
    /// Specifies the property order in JSON when serializing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class JsonPropertyOrderAttribute : JsonAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="JsonPropertyOrderAttribute"/> with the specified property order.
        /// </summary>
        /// <param name="order">The order of the property.</param>
        public JsonPropertyOrderAttribute(int order)
        {
            Order = order;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public int Order { get; }
    }
}
