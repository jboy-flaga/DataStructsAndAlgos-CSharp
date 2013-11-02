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

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return this.Count <= 0; }
        }
        #endregion

        #region Constructors
        public SimpleLinkedList()
        {
            this.Count = 0;
        }
        #endregion

        #region Public Methods
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

        public void AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> { Item = item, Link = null };

            if (this._head == null)
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

            if (this._tail == null)
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

        /** 
         * returns null if object to be removed is not found in the list else returns the removed item
         * 
         * */
        public bool Remove(T item)
        {
            LinkedListNode<T> previousNode = this._head;
            LinkedListNode<T> currentNode = this._head;
            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    previousNode.Link = currentNode.Link;
                    // at this point the previous currentNode will be ready for garbage collection
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
            if (this.IsEmpty || this._head == null)
            {
                throw new InvalidOperationException("RemoveFirst() cannot be called if the list is empty");
            }

            this._head = this._head.Link;
        }

        public void RemoveLast()
        {
            if (this.IsEmpty || this._tail == null)
            {
                throw new InvalidOperationException("RemoveFirst() cannot be called if the list is empty");
            }

            LinkedListNode<T> currentNode = this._head;
            while (currentNode != null)
            {
                if (currentNode.Link.Link == null)
                {
                    currentNode.Link = null;
                    break;
                }

                currentNode = currentNode.Link;
            }
        }
        #endregion
    }
}
