using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class GCTFileException : Exception
    {
        private String m_errorMessage;

        public GCTFileException(short errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    m_errorMessage = "Validation of GCT file failed. Data may be corrupted, please redownload PM or restore a backup of your RSBE01.gct file.";
                    break;
            }
        }

        public String ErrorMessage
        {
            get { return m_errorMessage; }
        }
    }
}
