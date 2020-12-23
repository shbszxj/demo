using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEnumToCheckbox
{
    [Flags]
    public enum Department
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8
    }
}
