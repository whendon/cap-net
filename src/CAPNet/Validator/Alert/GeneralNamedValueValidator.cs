using CAPNet.Models;
using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneralNamedValueValidator<T> : Validator<T>
    {
        private static readonly Dictionary<Type, Error> typeDictionary = new Dictionary<Type, Error>
                    {
                        {typeof(GeoCode), new GeoCodeError() },
                        {typeof(Parameter), new ParameterError() },
                        {typeof(EventCode), new EventCodeError() }
                    };

        private Error getErrorType(Type type)
        {
            if (!typeDictionary.ContainsKey(type))
            {
                throw new KeyNotFoundException();
            }

            return typeDictionary[type];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namedValue"></param>
        public GeneralNamedValueValidator(T namedValue) : base(namedValue) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                {
                    yield return getErrorType(Entity.GetType());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var generalNamedValue = (NamedValue)(object)Entity;
                return generalNamedValue.Value != null && generalNamedValue.ValueName != null;
            }
        }
    }
}
