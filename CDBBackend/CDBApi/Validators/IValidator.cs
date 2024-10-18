using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDBApi.Validators
{
    public interface IValidator<in T>
    {
        void Validate(T request);
    }
}