using System;
using System.Collections.Generic;
using System.Text;

namespace amelie.lib.client.csharp
{
    class Entry
    {
        private string id;
        private string source;
        private string level;
        private string message;
        private string message_long;
        private DateTime timestamp;

        public string ID { get { return id; } }
        public string Source { get { return source; } set { source = value; } }
        public string Level { get { return level; } set { level = value; } }
        public string Message { get { return message; } set { message = value; } }
        public string MessageLong { get { return message_long; } set { message_long = value; } }
        public DateTime TimeStamp { get { return timestamp; } }
    }
}
