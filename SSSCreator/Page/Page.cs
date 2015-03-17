using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class Page
    {
        private List<Stage> m_stages;
        public Int32 Size { get; private set; }
        public String Name { get; private set; }

        public Page(Int32 size)
        {
            Size = size;
            m_stages = new List<Stage>(size);
        }

        public Page(List<Stage> stages)
        {
            m_stages = new List<Stage>(stages);
            Size = m_stages.Count;
        }

        public Page(List<Int32> stageValues, String name)
        {
            Name = name;
            m_stages = new List<Stage>();
            foreach (Int32 value in stageValues)
            {
                m_stages.Add(GlobalStageDirectory.GetStage(value));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
