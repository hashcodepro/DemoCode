using System;
using System.Collections.Generic;

namespace DapperDemo
{
    public class Community : IEquatable<Community>
    {
        public int Community_Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public bool Equals(Community other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            return Community_Id.Equals(other.Community_Id)
            && Name.Equals(other.Name)
            && Users == other.Users;
        }

        public override int GetHashCode()
        {
            int hashCommunity_Id = Community_Id.GetHashCode();
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashUsers = Users == null ? 0 : Users.GetHashCode();

            return hashCommunity_Id ^ hashName ^ hashUsers;
        }
    }
}