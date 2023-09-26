namespace Lab_5.Models.Events
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
            this.Collection = collection;
            this.Action = action;
            this.Property = property;
            this.Key = key;
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
