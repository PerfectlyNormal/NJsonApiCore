using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJsonApiCore.Test.TestModel
{
    public class ValidModelWithBadChild
    {
        public BadModelWithReservedWords BadChild { get; set; }
    }
}
