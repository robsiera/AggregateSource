using System;

namespace SampleSource.Messages
{
    public class DescribedTodoListItem
    {
        protected bool Equals(DescribedTodoListItem other)
        {
            return string.Equals(Description, other.Description) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DescribedTodoListItem) obj);
        }

        public override int GetHashCode()
        {
            return (Description?.GetHashCode() ?? 0) ^ Id.GetHashCode();
        }

        public readonly Guid Id;
        public readonly string Description;

        public DescribedTodoListItem(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}