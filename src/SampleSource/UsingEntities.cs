using System;
using NUnit.Framework;
using SampleSource.Domain;
using SampleSource.Domain.Identifiers;
using SampleSource.Messages;

namespace SampleSource
{
    namespace UsingEntities
    {
        [TestFixture]
        public class SampleUsage
        {
            TodoList _list;
            TodoListItemId _todoListItemId;

            [SetUp]
            public void SetUp()
            {
                _list = new TodoList(new TodoListId(Guid.NewGuid()), "Before my 40th birthday");
                _todoListItemId = new TodoListItemId(Guid.NewGuid());
                _list.AddNewItem(_todoListItemId, "Compose a piece of music");
                _list.ClearChanges();
            }

            [Test]
            public void Encapsulated_TodoListItem_Behavior_Changes_Are_Tracked()
            {
                _list.DescribeItem(_todoListItemId, "Compose a crappy piece of music");

                Assert.That(_list.GetChanges(), Is.EquivalentTo(
                    new Object[]
                    {
                        new DescribedTodoListItem(_todoListItemId, "Compose a crappy piece of music")
                    }));
            }

            [Test]
            public void Exposed_TodoListItem_Behavior_Changes_Are_Tracked()
            {
                _list.FindById(_todoListItemId).Describe("Compose a crappy piece of music");

                Assert.That(_list.GetChanges(), Is.EquivalentTo(
                    new Object[]
                    {
                        new DescribedTodoListItem(_todoListItemId, "Compose a crappy piece of music")
                    }));
            }
        }

        namespace Messaging
        {
        }
    }
}