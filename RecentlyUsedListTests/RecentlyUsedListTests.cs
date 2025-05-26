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

        [Fact]
        public void Add_AddsItemToTheList()
        {
            //Arrange
            var recentlyUsedList = new RecentlyUsedList();

            //Act
            recentlyUsedList.Add("one");

            //Assert
            Assert.Equal(1, recentlyUsedList.Count);
            Assert.Equal("one", recentlyUsedList[0]);
        }

        [Fact]
        public void RecentlyUsedList_NullAdd_ReturnsArgumentNullException()
        {
            //Arrange
            var recentlyUsedList = new RecentlyUsedList();

            string nullArg = null;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => recentlyUsedList.Add(nullArg));
        }
    }
}