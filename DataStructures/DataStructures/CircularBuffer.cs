using System;

namespace DataStructures
{
    public class CircularBuffer<T> : Buffer<T>
    {
        private int _capacity;

        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);

            if (_queue.Count > _capacity)
            {
                var discardedItem = _queue.Dequeue();
                OnItemDiscarded(discardedItem, value);
            }
        }

        private void OnItemDiscarded(T discardedItem, T value)
        {
            if (ItemDiscarded != null)
            {
                var args = new ItemDiscarded_EventArgs<T>(discardedItem, value);
                ItemDiscarded(this, args);
            }
        }

        public bool IsFull { get { return _queue.Count == _capacity; } }


        public event EventHandler<ItemDiscarded_EventArgs<T>> ItemDiscarded;
    }

    public class ItemDiscarded_EventArgs<T> : EventArgs
    {
        public ItemDiscarded_EventArgs(T discard, T newItem)
        {
            ItemDiscarded = discard;
            NewItemAdded = newItem;
        }

        public T ItemDiscarded { get; set; }

        public T NewItemAdded { get; set; }
    }
}
