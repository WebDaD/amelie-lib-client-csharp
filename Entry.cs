using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amelie.lib.client.csharp
{
    public class Entry
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

        
        public Entry(string source, string level, string message, string message_long)
        {
            this.id = Guid.NewGuid().ToString();
            this.source = source;
            this.level = level;
            this.message = message;
            this.message_long = message_long;
            this.timestamp = DateTime.Now;
        }

        [JsonIgnore]
        public string JSON
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
