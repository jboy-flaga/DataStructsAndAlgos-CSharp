using System;
using DataStuctsAndAlgos.CSharp;
using Xunit;

namespace DataStructsAndAlgos.CSharp.Test
{
    public class SimpleLinkedListTest
    {
        #region Constructors
        public class DefaultConstructor
        {
            [Fact]
            public void DefaultConstructor_SetsLengthToZero()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<String>();

                Assert.Equal(0, linkedList.Count);
            }
        }
        #endregion
        #region Properties
        public class FirstProperty
        {
            [Fact]
            public void FirstProperty_ReturnsTheCorrectNodeInListWithMultipleItems()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("qwer");
                linkedList.AddFirst("zxcv");

                Assert.Equal("zxcv", linkedList.First.Item);
            }

            [Fact]
            public void FirstProperty_ReturnsTheOnlyNodeInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");

                Assert.Equal("asdf", linkedList.First.Item);
            }

            [Fact]
            public void FirstProperty_ThrowsInvalidOperationExceptionIfListIsEmpty()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.First;
                    });
            }
        }

        public class LastProperty
        {
            [Fact]
            public void LastProperty_ReturnsTheCorrectNodeInListWithMultipleItems()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("qwer");
                linkedList.AddFirst("zxcv");

                Assert.Equal("asdf", linkedList.Last.Item);
            }

            [Fact]
            public void LastProperty_ReturnsTheOnlyNodeInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");

                Assert.Equal("asdf", linkedList.Last.Item);
            }

            [Fact]
            public void LastProperty_ThrowsInvalidOperationExceptionIfListIsEmpty()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.Last;
                    });
            }
        }

        public class CountProperty
        {
            [Fact]
            public void CountProperty_ReturnsAccurateCount()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                int expectedCount = 0;
                linkedList.AddLast("asdf"); expectedCount++;
                linkedList.AddLast("qwer"); expectedCount++;
                linkedList.AddLast("zxcv"); expectedCount++;

                Assert.Equal(expectedCount, linkedList.Count);
            }
        }

        public class IsEmptyProperty
        {
            [Fact]
            public void IsEmpty_ReturnsTrueIfListIsEmpty()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                Assert.True(linkedList.IsEmpty);
            }

            [Fact]
            public void IsEmpty_ReturnsFalseIfListIsNotEmpty()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("asdf");

                Assert.False(linkedList.IsEmpty);
            }
        }
        #endregion

        #region Methods
        public class AddFirstMethod
        {
            [Fact]
            public void AddFirstMethod_AddsNewItemAtTheHeadOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                linkedList.AddFirst("new Item 1");

                Assert.ReferenceEquals(linkedList.First, "new Item 1");
                Assert.Equal("new Item 1", linkedList.First.Item);
            }

            [Fact]
            public void AddFirstMethod_SetsThe_LinkProperty_OfTheCurrentHeadToThePreviousHeadOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                linkedList.AddFirst("new Item 1");
                linkedList.AddFirst("new Item 2");

                Assert.ReferenceEquals(linkedList.First.Link, "new Item 1");
                Assert.Equal("new Item 1", linkedList.First.Link.Item);
            }

            [Fact]
            public void AddFirstMethod_IncrementsLengthOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                int expectedCount = 0;

                linkedList.AddFirst("asdf"); expectedCount++;

                Assert.Equal(expectedCount, linkedList.Count);
            }
        }

        public class AddLastMethod
        {
            [Fact]
            public void AddLastMethod_AddsNewItemAtTheTailOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                linkedList.AddLast("new Item 1");
                linkedList.AddLast("new Item 2");

                Assert.ReferenceEquals(linkedList.Last, "new Item 2");
                Assert.True(linkedList.Last.Item == "new Item 2");
            }

            [Fact]
            public void AddLastMethod_SetsThe_LinkProperty_OfThePreviousTailToTheCurrentTailOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                linkedList.AddLast("new Item 1");
                LinkedListNode<string> previousTail = linkedList.Last;

                linkedList.AddLast("new Item 2");
                LinkedListNode<string> currentTail = linkedList.Last;

                Assert.ReferenceEquals(previousTail.Link, currentTail);
                Assert.Equal("new Item 2", previousTail.Link.Item);
            }

            [Fact]
            public void AddLastMethod_IncrementsLengthOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();

                linkedList.AddLast("asdf");

                Assert.True(linkedList.Count == 1);
            }
        }

        public class FindMethod
        {
            [Fact]
            public void FindMethod_ReturnsCorrectNode()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("qwer");

                LinkedListNode<string> node = linkedList.Find("asdf");

                Assert.NotNull(node);
                Assert.Equal("asdf", node.Item);
            }

            [Fact]
            public void FindMethod_ReturnsNullIfItemIsNotFound()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("qwer");

                LinkedListNode<string> node = linkedList.Find("zzzzzzzzzzzz");

                Assert.Null(node);
            }
        }

        public class RemoveMethod
        {
            [Fact]
            public void RemoveMethod_RemovesCorrectItemFromListWithMultipleItems()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("middle");
                linkedList.AddFirst("qwer");

                linkedList.Remove("middle");

                Assert.Null(linkedList.Find("middle"));
            }

            [Fact]
            public void RemoveMethod_RemovesTheOnlyItemFromList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");

                linkedList.Remove("asdf");

                Assert.Null(linkedList.Find("asdf"));
            }

            [Fact]
            public void RemoveMethod_SetsThe_FirstProperty_ToTheSecondNodeIfTheItemToBeRemovedIsTheHeadOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("new Item 1");
                linkedList.AddFirst("new Item 2");

                linkedList.Remove("new Item 2");

                Assert.Equal("new Item 1", linkedList.First.Item);
            }

            [Fact]
            public void RemoveMethod_SetsThe_LastProperty_ToTheSecondToLastNodeIfTheItemToBeRemovedIsTheTailOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");
                linkedList.AddLast("new Item 2");

                linkedList.Remove("new Item 2");

                Assert.Equal("new Item 1", linkedList.Last.Item);
            }

            [Fact]
            public void RemoveMethod_SetsThe_LinkProperty_Of_LastProperty_ToNull()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");
                linkedList.AddLast("new Item 2");

                linkedList.Remove("new Item 2");

                Assert.Null(linkedList.Last.Link);
            }

            [Fact]
            public void RemoveMethod_SetsThe_FirstProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("new Item 1");

                linkedList.Remove("new Item 1");
                                // Assert
                // acessing linkedList.First throws exception if the head of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.First;
                    });
            }

            [Fact]
            public void RemoveMethod_SetsThe_LastProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");

                linkedList.Remove("new Item 1");

                // acessing linkedList.Last throws exception if the tail of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.Last;
                    });
            }

            [Fact]
            public void RemoveMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                int expectedCount = 0;
                linkedList.AddLast("asdf"); expectedCount++;
                linkedList.AddLast("qwer"); expectedCount++;
                linkedList.AddLast("zxcv"); expectedCount++;

                linkedList.Remove("asdf"); expectedCount--;

                Assert.Equal(expectedCount, linkedList.Count);
            }

            [Fact]
            public void RemoveMethod_ReturnsFalseIfItemToBeRemovedIsNotFound()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("asdf");
                linkedList.AddLast("qwer");

                bool result = linkedList.Remove("zzzzzzzzzzzzz");

                Assert.False(result);
            }
            
            [Fact]
            public void RemoveMethod_ReturnsTrueIfItemToBeRemovedIsFound()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("asdf");
                linkedList.AddLast("qwer");

                bool result = linkedList.Remove("asdf");

                Assert.True(result);
            }
        }

        public class RemoveFirstMethod
        {
            [Fact]
            public void RemoveFirstMethod_RemovesTheFirstItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");
                linkedList.AddFirst("qwer");

                linkedList.RemoveFirst();

                Assert.NotEqual("qwer", linkedList.First.Item);
            }

            [Fact]
            public void RemoveFirstMethod_RemovesTheOnlyItemFromList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("asdf");

                linkedList.RemoveFirst();

                Assert.Null(linkedList.Find("asdf"));
            }

            [Fact]
            public void RemoveFirstMethod_SetsThe_FirstProperty_ToTheSecondNodeIfTheItemToBeRemovedIsTheHeadOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("new Item 1");
                linkedList.AddFirst("new Item 2");

                linkedList.RemoveFirst();

                Assert.Equal("new Item 1", linkedList.First.Item);
            }

            [Fact]
            public void RemoveFirstMethod_SetsThe_FirstProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("new Item 1");

                linkedList.RemoveFirst();

                // acessing linkedList.First throws exception if the head of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.First;
                    });
            }

            [Fact]
            public void RemoveFirstMethod_SetsThe_LastProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");

                linkedList.RemoveFirst();

                // acessing linkedList.Last throws exception if the tail of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.Last;
                    });
            }

            [Fact]
            public void RemoveFirstMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                int expectedCount = 0;
                linkedList.AddFirst("asdf"); expectedCount++;
                linkedList.AddFirst("qwer"); expectedCount++;

                linkedList.RemoveFirst(); expectedCount--;

                Assert.Equal(expectedCount, linkedList.Count);
            }
        }

        public class RemoveLastMethod
        {
            [Fact]
            public void RemoveLastMethod_RemovesTheLastItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("asdf");
                linkedList.AddLast("qwer");

                linkedList.RemoveLast();

                Assert.NotEqual("qwer", linkedList.Last.Item);
            }

            [Fact]
            public void RemoveLastMethod_RemovesTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("asdf");

                linkedList.RemoveLast();

                Assert.Null(linkedList.Find("asdf"));
            }

            [Fact]
            public void RemoveLastMethod_SetsThe_LastProperty_ToTheSecondToLastNodeIfTheItemToBeRemovedIsTheTailOfTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");
                linkedList.AddLast("new Item 2");

                linkedList.RemoveLast();

                Assert.Equal("new Item 1", linkedList.Last.Item);
            }

            [Fact]
            public void RemoveLastMethod_SetsThe_FirstProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddFirst("new Item 1");

                linkedList.RemoveLast();

                // acessing linkedList.First throws exception if the head of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.First;
                    });
            }

            [Fact]
            public void RemoveLastMethod_SetsThe_LastProperty_ToNullIfTheItemToBeRemovedIsTheOnlyItemInTheList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                linkedList.AddLast("new Item 1");

                linkedList.RemoveLast();

                // acessing linkedList.Last throws exception if the tail of the list is null
                Assert.Throws<InvalidOperationException>(
                    delegate
                    {
                        LinkedListNode<string> node = linkedList.Last;
                    });
            }

            [Fact]
            public void RemoveLastMethod_DecrementsLengthOfList()
            {
                SimpleLinkedList<string> linkedList = new SimpleLinkedList<string>();
                int expectedCount = 0;
                linkedList.AddFirst("asdf"); expectedCount++;
                linkedList.AddFirst("qwer"); expectedCount++;

                linkedList.RemoveLast(); expectedCount--;

                Assert.Equal(expectedCount, linkedList.Count);
            }
        }
        #endregion
    }
}
