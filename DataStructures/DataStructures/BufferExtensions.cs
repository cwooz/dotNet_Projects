﻿using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace DataStructures
{
    // public delegate void Printer<T>(T data);         // Custom Delegate Definition    // REPLACED w/ Action<T>

    public static class BufferExtensions
    {
        public static void DumpBuffer<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            //foreach (var item in buffer)
            //{
            //    TOutput result = converter(item);
            //    yield return result;
            //}
            return buffer.Select(item => converter(item));      // Succinct refactor using LINQ Library
        }
    }
}
