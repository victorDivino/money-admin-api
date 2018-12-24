using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoneyAdmin.Domain.Core.Models
{
    public abstract class Entity
    {
        [BsonRequired()]
        [BsonId()]
        public ObjectId _id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return _id.Equals(compareTo._id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + _id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + _id + "]";
        }


    }
}
