using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayeed.NETCore.DataProtection.Tests.MockEntity
{
    public class Parent
    {
        public string Name { get; set; }
        public string ParentPassword { get; set; }
        public bool HasPassword { get; set; }
        public ChildA SingleChild { get; set; }
        public IList<ChildB> Children { get; set; }
    }
}
