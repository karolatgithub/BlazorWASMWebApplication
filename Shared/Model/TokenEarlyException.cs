﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BlazorWASMWebApplication.Shared.Model
{
    public class TokenEarlyException : Exception
    {
        public TokenEarlyException() :
            base("Token jest z przyszłości")
        { }

    }
}
