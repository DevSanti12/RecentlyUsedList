using RecentlyUsedListLibrary;

namespace RecentlyUsedListTests
{
    public class RecentlyUsedListTests
    {
        [Fact]
        public void RecentlyUsedList_EmptyAtStart()
        {
            //Arrange and Act
            var recentlyUsedList = new RecentlyUsedList();

            //Assert
            Assert.Equal(0, recentlyUsedList.Count);
        }
    }
}