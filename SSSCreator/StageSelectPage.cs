using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class StageSelectPage
    {
        public String Name { get; private set; }
        public Int32 Number { get; private set; }
        public Int32 Size { get; set; }
        public List<Int32> StageList { get; private set; }
        public StageSelectPage(String name, Int32 number, Int32 size, List<Int32> stages)
        {
            Name = name;
            Number = number;
            Size = size;
            StageList = stages;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
