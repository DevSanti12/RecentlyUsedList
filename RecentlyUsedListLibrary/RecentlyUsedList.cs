using System.Collections.Generic;

namespace RecentlyUsedListLibrary
{
    public class RecentlyUsedList
    {
        private readonly List<string> _list = new List<string>();

        public int Count => _list.Count;

        public void Add(string item)
        {
            //Insert item at the beginning lifo order
            _list.Insert(0, item);
        }

        public string this[int index]
        {
            get => _list[index];
        }
    }
}
