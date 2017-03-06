using System;
using AggregateSource;
using SampleSource.Domain.Identifiers;
using SampleSource.Messages;

namespace SampleSource.Domain
{
    public class TodoListItem : Entity
    {
        public TodoListItem(Action<object> applier) : base(applier)
        {
            Register<AddedNewItemToTodoList>(When);
            Register<DescribedTodoListItem>(When);
        }

        public void Describe(string description)
        {
            Apply(new DescribedTodoListItem(Id, description));
        }

        public TodoListItemId Id { get; private set; }

        void When(AddedNewItemToTodoList @event)
        {
            Id = new TodoListItemId(@event.TodoListItemId);
        }

        void When(DescribedTodoListItem @event)
        {
            /* just so you can see we really get to this point */
        }
    }
}