using System;
using System.Collections.Generic;
using System.Text;

namespace KeysKeyboard.CusInherit
{
    public class SimpleObserver<T> : IObserver<T>
    {
        private Action<T> _callback;

        public SimpleObserver(Action<T> callback)
        {
            this._callback = callback;
        }

        public void OnCompleted()
        {
            Console.WriteLine("OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnNext(T value)
        {
            this._callback(value);
        }
    }
}