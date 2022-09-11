using ImageFilters.Services.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Utilities
{
    public class GenericResponseModel<TResult> : BaseResponseModel
    {
        public GenericResponseModel()
        {
            Type t = typeof(TResult);
            if (t.GetConstructor(Type.EmptyTypes) != null)
                Data = Activator.CreateInstance<TResult>();
        }

        public TResult Data { get; set; }

    }
}
