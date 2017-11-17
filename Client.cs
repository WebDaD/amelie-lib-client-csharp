using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace amelie.lib.client.csharp
{
    public class Client
    {
        private string serverURL;
        private string source;
        private string level;
        private string pattern;

        /// <summary>
        /// Create the Client with Default Values
        /// </summary>
        /// <param name="serverURL"></param>
        /// <param name="source"></param>
        /// <param name="level"></param>
        /// <param name="regex"></param>
        public Client(string serverURL, string source, string level, string regex)
        {
            this.serverURL = serverURL;
            this.source = source;
            this.level = level;
            this.pattern = regex;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Entry WriteLog(string message)
        {
            // TODO: if message matches regex, split it. else just write
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public Entry WriteLog(string message, string level)
        {
            return WriteLog(message, level, this.source, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public Entry WriteLog(string message, string level, string source)
        {
            return WriteLog(message, level, source, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="source"></param>
        /// <param name="message_long"></param>
        /// <returns></returns>
        public Entry WriteLog(string message, string level, string source, string message_long)
        {
            // TODO: write to server, return parse to object
            // POST /log (body: source, level, message, message_long, timestamp(optional))
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAll(string serverURL = "")
        {
            // * GET /log  - get all log entries
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadSources(string serverURL = "")
        {
            // * GET /log/sources  - get all sources
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadLevels(string serverURL = "")
        {
            // * GET /log/levels  - get all sources
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadTags(string serverURL = "")
        {
            // * GET /log/tags  - get all sources
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public Entry ReadEntry(string id, string serverURL = "")
        {
            // * GET /log/:id  - get object with id
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllBySource(string source, string serverURL = "")
        {
            // * GET /log/source/:source  - get all entries to source
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllByLevel(string level, string serverURL = "")
        {
            // * GET /log/level/:level - get all entries to level
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllByTag(string tag, string serverURL = "")
        {
            // * GET /log/tag/:tag - get all entries to tag
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> Query(string query, string serverURL = "")
        {
            // * GET /search?:query (query: source, level, from, to, tag, string, ...)
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllByTimeStamp(DateTime From, DateTime? To = null, string serverURL = "")
        {
            // * GET /log/timestamp/:from/[:to]  - get from, if no to then now
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public Entry ReadNewst(int number = 1, string serverURL = "")
        {
            // * GET /log/last  - get newest Entry
            // * GET /log/last/:number  - get newest entries, where number is the number of entries to get
        }



    }
}
