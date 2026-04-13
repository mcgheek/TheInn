using System;
using System.Collections.Generic;
using System.Text;

namespace TheInn
{
    public class EquitableItem : Item, IEquatable<EquitableItem>
    {
        public bool Equals(EquitableItem? other)
        {
            return other != null &&
                   other.Name == Name &&
                   other.Quality == Quality &&
                   other.SellIn == SellIn;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((EquitableItem)obj);
        }

        public override int GetHashCode()
        {
            var hashcode = Name.GetHashCode();
            hashcode = (hashcode * 397) ^ Quality.GetHashCode();
            hashcode = (hashcode * 397) ^ SellIn.GetHashCode();
            return hashcode;
        }

        public static bool operator ==(EquitableItem? left, EquitableItem? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EquitableItem? left, EquitableItem? right)
        {
            return !Equals(left, right);
        }
    }
}
