using System;

namespace SampleSource.Domain.Identifiers
{
    public struct TodoListItemId : IEquatable<TodoListItemId>
    {
        readonly Guid _value;

        public TodoListItemId(Guid value)
        {
            _value = value;
        }

        public bool Equals(TodoListItemId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TodoListItemId && Equals((TodoListItemId) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static implicit operator Guid(TodoListItemId id)
        {
            return id._value;
        }
    }
}