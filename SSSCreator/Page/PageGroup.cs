using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class PageGroup : IList
    {
        private List<Page> m_pages;
        public Page SelectedPage { get; private set; }

        public delegate void SelectedPageChangedHandler(Page selectedPage);
        public event SelectedPageChangedHandler SelectedPageChanged;

        public PageGroup()
        {
            m_pages = new List<Page>();
        }
        public void SelectPage(Int32 index)
        {
            if (index >= 0 && index < m_pages.Count)
            {
                SelectedPage = m_pages[index];

                if (SelectedPageChanged != null)
                {
                    SelectedPageChanged(SelectedPage);
                }
            }
        }

        #region IList Interface

        #region Implemented Members

        public void Insert(int index, Object item)
        {
            Page temp = item as Page;

            if (temp != null)
            {
                m_pages.Insert(index, temp);
            }
        }

        public void RemoveAt(int index)
        {
            m_pages.RemoveAt(index);
        }

        public Object this[int index]
        {
            get
            {
                return m_pages[index];
            }
            set
            {
                Page temp = value as Page;

                if (temp != null)
                {
                    m_pages[index] = temp;
                }
            }
        }

        public Int32 Add(Object item)
        {
            Page temp = item as Page;

            if (temp != null)
            {
                m_pages.Add(temp);
            }

            return 0;
        }

        public void Clear()
        {
            m_pages.Clear();
        }

        public int Count
        {
            get { return m_pages.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion 

        #region Non-Implemented Members

        public int IndexOf(Object item)
        {
            throw new NotImplementedException();
        }
        
        public bool Contains(Object item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            throw new NotImplementedException();
        }       

        public void Remove(Object item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }


        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
