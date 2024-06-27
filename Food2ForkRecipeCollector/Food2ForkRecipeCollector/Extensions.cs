using System.ComponentModel;

namespace Food2ForkRecipeCollector
{
    public static class Extensions
    {
        /// <summary>
        /// Retrieves the description attribute value associated with the specified enum
        /// value.
        /// </summary>
        /// <param name="value">
        /// The <see langword="enum" /> value for which to retrieve the
        /// description.
        /// </param>
        /// <returns>
        /// The description associated with the <see langword="enum" /> value, if
        /// available; otherwise, the
        /// string representation of the <see langword="enum" /> value.
        /// </returns>
        /// <remarks>
        /// This method retrieves the description attribute value, if present, associated
        /// with the specified <see langword="enum" /> value.
        /// <para />
        /// If no description attribute is found, it returns the string representation of
        /// the <see langword="enum" /> value.
        /// </remarks>
        public static string GetEnumDescription(this Enum value)
        {
            var field = value.GetType()
                             .GetField(value.ToString());
            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is not DescriptionAttribute attribute
                    ? value.ToString()
                    : attribute.Description;
        }
    }
}
