using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalsProAPIV8.Core.Extensions;

namespace RentalsProMobileV9.Services.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            return value is string str && !str.IsEmpty();
        }
    }
}
