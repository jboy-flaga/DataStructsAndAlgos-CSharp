using System;
using DataStuctsAndAlgos.CSharp;
using Xunit;

namespace DataStructsAndAlgos.CSharp.Test
{
    public class SimpleLinkedListTest
    {
        public class Indexer
        {
            [Fact]
            public void ThrowsIndexOutOfRangeExceptionIfIndexIsNotValid()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                Assert.ThrowsDelegate act = delegate { list[777] = "asdf"; };

                Assert.Throws<IndexOutOfRangeException>(act);
            }

            [Fact]
            public void ReturnsCorrectItem()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");

                Assert.True((list[0] as string) == "asdf");
                Assert.True((list[1] as string) == "qwer");
            }

            [Fact]
            public void SetsCorrectItemInList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");
                list.Insert("zxcv");

                list[1] = "aaaa";

                Assert.True((list[0] as string) == "asdf");
                Assert.True((list[1] as string) != "qwer");
                Assert.True((list[1] as string) == "aaaa");
            }
        }

        public class InsertMethod
        {
            [Fact]
            public void InsertsNewItemInList()
            {
                // Arrange
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                string newItem1 = "new Item 1";
                string newItem2 = "new Item 2";
                // Act
                list.Insert(newItem1);
                list.Insert(newItem2);

                // Assert
                Assert.ReferenceEquals((list[0] as string), newItem1);
                Assert.True((list[0] as string) == "new Item 1");
                Assert.ReferenceEquals((list[1] as string), newItem2);
                Assert.True((list[1] as string) == "new Item 2");
            }

            [Fact]
            public void IncrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");

                Assert.True(list.Length == 1);
            }
        }

        public class RemoveMethod
        {
            [Fact]
            public void RemovesNewItemFromList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");
                list.Remove("asdf");

                Assert.True((list[0] as string) != "asdf");
            }

            [Fact]
            public void DecrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");
                list.Insert("zxcv");
                list.Remove("asdf");

                Assert.True(list.Length == 2);
            }

            [Fact]
            public void ReturnsNullIfItemIsNotFound()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");
                string removedItem = list.Remove("zzzzzzzzzzzzz");

                Assert.Null(removedItem);
            }
        }

        public class FirstProperty
        {
            [Fact]
            public void ReturnsFirstItemInList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");

                Assert.True(list.First == "asdf");
            }
        }

        public class LastProperty
        {
            [Fact]
            public void ReturnsLastItemInList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.Insert("asdf");
                list.Insert("qwer");
                list.Insert("zxcv");

                Assert.True(list.Last == "zxcv");
            }
        }
    }
}
