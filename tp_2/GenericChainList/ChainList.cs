using System;
using System.Collections.Generic;
using System.Text;

namespace GenericChainList
{
    public class ChainList<T>
    {
        public Container<T> First { get; private set; }

        public Container<T> Last 
        {
            get
            {
                Container<T> dernier = First ?? null;
                while(dernier.Next != null)
                {
                    dernier = dernier.Next;
                }
                return dernier;
            }
        }

        public void Ajouter(T element)
        {
            if (First == null)
            {
                First = new Container<T> { Value = element };
            } 
            else
            {
                Container<T> dernier = Last; 
                dernier.Next = new Container<T> { Value = element, Previous = dernier };
            }
        }

        public Container<T> RecupererMaillon(int indice)
        {
            if(First == null)
            {
                return null;
            }
            else
            {
                Container<T> temp = First;
                for (int i = 1; i <= indice; i++)
                {
                    temp = temp.Next;
                }
                return temp;
            }
        }

        public void InsererMaillon(T element, int indice)
        {
            if(indice < 0)
            {
                this.Ajouter(element);
            }
            else
            {
                if(indice == 1)
                {
                    Container<T> after = First;
                    First = new Container<T> { Value = element, Next = after};
                    after.Previous = First; 
                }
                else
                {
                    Container<T> recup = this.RecupererMaillon(indice);
                    Container<T> before = recup.Previous;
                    Container<T> after = before.Next;

                    Container<T> current = new Container<T> { Value = element, Next = after, Previous = before };
                    before.Next = current;
                }
            }
        }
    }
}
