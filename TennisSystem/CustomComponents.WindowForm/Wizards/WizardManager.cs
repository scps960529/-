using System;
using System.Collections.Generic;
using SystemFramework.Events;

namespace CustomComponents.WindowForm.Wizards
{
    public class WizardManager
    {
        private int _indexCount = 0;
        private List<int> noUsedIndex = new List<int>();

        public event EventHandler SelectedChanged;

        public Dictionary<int, IWizardModel> Pages { get; private set; }

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            private set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;

                    if (SelectedChanged != null)
                        SelectedChanged(this, EventArgs.Empty);
                }
            }
        }

        public IWizardModel Page
        {
            get
            {
                if (SelectedIndex != -1)
                {
                    return Pages[SelectedIndex];
                }

                return null;
            }
        }

        public WizardManager()
        {
            Pages = new Dictionary<int, IWizardModel>();
        }

        public int Registor(IWizardModel page)
        {
            int targetIdx = -1;
            if (noUsedIndex.Count == 0)
            {
                targetIdx = _indexCount;
                _indexCount++;
            }
            else
            {
                targetIdx = noUsedIndex[0];
                noUsedIndex.RemoveAt(0);
            }

            ((WizardModelBase)page).LabelFlag = targetIdx;

            Pages.Add(targetIdx, page);

            return targetIdx;
        }

        public void Unregistor(int index)
        {
            if (Pages.ContainsKey(index))
            {
                Pages.Remove(index);
                noUsedIndex.Add(index);

                if (SelectedIndex > index)
                    SelectedIndex--;
            }
        }

        public bool IsContains(int index)
        {
            return Pages.ContainsKey(index);
        }

        public bool IsContains(IWizardModel page)
        {
            return Pages.ContainsValue(page);
        }

        public void Forward(object sender, EventArgs e)
        {
            SelectedIndex -= 1;// mistake
        }

        public void Next(object sender, EventArgs e)
        {
            SelectedIndex += 1; // mistake
        }

        public void MoveTo(object sender, IntEventArgs e)
        {
            SelectedIndex = e.Value;
        }
    }
}
