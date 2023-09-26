using System.Diagnostics;
using Lab_4.Delegates;

namespace Lab_4.Models.Collections
{
    internal class TestCollections<TKey, TValue>
    {
        private readonly List<TKey> _keysList = new();
        private readonly List<string> _stringsList = new();
        private static readonly Dictionary<TKey, TValue> dictionary = new();
        private readonly Dictionary<TKey, TValue> _valuesDictionary = new();
        private readonly Dictionary<string, TValue> _stringsDictionary = new();
        private readonly GenerateElement<TKey, TValue> _generator;
        private readonly Dictionary<TKey, string> _searchedElements;

        public TestCollections(int number, GenerateElement<TKey, TValue> generator)
        {
            this._generator = generator;

            for (int i = 0; i < number; i++)
            {
                KeyValuePair<TKey, TValue> generated = this._generator(i);

                this._keysList.Add(generated.Key);
                this._stringsList.Add(generated.Key.ToString());

                this._valuesDictionary.Add(generated.Key, generated.Value);
                this._stringsDictionary.Add(generated.Key.ToString(), generated.Value);
            }

            this._searchedElements = new Dictionary<TKey, string>
            {
                {generator(0).Key, "first element"},
                {generator(number / 2).Key, "center element"},
                {generator(number  - 1).Key, "last element"},
                {generator(number).Key, "non-existed element"}
            };

        }

        public List<TestCollectionTimeTestReply> TestAll()
        {
            TestCollectionTimeTestReply keyListTestReply = new TestCollectionTimeTestReply()
            {
                Name = "Test for key list",
            };
            TestCollectionTimeTestReply stringListTestReply = new TestCollectionTimeTestReply()
            {
                Name = "Test for string list",
            };
            TestCollectionTimeTestReply keyDictTestReply = new TestCollectionTimeTestReply()
            {
                Name = "Test for key dictionary",
            };
            TestCollectionTimeTestReply stringDictTestReply = new TestCollectionTimeTestReply()
            {
                Name = "Test for string dictionary",
            };

            foreach (KeyValuePair<TKey, string> keyValuePair in this._searchedElements)
            {
                if (keyValuePair.Value == "first element")
                {
                    keyListTestReply.FirstElement = this.GetKeyListTime(keyValuePair.Key);
                    stringListTestReply.FirstElement = this.GetStringListTime(keyValuePair.Key.ToString());
                    keyDictTestReply.FirstElement = this.GetKeysDictionaryTime(keyValuePair.Key);
                    stringDictTestReply.FirstElement = this.GetStringDictionaryTime(keyValuePair.Key.ToString());
                }

                if (keyValuePair.Value == "last element")
                {
                    keyListTestReply.LastElement = this.GetKeyListTime(keyValuePair.Key);
                    stringListTestReply.LastElement = this.GetStringListTime(keyValuePair.Key.ToString());
                    keyDictTestReply.LastElement = this.GetKeysDictionaryTime(keyValuePair.Key);
                    stringDictTestReply.LastElement = this.GetStringDictionaryTime(keyValuePair.Key.ToString());

                }

                if (keyValuePair.Value == "center element")
                {
                    keyListTestReply.CenterElement = this.GetKeyListTime(keyValuePair.Key);
                    stringListTestReply.CenterElement = this.GetStringListTime(keyValuePair.Key.ToString());
                    keyDictTestReply.CenterElement = this.GetKeysDictionaryTime(keyValuePair.Key);
                    stringDictTestReply.CenterElement = this.GetStringDictionaryTime(keyValuePair.Key.ToString());

                }

                if (keyValuePair.Value == "non-existed element")
                {
                    keyListTestReply.NotExistingElement = this.GetKeyListTime(keyValuePair.Key);
                    stringListTestReply.NotExistingElement = this.GetStringListTime(keyValuePair.Key.ToString());
                    keyDictTestReply.NotExistingElement = this.GetKeysDictionaryTime(keyValuePair.Key);
                    stringDictTestReply.NotExistingElement = this.GetStringDictionaryTime(keyValuePair.Key.ToString());

                }
            }

            return new List<TestCollectionTimeTestReply>()
            {
                keyListTestReply, 
                stringListTestReply,
                stringDictTestReply, 
                keyDictTestReply
            };
        }

        private long GetKeyListTime(TKey key)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this._keysList.Contains(key);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private long GetStringListTime(string key)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this._stringsList.Contains(key);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private long GetKeysDictionaryTime(TKey key)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this._valuesDictionary.ContainsKey(key);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private long GetStringDictionaryTime(string key)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this._stringsDictionary.ContainsKey(key);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
