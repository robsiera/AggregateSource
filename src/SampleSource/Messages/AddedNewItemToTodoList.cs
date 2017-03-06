using System;

namespace SampleSource.Messages
{
    public class AddedNewItemToTodoList
    {
        protected bool Equals(AddedNewItemToTodoList other)
        {
            return TodoListId.Equals(other.TodoListId) && TodoListItemId.Equals(other.TodoListItemId) && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AddedNewItemToTodoList) obj);
        }

        public override int GetHashCode()
        {
            return TodoListId.GetHashCode() ^ TodoListItemId.GetHashCode() ^ (Description?.GetHashCode() ?? 0);
        }

        public readonly Guid TodoListId;
        public readonly Guid TodoListItemId;
        public readonly string Description;

        public AddedNewItemToTodoList(Guid todoListId, Guid todoListItemId, string description)
        {
            TodoListId = todoListId;
            TodoListItemId = todoListItemId;
            Description = description;
        }
    }
}