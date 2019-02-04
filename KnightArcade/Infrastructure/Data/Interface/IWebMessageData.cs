using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data.Interface
{
    public interface IWebMessageData
    {
        bool SendWebMessage(string url, object data);
    }
}
