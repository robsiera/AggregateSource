using System.Collections.Generic;
using AggregateSource;
using SampleSource.Domain.Identifiers;
using SampleSource.Messages;

namespace SampleSource.Domain
{
    public class TodoList : AggregateRootEntity
    {
        private TodoList()
        {
            Register<AddedNewTodoList>(When);
            Register<AddedNewItemToTodoList>(When);
            Register<DescribedTodoListItem>(When);
        }

        public TodoList(TodoListId id, string name) : this()
        {
            ApplyChange(new AddedNewTodoList(id, name));
        }

        public void AddNewItem(TodoListItemId itemId, string description)
        {
            ApplyChange(new AddedNewItemToTodoList(Id, itemId, description));
        }

        public void DescribeItem(TodoListItemId itemId, string description)
        {
            ApplyChange(new DescribedTodoListItem(itemId, description));
        }

        public TodoListItem FindById(TodoListItemId itemId)
        {
            return _items.Find(item => item.Id.Equals(itemId));
        }


        // state

        public TodoListId Id { get; private set; }
        private List<TodoListItem> _items;


        private void When(AddedNewTodoList @event)
        {
            Id = new TodoListId(@event.Id);
            _items = new List<TodoListItem>();
        }

        private void When(AddedNewItemToTodoList @event)
        {
            var item = new TodoListItem(ApplyChange);
            item.Route(@event);
            _items.Add(item);
        }

        private void When(DescribedTodoListItem @event)
        {
            _items.Find(item => item.Id == @event.Id).Route(@event);
        }
    }
}