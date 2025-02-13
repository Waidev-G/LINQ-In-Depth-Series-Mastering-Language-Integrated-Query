using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes.DynamicCollections
{
    public class CustomList<T> : IEnumerable<T>
    {
        private class Node
        {
            internal T Data=default!;
            internal Node Next = default!;
        }
        private Node _head = default!;
        public void Add(T item)
        {
           
            Node n = new Node();
            n.Data = item;
            n.Next = _head;
            _head = n;
            
        }

       public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private Node head;
            private T _current=default!;
            private int _state = 0;
            private Node n = default!;
            public Enumerator(Node head)
            {
                this.head = head;
            }

            public T Current => _current;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                _state = -1;
            }

            public bool MoveNext()
            {
                try { 
                    
                    if (_state == 0)
                    {
                        n = head;
                        _state = 1;
                    }
                    if (n == null) { return false; }
                    _current = n.Data;
                    n = n.Next;
                    return true;
                }
                catch {

                    throw;
                }
                finally
                {
                    Dispose();
                }


            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
