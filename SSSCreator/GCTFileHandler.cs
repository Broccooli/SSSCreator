using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSCreator
{
    class GCTFileHandler
    {
        private String m_filePath;
        private Byte[] m_gctBytes;

        private short m_errorCode;

        private List<Int32> m_pageOneStageList;
        private List<Int32> m_pageTwoStageList;

        public Int32 PageOneSize { get; private set; }
        public Int32 PageTwoSize { get; private set; }

        public List<Int32> PageOneStageList
        {
            get { return m_pageOneStageList; }
        }

        public List<Int32> PageTwoStageList
        {
            get { return m_pageTwoStageList; }
        }

        public enum ValidationPage
        {
            One = 1,
            Two = 2,
        }

        #region Constructor

        public GCTFileHandler(String gctFilePath)
        {
            m_filePath = gctFilePath;
            AssembleFile();
        }

        #endregion

        public void ExportNewStageList(Byte pageOneSize, Byte[] pageOneStages, Byte pageTwoSize, Byte[] pageTwoStages)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.DefaultExt = "gct";
                dialog.CheckPathExists = true;
                dialog.OverwritePrompt = true;
                dialog.Filter = "GCT Files(*.gct)|*.gct";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String fileName = dialog.FileName;
                    WriteNewGCT(fileName, pageOneSize, pageOneStages, pageTwoSize, pageTwoStages);
                }
            }
        }

        #region Private Methods

        private void WriteNewGCT(String fileName, Byte pageOneSize, Byte[] pageOneStages, Byte pageTwoSize, Byte[] pageTwoStages)
        {
            Int32 pageOneStageIndex = 0;
            Int32 endPageOneOffset = Constants.PAGE_ONE_STAGE_LIST_START_OFFSET + pageOneSize;
            for (Int32 ii = Constants.PAGE_ONE_STAGE_LIST_START_OFFSET; ii < endPageOneOffset; ii++)
            {
                m_gctBytes[ii] = pageOneStages[pageOneStageIndex++];
            }

            Int32 pageTwoStageIndex = 0;
            for (Int32 ii = Constants.PAGE_TWO_STAGE_LIST_START_OFFSET; ii < Constants.PAGE_TWO_STAGE_LIST_START_OFFSET + pageTwoSize; ii++)
            {
                m_gctBytes[ii] = pageTwoStages[pageTwoStageIndex++];
            }

            m_gctBytes[Constants.PAGE_ONE_STAGE_SIZE_OFFSET_1] = pageOneSize;
            m_gctBytes[Constants.PAGE_ONE_STAGE_SIZE_OFFSET_2] = pageOneSize;

            m_gctBytes[Constants.PAGE_TWO_STAGE_SIZE_OFFSET_1] = pageTwoSize;
            m_gctBytes[Constants.PAGE_TWO_STAGE_SIZE_OFFSET_2] = pageTwoSize;

            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                stream.Write(m_gctBytes, 0, m_gctBytes.Length);
            }
        }

        private void AssembleFile()
        {
            using (FileStream stream = new FileStream(m_filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                m_gctBytes = new Byte[stream.Length];
                stream.Read(m_gctBytes, 0, m_gctBytes.Length);
            }

            if (VerifyGCTFile(m_gctBytes))
            {
                m_pageOneStageList = new List<int>(PageOneSize);
                for (Int32 ii = Constants.PAGE_ONE_STAGE_LIST_START_OFFSET; ii < Constants.PAGE_ONE_STAGE_LIST_START_OFFSET + PageOneSize; ii++)
                {
                    m_pageOneStageList.Add(m_gctBytes[ii]);
                }

                m_pageTwoStageList = new List<int>(PageTwoSize);
                for (Int32 ii = Constants.PAGE_TWO_STAGE_LIST_START_OFFSET; ii < Constants.PAGE_TWO_STAGE_LIST_START_OFFSET + PageTwoSize; ii++)
                {
                    m_pageTwoStageList.Add(m_gctBytes[ii]);
                }
            }
            else
            {
                throw new GCTFileException(m_errorCode);
            }
        }

        private Boolean VerifyGCTFile(Byte[] gctBytes)
        {
            return ValidatePage(ValidationPage.One, gctBytes) && ValidatePage(ValidationPage.Two, gctBytes);            
        }

        private Boolean ValidatePage(ValidationPage page, Byte[] gctBytes)
        {
            Byte[] validationArray = null;
            Byte[] gctArrayPart = SetupGCTBytesForVerfication(page, gctBytes);

            if (page == ValidationPage.One)
            {
                validationArray = Constants.FIRST_PAGE_VERIFICATION;
            }
            else
            {
                validationArray = Constants.SECOND_PAGE_VERIFICATION;
            }

            for (Int32 ii = 0; ii < gctArrayPart.Length; ii++)
            {
                if (ii != 7 && ii != 15)
                {
                    if (gctArrayPart[ii] == validationArray[ii])
                    {
                        continue;
                    }
                    else
                    {
                        m_errorCode = 1;
                        return false;
                    }
                }
                else
                {
                    if (Constants.POSSIBLE_STAGE_SIZES.Contains<Byte>(gctArrayPart[ii]))
                    {
                        if (page == ValidationPage.One) { PageOneSize = gctArrayPart[ii]; }
                        else { PageTwoSize = gctArrayPart[ii]; }

                        continue;
                    }
                    else
                    {
                        m_errorCode = 1;
                        return false;
                    }
                }
            }

            return true;
        }

        private Byte[] SetupGCTBytesForVerfication(ValidationPage page, Byte[] gctBytes)
        {
            Byte[] retArray = new Byte[16];

            Int32 retArrayIndex = 0;

            switch (page)
            {
                case ValidationPage.One:

                    for (long ii = Constants.FIRST_PAGE_START_OFFSET; ii <= Constants.FIRST_PAGE_END_OFFSET; ii++)
                    {
                        retArray[retArrayIndex++] = gctBytes[ii];
                    }
                    break;
                case ValidationPage.Two:
                    for (long ii = Constants.SECOND_PAGE_START_OFFSET; ii <= Constants.SECOND_PAGE_END_OFFSET; ii++)
                    {
                        retArray[retArrayIndex++] = gctBytes[ii];
                    }
                        break;
            }

            return retArray;
        }

        #endregion
    }
}
