using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponents.WindowForm.Wizards
{
    public abstract class WizardModelBase : IWizardModel
    {
        public string Label { get; protected set; }

        public int LabelFlag { get; set; }
    }
}
