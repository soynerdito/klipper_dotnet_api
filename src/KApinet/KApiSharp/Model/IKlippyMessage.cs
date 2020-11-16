using System;
using System.Collections.Generic;
using System.Text;

namespace KApiSharp.Model
{
    public interface IKlippyMessage
    {
        int Id { get; set; }
        string Method { get; set; }
    }
}
