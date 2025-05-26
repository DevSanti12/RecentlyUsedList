namespace RecentlyUsedListLibrary
{
    public class RecentlyUsedList
    {
        private readonly List<string> _list = new List<string>();
        private readonly int _capacity;

        public int Count => _list.Count;
        

        public RecentlyUsedList(int capacity = 5) //Default set to 5
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity must be greater than zero", nameof(capacity));

            _capacity = (capacity <= 0) ? int.MaxValue : capacity;
        }

        public void Add(string item)
        {
            if(item == null)
                throw new ArgumentNullException();

            //Remove if item already exists
            _list.Remove(item);

            //Insert item at the beginning lifo order
            _list.Insert(0, item);

            //Enforce capacity limit
            if(_list.Count > _capacity)
            {
                _list.RemoveAt(_list.Count - 1); //Remove least recently used item
            }
        }

        public string this[int index]
        {
            get
            {
                if(index < 0 || index >= _list.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return _list[index];
            }
        }
    }
}
