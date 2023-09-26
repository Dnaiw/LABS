namespace Lab_5.Models.Events
{
    internal sealed class Journal<Tkey> where Tkey : notnull 
    {
        private DateTime startDateTime;
        private List<JournalEntry> _entries;

        private static Journal<Tkey> _instance = null;
        private static readonly object threadlock = new object();

        private Journal()
        {
            this.startDateTime = DateTime.Now;
            this._entries = new List<JournalEntry>();
        }

        public static Journal<Tkey> Instance
        {
            get
            {
                lock (threadlock)
                {
                    if (_instance == null)
                        _instance = new Journal<Tkey>();
                }

                return _instance;
            }
        }

        public void StudentChanged(object sender, StudentsChangedEventArgs<Tkey> args)
        {
            this._entries.Add(new JournalEntry(args.Collection, args.Action, args.Property, args.Element.ToString() ?? "null"));
        }

        public override string ToString()
        {
            string result = $"Created: {this.startDateTime}\n" +
                            $"Events:\n";
            
            foreach (JournalEntry entry in this._entries)
            {
                result += "\n-------------------\n";
                result += entry.ToString();
            }
            
            return result;
        }
    }
}
