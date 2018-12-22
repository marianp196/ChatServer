using System;
using System.Collections.Generic;
using System.Text;

namespace ChatserverProtokoll.Input
{
    public class MessageResult
    {
        public EState State { get; set; }
        public Guid? ClientID { get; set; }
        public Guid? ServerID { get; set; }

        public IEnumerable<Error> Errors { get; set; }
    }

    public enum EState
    {
        Success,
        Error,
        Warning
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
