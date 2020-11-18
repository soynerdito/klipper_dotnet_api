using System;
using System.Collections.Generic;
using System.Text;

namespace KApinet.Model
{
    public interface IKlippyMessage
    {
        int Id { get; set; }
        string Method { get; set; }
    }
}
