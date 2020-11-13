// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Xunit;

namespace System.Text.Json.Serialization.Tests
{
    public interface IMyTestClass
    {
        void Initialize();
        void Verify();
    }

    public static class PropertyOrderTests
    {
        [Theory]
        [MemberData(nameof(PropertyOrderTestCases))]
        public static void TestClasses(object testObj, string expectedJson)
        {
            string json = JsonSerializer.Serialize(testObj, testObj.GetType(), new JsonSerializerOptions());
            Assert.Equal(expectedJson, json);
        }

        public static IEnumerable<object[]> PropertyOrderTestCases
        {
            get
            {
                yield return new object[] { new PropertyOrderTestStruct1(), PropertyOrderTestStruct1.e_json };
                yield return new object[] { new PropertyOrderTestClass1(), PropertyOrderTestClass1.e_json };
                yield return new object[] { new PropertyOrderTestClass2(), PropertyOrderTestClass2.e_json };
                yield return new object[] { new PropertyOrderTestClass3(), PropertyOrderTestClass3.e_json };
                yield return new object[] { new PropertyOrderTestClass4(), PropertyOrderTestClass4.e_json };
                yield return new object[] { new PropertyOrderTestClass5(), PropertyOrderTestClass5.e_json };
                yield return new object[] { new PropertyOrderTestClass6(), PropertyOrderTestClass6.e_json };
                yield return new object[] { new PropertyOrderTestClass7(), PropertyOrderTestClass7.e_json };
                yield return new object[] { new PropertyOrderTestClass8(), PropertyOrderTestClass8.e_json };
                yield return new object[] { new PropertyOrderTestClass9(), PropertyOrderTestClass9.e_json };
                yield return new object[] { new PropertyOrderTestClass10(), PropertyOrderTestClass10.e_json };
                yield return new object[] { new PropertyOrderTestClass11(), PropertyOrderTestClass11.e_json };
                yield return new object[] { new PropertyOrderTestClass12(), PropertyOrderTestClass12.e_json };
            }
        }

        public struct PropertyOrderTestStruct1
        {
            [JsonPropertyOrder(1)]
            public int A { get; set; }
            public int B { get; set; }
            [JsonPropertyOrder(-2)]
            public int C { get; set; }

            public static readonly string e_json = @"{""C"":0,""B"":0,""A"":0}";
        }

        public class PropertyOrderTestClass1
        {
            [JsonPropertyOrder(-1)]
            public int A { get; set; } = 1;
            [JsonPropertyOrder(-1)]
            public int B { get; set; } = 2;
            [JsonPropertyOrder(-1)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""A"":1,""B"":2,""C"":3}";
        }

        public class PropertyOrderTestClass2
        {
            [JsonPropertyOrder(2)]
            public int a { get; set; } = 1;
            [JsonPropertyOrder(1)]
            public int b { get; set; } = 2;
            [JsonPropertyOrder(0)]
            public int c { get; set; } = 3;

            public static readonly string e_json = @"{""c"":3,""b"":2,""a"":1}";
        }

        public class PropertyOrderTestClass3
        {
            public int A { get; set; } = 1;
            public int B { get; set; } = 2;
            [JsonPropertyOrder(-2)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""C"":3,""A"":1,""B"":2}";
        }

        public class PropertyOrderTestClass4
        {
            [JsonPropertyOrder(1)]
            public int A { get; set; } = 1;
            [JsonPropertyOrder(2)]
            public int B { get; set; } = 2;
            [JsonPropertyOrder(-1)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""C"":3,""A"":1,""B"":2}";
        }

        public class PropertyOrderTestClass5
        {
            [JsonPropertyOrder(2)]
            public int A { get; set; } = 1;
            [JsonPropertyOrder(-1)]
            public int B { get; set; } = 2;
            [JsonPropertyOrder(1)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""B"":2,""C"":3,""A"":1}";
        }

        public class PropertyOrderTestClass6
        {
            [JsonPropertyOrder(0)]
            public int A { get; set; } = 1;
            [JsonPropertyOrder(0)]
            public int B { get; set; } = 2;
            [JsonPropertyOrder(0)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""A"":1,""B"":2,""C"":3}";
        }

        public class PropertyOrderTestClass7
        {
            [JsonPropertyOrder(1)]
            public int A { get; set; } = 1;
            public int B { get; set; } = 2;
            [JsonPropertyOrder(-2)]
            public int C { get; set; } = 3;

            public static readonly string e_json = @"{""C"":3,""B"":2,""A"":1}";
        }

        [JsonPropertyOrderByName]
        public class PropertyOrderTestClass8
        {
            public int C { get; set; } = 3;
            public int B { get; set; } = 2;
            public int A { get; set; } = 1;

            public static readonly string e_json = @"{""A"":1,""B"":2,""C"":3}";
        }

        [JsonPropertyOrderByName()]
        public class PropertyOrderTestClass9
        {
            public int cC { get; set; } = 3;
            public int CC { get; set; } = 3;
            public int bB { get; set; } = 2;
            public int BB { get; set; } = 2;
            public int aA { get; set; } = 1;
            public int AA { get; set; } = 1;

            public static readonly string e_json = @"{""AA"":1,""BB"":2,""CC"":3,""aA"":1,""bB"":2,""cC"":3}";
        }

        [JsonPropertyOrderByName(StringComparison.OrdinalIgnoreCase)]
        public class PropertyOrderTestClass10
        {
            public int cC { get; set; } = 3;
            public int CC { get; set; } = 3;
            public int bB { get; set; } = 2;
            public int BB { get; set; } = 2;
            public int aA { get; set; } = 1;
            public int AA { get; set; } = 1;

            public static readonly string e_json = @"{""aA"":1,""AA"":1,""bB"":2,""BB"":2,""cC"":3,""CC"":3}";
        }

        [JsonPropertyOrderByName]
        public class PropertyOrderTestClass11
        {
            [JsonPropertyName("C")]
            public int a { get; set; } = 3;
            [JsonPropertyName("B")]
            public int b { get; set; } = 2;
            [JsonPropertyName("A")]
            public int c { get; set; } = 1;

            public static readonly string e_json = @"{""A"":1,""B"":2,""C"":3}";
        }

        [JsonPropertyOrderByName]
        public class PropertyOrderTestClass12
        {
            [JsonPropertyName("C")]
            [JsonPropertyOrder(-2)]
            public int a { get; set; } = 3;
            [JsonPropertyName("B")]
            public int b { get; set; } = 2;
            [JsonPropertyName("A")]
            public int c { get; set; } = 1;

            public static readonly string e_json = @"{""C"":3,""A"":1,""B"":2}";
        }
    }
}
