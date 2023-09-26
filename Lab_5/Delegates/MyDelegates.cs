using Lab_5.Models;

namespace Lab_5.Delegates
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    delegate TKey KeySelector<TKey>(Student st);
}
