using System;

namespace DataStuctsAndAlgos.CSharp
{
    public class SimpleLinkedList<T>
    {
        #region Private Fields
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;
        #endregion

        #region Public Properties        
        public int Count { get; private set; }

        public LinkedListNode<T> First
        {
            get
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("First cannot be called if list is empty");
                }
                return this._head;
            }
        }

        public bool IsEmpty
        {
            get { return this.Count <= 0; }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Last cannot be called if list is empty");
                }
                return this._tail;
            }
        }
        #endregion

        #region Constructors
        public SimpleLinkedList()
        {
            this.Count = 0;
        }
        #endregion

        #region Public Methods
               public void AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> { Item = item, Link = null };

            if (this.IsEmpty)
            {
                this._head = this._tail = newNode;
            }
            else
            {
                newNode.Link = this._head;
                this._head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> { Item = item, Link = null };

            if (this.IsEmpty)
            {
                this._head = this._tail = newNode;
            }
            else
            {
                this._tail.Link = newNode;
                this._tail = newNode;
            }

            this.Count++;
        }

        public LinkedListNode<T> Find(T item)
        {
            LinkedListNode<T> currentNode = this._head;
            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return currentNode;
                }
                currentNode = currentNode.Link;
            }

            return null;
        }

        /** 
         * returns null if object to be removed is not found in the list else returns the removed item
         * 
         * */
        public bool Remove(T item)
        {
            if (this._head.Item.Equals(item)) // if the item to be deleted is in the head of the list
            {
                this.RemoveFirst();
                return true;
            }

            LinkedListNode<T> previousNode = this._head;
            LinkedListNode<T> currentNode = this._head.Link;
            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    previousNode.Link = currentNode.Link;
                    // at this point the node to be deleted (the previous current node) will be ready for garbage collection

                    if (object.ReferenceEquals(currentNode, this._tail)) // if the item to be deleted is in the tail of the list
                    {
                        this._tail = previousNode;
                    }

                    this.Count--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Link;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (this.IsEmpty) { throw new InvalidOperationException("RemoveFirst() cannot be called if the list is empty"); }

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._head = this._head.Link;
            }

            this.Count--;
        }

        public void RemoveLast()
        {
            if (this.IsEmpty) { throw new InvalidOperationException("RemoveLast() cannot be called if the list is empty"); }

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                LinkedListNode<T> currentNode = this._head;
                while (currentNode != null)
                {
                    if (currentNode.Link.Link == null)
                    {
                        currentNode.Link = null;
                        this._tail = currentNode;
                        break;
                    }

                    currentNode = currentNode.Link;
                }
            }

            this.Count--;
        }
        #endregion
    }
}
