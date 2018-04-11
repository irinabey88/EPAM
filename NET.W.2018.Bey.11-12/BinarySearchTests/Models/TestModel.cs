namespace BinarySearchTests.Models
{
    using System;

    public class TestModel : IEquatable<TestModel>, IComparable<TestModel>
    {        
        public TestModel(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public uint Age { get; set; }

        public bool Equals(TestModel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Name == other.Name && this.Age == other.Age)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(TestModel other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (string.Compare(this.Name, other.Name, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }

            return this.Age.CompareTo(other.Age);
        }
    }
}