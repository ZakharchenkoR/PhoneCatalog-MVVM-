using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Model
{
    interface ISaver
    {
        void Save(IEnumerable<Phone> phones);
    }
}
