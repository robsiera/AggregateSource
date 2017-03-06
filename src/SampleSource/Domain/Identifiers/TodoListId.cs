using System;

namespace SampleSource.Domain.Identifiers
{
    public struct TodoListId : IEquatable<TodoListId>
    {
        readonly Guid _value;

        public TodoListId(Guid value)
        {
            _value = value;
        }

        public bool Equals(TodoListId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TodoListId && Equals((TodoListId) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static implicit operator Guid(TodoListId id)
        {
            return id._value;
        }
    }
}