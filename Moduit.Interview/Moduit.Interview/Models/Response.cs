using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Models
{
    public class Response
    {
        public long id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public List<string> tags { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class ResponseItems
    {
        public long id { get; set; }
        public int category { get; set; }
        public List<Item> items { get; set; }
        public List<string> tags { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
    }
}
