using System;
using DataStuctsAndAlgos.CSharp;
using Xunit;

namespace DataStructsAndAlgos.CSharp.Test
{
    public class SimpleLinkedListTest
    {
        public class FirstProperty
        {
            [Fact]
            public void FirstProperty_ReturnsFirstItemInList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");

                Assert.Equal("asdf", list.First.Item);
            }
        }

        public class LastProperty
        {
            [Fact]
            public void LastProperty_ReturnsLastItemInList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");
                list.AddLast("zxcv");

                Assert.Equal("zxcv", list.Last.Item);
            }
        }

        public class CountProperty
        {
            [Fact]
            public void CountProperty_ReturnsAccurateCount()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");
                list.AddLast("zxcv");

                Assert.Equal(3, list.Count);
            }
        }

        public class IsEmptyProperty
        {
            [Fact]
            public void IsEmpty_ReturnsTrueIfListIsEmpty()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                Assert.True(list.IsEmpty);
            }

            [Fact]
            public void IsEmpty_ReturnsFalseIfListIsNotEmpty()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");

                Assert.False(list.IsEmpty);
            }
        }


        public class AddFirstMethod
        {
            [Fact]
            public void AddFirstMethod_AddsNewItemAtTheHeadOfList()
            {
                // Arrange
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                string newItem1 = "new Item 1";
                string newItem2 = "new Item 2";

                // Act
                list.AddFirst(newItem1);
                list.AddFirst(newItem2);

                // Assert
                Assert.ReferenceEquals(list.First, newItem2);
                Assert.Equal("new Item 2", list.First.Item);
            }


            [Fact]
            public void AddFirstMethod_IncrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.AddFirst("asdf");

                Assert.True(list.Count == 1);
            }
        }

        public class AddLastMethod
        {
            [Fact]
            public void AddLastMethod_AddsNewItemAtTheEndOfList()
            {
                // Arrange
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                string newItem1 = "new Item 1";
                string newItem2 = "new Item 2";

                // Act
                list.AddLast(newItem1);
                list.AddLast(newItem2);

                // Assert
                Assert.ReferenceEquals(list.Last, newItem2);
                Assert.True(list.Last.Item == "new Item 2");
            }

            [Fact]
            public void AddLastMethod_IncrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();

                list.AddLast("asdf");

                Assert.True(list.Count == 1);
            }
        }

        public class RemoveMethod
        {
            [Fact]
            public void RemoveMethod_RemovesFirstItemFromList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");

                list.Remove("asdf");

                Assert.Null(list.Find("asdf"));
            }

            [Fact]
            public void RemoveMethod_RemovesLastItemFromList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");

                list.Remove("qwer");

                Assert.Null(list.Find("qwer"));
            }

            [Fact]
            public void RemoveMethod_RemovesMiddleItemFromList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("middle");
                list.AddFirst("qwer");

                list.Remove("middle");

                Assert.Null(list.Find("middle"));
            }

            [Fact]
            public void RemoveMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");
                list.AddLast("zxcv");
                int expectedCount = list.Count - 1;

                list.Remove("asdf");

                Assert.Equal(expectedCount, list.Count);
            }

            [Fact]
            public void RemoveMethod_ReturnsFalseIfItemIsNotFound()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");

                bool result = list.Remove("zzzzzzzzzzzzz");

                Assert.False(result);
            }
        }

        public class FindMethod
        {
            [Fact]
            public void FindMethod_ReturnsCorrectNode()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");

                LinkedListNode<string> node = list.Find("asdf");

                Assert.NotNull(node);
                Assert.Equal("asdf", node.Item);
            }

            [Fact]
            public void FindMethod_ReturnsNullIfItemIsNotFound()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");

                LinkedListNode<string> node = list.Find("zzzzzzzzzzzz");

                Assert.Null(node);
            }
        }

        public class RemoveFirstMethod
        {
            [Fact]
            public void RemoveFirstMethod_RemovesTheFirstItemInTheList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");

                list.RemoveFirst();

                Assert.NotEqual("qwer", list.First.Item);
            }

            public void RemoveFirstMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");
                int expectedCount = list.Count - 1;

                list.RemoveFirst();

                Assert.Equal(expectedCount, list.Count);
            }
        }

        public class RemoveLastMethod
        {
            [Fact]
            public void RemoveLastMethod_RemovesTheLastItemInTheList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddLast("asdf");
                list.AddLast("qwer");

                list.RemoveLast();

                Assert.NotEqual("qwer", list.First.Item);
            }

            public void RemoveLastMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> list = new SimpleLinkedList<string>();
                list.AddFirst("asdf");
                list.AddFirst("qwer");
                int expectedCount = list.Count - 1;

                list.RemoveLast();

                Assert.Equal(expectedCount, list.Count);
            }
        }
    }
}
