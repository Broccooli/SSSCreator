using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    static class GlobalStageDirectory
    {
        private static Dictionary<String, Stage> m_stringToStageDict = new Dictionary<String, Stage>();
        private static Dictionary<Int32, Stage> m_valueToStageDict = new Dictionary<Int32, Stage>();

        public static Stage GetStage(String key)
        {
            return m_stringToStageDict[key];
        }

        public static Stage GetStage(Int32 key)
        {
            return m_valueToStageDict[key];
        }
    }
}
