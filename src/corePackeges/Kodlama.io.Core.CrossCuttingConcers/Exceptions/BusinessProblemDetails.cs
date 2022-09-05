using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Core.CrossCuttingConcers.Exceptions
{
    public class BusinessProblemDetails : ProblemDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
