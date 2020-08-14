using System;
using System.Collections.Generic;
using System.Text;

namespace GenericChainList
{
    public class Container<T>
    {
        public Container<T> Next { get; set; }
        public Container<T> Previous { get; set; }
        public T Value { get; set; }
    }
}
