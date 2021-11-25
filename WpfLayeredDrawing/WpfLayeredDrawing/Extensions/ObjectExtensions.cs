using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLayeredDrawing.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Indicates that the specified reference is a null reference
        /// </summary>
        /// <typeparam name="T">Current Type.</typeparam>
        /// <param name="value">Reference to be tested</param>
        /// <returns>True, if specified value is a null reference; Otherwise False.</returns>
        [ContractAnnotation("null => true")]
        public static bool IsNull<T>(this T value)
        {
            return value == null;
        }

        /// <summary>
        /// Indicates that the specified reference is not a null reference
        /// </summary>
        /// <typeparam name="T">Current Type.</typeparam>
        /// <param name="value">Reference to be tested</param>
        /// <returns>
        /// True, if specified value is not a null reference; Otherwise False.
        /// </returns>
        [ContractAnnotation("null => false")]
        public static bool IsNotNull<T>(this T value)
        {
            return value is object;
        }
    }
}
