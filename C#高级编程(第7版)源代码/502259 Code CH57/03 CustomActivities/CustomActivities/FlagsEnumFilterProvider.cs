using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;

namespace CustomActivities
{
    /// <summary>
    /// Class which acts as a filter when browsing for enums
    /// </summary>
    public class FlagsEnumFilterProvider : ITypeFilterProvider
    {
        /// <summary>
        /// Construct the object
        /// </summary>
        /// <param name="provider">The service provider</param>
        public FlagsEnumFilterProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Used to work out if a given type can be used
        /// </summary>
        /// <param name="type"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public bool CanFilterType(Type type, bool throwOnError)
        {
            bool canFilter = false;

            if (type.IsEnum)
            {
                Attribute att = Attribute.GetCustomAttribute(type, typeof(FlagsAttribute));

                if (null != att)
                    canFilter = true;
                else if (throwOnError)
                    throw new ArgumentException("The passed type does not include the [Flags] attribute", "type");
            }
            else if (throwOnError)
                throw new ArgumentException("The passed type is not an enum", "type");

            return canFilter;
        }

        /// <summary>
        /// Return the description of the filter
        /// </summary>
        public string FilterDescription
        {
            get { return "Showing enums that are decorated with the [Flags] attribute."; }
        }

        /// <summary>
        /// Store the IServiceProvider
        /// </summary>
        private IServiceProvider _provider;
    }
}
