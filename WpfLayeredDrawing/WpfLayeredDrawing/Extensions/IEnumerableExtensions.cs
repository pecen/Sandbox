using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLayeredDrawing.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Execute a action for each item in the list.
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <param name="source">The list itself.</param>
        /// <param name="action">Action to take on each item</param>
        /// <returns>The list itself.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source.IsNull())
            {
                return null;
            }
            else
            {
                foreach (T item in source)
                {
                    action(item);
                }
            }

            return source;
        }

        /// <summary>
        /// Execute a action for each item in the list.
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <param name="source">The list itself.</param>
        /// <param name="action">Action to take on each item</param>
        [DebuggerStepThrough]
        public static void ForEach<T>(this ICollection source, Action<T> action)
        {
            if (source.IsNotNull())
            {
                foreach (T item in source)
                {
                    action(item);
                }
            }
        }
    }
}
