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
        private static readonly Dictionary<Type, int> typeDictionary = new Dictionary<Type, int>
                    {
                        {typeof(GeoCode), 0},
                        {typeof(Parameter), 1},
                        {typeof(EventCode), 2}
                    };

        private Error getErrorType(Type type)
        {
            switch (typeDictionary[type])
            {
                case 0:
                    return new GeoCodeError();
                case 1:
                    return new ParameterError();
                case 2:
                    return new EventCodeError();
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
