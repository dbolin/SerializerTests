﻿using System;
using System.IO;
using System.Text;
using Wire;
using System.Runtime.CompilerServices;

namespace SerializerTests.Serializers
{

    /// <summary>
    /// Not active anymore since it does not work with .NET Core 3
    /// https://github.com/rogeralsing/Wire
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Wire<T> : TestBase<T, Serializer> where T : class
    {
        public Wire(Func<int, T> testData, Action<T> data, bool refTracking=false):base(testData, data, refTracking)
        {
            FormatterFactory = () =>
            {
                var lret = new Serializer(new SerializerOptions(preserveObjectReferences:RefTracking));
                return lret;
            };
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Serialize(T obj, Stream stream)
        {
            Formatter.Serialize(obj, stream);
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override T Deserialize(Stream stream)
        {
            return Formatter.Deserialize<T>(stream);
        }
    }
}
