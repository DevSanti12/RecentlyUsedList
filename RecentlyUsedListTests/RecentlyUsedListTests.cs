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

        [Fact]
        public void Add_DuplicateItemIsMovedToTheStart()
        {
            // Arrange
            var recentlyUsedList = new RecentlyUsedList();
            recentlyUsedList.Add("first");
            recentlyUsedList.Add("second");

            // Act
            recentlyUsedList.Add("first");

            // Assert
            Assert.Equal(2, recentlyUsedList.Count);
            Assert.Equal("first", recentlyUsedList[0]);
            Assert.Equal("second", recentlyUsedList[1]);
        }

        [Fact]
        public void Add_WhenCapacityExceeds_RemoveLeastRecentUsedItem()
        {
            //Arrange
            var recentlyUsedList = new RecentlyUsedList(5);

            //Act
            recentlyUsedList.Add("1");
            recentlyUsedList.Add("2");
            recentlyUsedList.Add("3");
            recentlyUsedList.Add("4");
            recentlyUsedList.Add("5");
            recentlyUsedList.Add("6");

            //Assert
            Assert.Equal(5, recentlyUsedList.Count);
            Assert.Equal("6", recentlyUsedList[0]);
            Assert.Equal("3", recentlyUsedList[3]);
            Assert.Equal("2", recentlyUsedList[4]);
        }

        [Fact]
        public void Indexer_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var recentlyUsedList = new RecentlyUsedList();
            recentlyUsedList.Add("1");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { var item = recentlyUsedList[-1]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var item = recentlyUsedList[1]; });
        }

        [Fact]
        public void Add_UnboundedList_DoesNotRemoveItems()
        {
            // Arrange
            var recentlyUsedList = new RecentlyUsedList(0); // 0 capacity means unbounded
            for (int i = 1; i <= 100; i++)
            {
                recentlyUsedList.Add($"item{i}");
            }

            // Assert
            Assert.Equal(100, recentlyUsedList.Count);
            Assert.Equal("item100", recentlyUsedList[0]);
        }
    }
}