using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models.Events
{
    internal class JournalEntry
    {
        public string Collection { get; set; }
        public Action Action { get; set; }
        public string Property { get; set; }
        public string Key { get; set; }

        public JournalEntry(
            string collection, 
            Action action, 
            string property, 
            string key)
        {
            Collection = collection;
            Action = action;
            Property = property;
            Key = key;
        }

        public override string ToString()
        {
            return $"Collection: {this.Collection}\n" +
                   $"Action: {this.Action}\n" +
                   $"Property: {this.Property}\n" +
                   $"Key: {this.Key}";
        }
    }
}
