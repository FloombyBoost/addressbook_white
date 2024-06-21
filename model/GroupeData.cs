using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_white
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>  // IComparable --для сортировки ,IEquatable -- для сравнения элементов между собой
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
           return this.Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
