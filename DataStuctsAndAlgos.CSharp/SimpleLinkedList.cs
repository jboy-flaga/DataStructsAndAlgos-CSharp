using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DataStuctsAndAlgos.CSharp
{
    public class SimpleLinkedList<T>
    {
        private class Cell
        {
            public T Item;
            public Cell Link;
        }

        private Cell _first;
        private Cell _last;
        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public T First
        {
            get { return this._first.Link == null ? default(T) : this._first.Link.Item; }
        }

        public T Last
        {
            get { return this._length == 0 ? default(T) : this[this._length - 1]; }
        }

        public SimpleLinkedList()
        {
            Cell dummyCell = new Cell { Item = default(T), Link = null };
            this._first = dummyCell;
            this._last = dummyCell;
            this._length = 0;
        }

        public T this[int index]
        {
            get
            {
                if (this._first.Link == null) { throw new IndexOutOfRangeException(); }
                if (index >= this._length) { throw new IndexOutOfRangeException(); }

                Cell currentCell = this._first.Link;
                for (int i = 0; i < index; i++)
                {
                    currentCell = currentCell.Link;
                }

                return currentCell.Item;
            }
            set
            {
                if (this._first.Link == null) { throw new IndexOutOfRangeException(); }
                if (index >= this._length) { throw new IndexOutOfRangeException(); }

                Cell currentCell = this._first.Link;
                for (int i = 0; i < index; i++)
                {
                    currentCell = currentCell.Link;
                }

                currentCell.Item = (T)value;
            }
        }

        public void Insert(T item)
        {
            Cell newCell = new Cell { Item = item, Link = null };
            this._last.Link = newCell;
            this._last = newCell;
            this._length++;
        }

        /** 
         * returns null if object to be removed is not found in the list else returns the removed item
         * 
         * */
        public T Remove(T item)
        {
            Cell previousCell = this._first;
            Cell currentCell = this._first.Link;
            while (currentCell != null)
            {
                if (currentCell.Item.Equals(item))
                {
                    previousCell.Link = currentCell.Link;
                    // delete currentCell - currentCell will be garbase collected
                    this._length--;
                    return currentCell.Item;
                }

                Cell nextCell = currentCell.Link;
                previousCell = currentCell;
                currentCell = nextCell;
            }

            return default(T);
        }
    }
}
