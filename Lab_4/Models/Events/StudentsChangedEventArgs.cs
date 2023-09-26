using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models.Events
{
    public class StudentsChangedEventArgs<TKey>: EventArgs
    {
        public StudentsChangedEventArgs(
            string collection,
            Action action,
            string property, 
            TKey element)
        {
            this.Collection = collection;
            this.Action = action;
            this.Property = property;
            this.Element = element;
        }

        public string Collection { get; set; } = string.Empty;
        public Action Action { get; set; }
        public string Property { get; set; } = string.Empty;
        public TKey Element { get; set; }

        public override string ToString()
        {
            return $"Collection: {this.Collection}\n" +
                   $"Action: {this.Action}\n" +
                   $"Property: {this.Property}\n" +
                   $"Element: {this.Element}";
        }
    }
}
