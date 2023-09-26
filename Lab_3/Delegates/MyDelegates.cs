using Lab_3.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Delegates
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    delegate TKey KeySelector<TKey>(Student st);
}
