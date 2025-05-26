namespace RecentlyUsedListLibrary
{
    public class RecentlyUsedList
    {
        private readonly List<string> _list = new List<string>();

        public int Count => _list.Count;
    }
}
