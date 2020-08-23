using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.CORE
{
    public enum ResponseCode
    {
        Success,
        Error,
        InternalServerError = 500,
        NotFound
    }
}
