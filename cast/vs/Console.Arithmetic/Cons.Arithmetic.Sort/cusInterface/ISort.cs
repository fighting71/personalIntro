using System;
using System.Collections.Generic;

namespace Cons.Arithmetic.Sort
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISort<T>
    {

        IEnumerable<T> Sort(IEnumerable<T> source, Func<T, T, bool> compareFunc);

    }
}
