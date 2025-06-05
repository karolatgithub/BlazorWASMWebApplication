using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BlazorWASMWebApplication.Shared.Model
{
    public class TokenDelayedException : Exception
    {
        public TokenDelayedException() :
            base("Token jest z przeszłości")
        { }

    }
}
