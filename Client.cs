using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;

namespace amelie.lib.client.csharp
{
    public class Client
    {
        private string serverURL;
        private string source;
        private string level;
        private string pattern;
        private Regex pattern_reg;

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
            this.pattern_reg = new Regex(regex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Entry WriteLog(string message)
        {
            if (this.pattern_reg.IsMatch(message))
            {
                // TODO: parse string into fields based on regex
            }
            else
            {
                return WriteLog(message, this.level, this.source, "");
            }

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
            Entry write = new Entry(source, level, message, message_long);
            string output = writeJSON(write.JSON, makeURL(serverURL, "/log/"));
            Entry deserializedEntry = JsonConvert.DeserializeObject<Entry>(output);
            return deserializedEntry;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAll(string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/log/"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadSources(string serverURL = "")
        {
            string output = getJSON(makeURL(serverURL, "/log/sources/"));
            string[] deserializedEntry = JsonConvert.DeserializeObject<string[]>(output);
            return new List<string>(deserializedEntry);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadLevels(string serverURL = "")
        {
            string output = getJSON(makeURL(serverURL, "/log/levels/"));
            string[] deserializedEntry = JsonConvert.DeserializeObject<string[]>(output);
            return new List<string>(deserializedEntry);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<string> ReadTags(string serverURL = "")
        {
            string output = getJSON(makeURL(serverURL, "/log/tags/"));
            string[] deserializedEntry = JsonConvert.DeserializeObject<string[]>(output);
            return new List<string>(deserializedEntry);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public Entry ReadEntry(string id, string serverURL = "")
        {
            string output = getJSON(makeURL(serverURL, "/log/" + id));
            Entry deserializedEntry = JsonConvert.DeserializeObject<Entry>(output);
            return deserializedEntry;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllBySource(string source, string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/log/source/" + source));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllByLevel(string level, string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/log/level/" + level));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadAllByTag(string tag, string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/log/tag/" + tag));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> Query(string query, string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/search?" + query));
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
            DateTime until;
            if(To == null)
            {
                until = DateTime.Now;
            } else
            {
                until = (DateTime)To;
            }
            return getEntriesFromUrl(makeURL(serverURL, "/log/timestamp/" + From.ToString() + "/" + until.ToString()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="serverURL"></param>
        /// <returns></returns>
        public List<Entry> ReadNewest(int number = 1, string serverURL = "")
        {
            return getEntriesFromUrl(makeURL(serverURL, "/log/last/" + number.ToString()));
        }

        private List<Entry> getEntriesFromUrl(string url)
        {
            string output = getJSON(url);
            Entry[] deserializedEntry = JsonConvert.DeserializeObject<Entry[]>(output);
            return new List<Entry>(deserializedEntry);
        }

        private string makeURL(string alternativeURL, string addon)
        {
            Uri baseUri = new Uri(returnBaseURL(alternativeURL));
            return new Uri(baseUri, addon).ToString();
        }
        private string returnBaseURL(string alternativeURL)
        {
            return String.IsNullOrEmpty(alternativeURL) ? this.serverURL : alternativeURL;
        }
        /// <summary>
        /// Writes JSON to URL and returns the JSON Output as String
        /// </summary>
        /// <param name="json"></param>
        /// <param name="url"></param>
        /// <returns>json as string</returns>
        private string writeJSON(string json, string url)
        {
            //TODO: write json as string to url
        }
        /// <summary>
        /// Reads JSON from URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns>json as string</returns>
        private string getJSON(string url)
        {
            //TODO: get Json as String from url
        }
    }
}
