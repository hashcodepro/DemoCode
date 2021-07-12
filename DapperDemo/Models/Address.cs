using System;

namespace DapperDemo
{
    public class Address : IEquatable<Address>
    {
        public int Address_Id { get; set; }
        public int User_Id { get; set; }
        public string Address_Line_1 { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }

        public bool Equals(Address other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            return Address_Id.Equals(other.Address_Id)
            && User_Id.Equals(other.User_Id)
            && Address_Line_1.Equals(other.Address_Line_1)
            && City.Equals(other.City)
            && Postcode.Equals(other.Postcode);
        }

        public override int GetHashCode()
        {
            int hashAddress_Id = Address_Id.GetHashCode();
            int hashUser_Id = User_Id.GetHashCode();
            int hashAddress_Line_1 = Address_Line_1 == null ? 0 : Address_Line_1.GetHashCode();
            int hashCity = City == null ? 0 : City.GetHashCode();
            int hashPostcode = Postcode.GetHashCode();

            return hashAddress_Id ^ hashUser_Id ^ hashAddress_Line_1 ^ hashCity ^ hashPostcode;
        }
    }
}