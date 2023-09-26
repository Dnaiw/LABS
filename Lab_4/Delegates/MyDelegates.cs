using Lab_4.Models;
using Lab_4.Models.Events;

namespace Lab_4.Delegates
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    delegate TKey KeySelector<TKey>(Student st);
}
