using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSCreator
{
    class IndexedComboBox : ComboBox
    {
        public Int32 Index { get; private set; }
        public IndexedComboBox(Int32 index) :
            base()
        {
            Index = index;
        }
    }
}
