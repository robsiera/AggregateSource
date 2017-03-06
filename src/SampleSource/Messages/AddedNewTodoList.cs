using System;

namespace SampleSource.Messages
{
    public class AddedNewTodoList
    {
        protected bool Equals(AddedNewTodoList other)
        {
            return this.Id.Equals(other.Id) && string.Equals(this.Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AddedNewTodoList) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ (Name?.GetHashCode() ?? 0);
        }

        public readonly Guid Id;
        public readonly string Name;

        public AddedNewTodoList(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}