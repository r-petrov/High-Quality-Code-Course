using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReformatBadlyFormattedCode
{
    class BadlyFormattedCode
    {
        protected virtual string GetParentTableControlID()
        {
            try
            {
                if (this.Parent is BaseApplicationTableControl) return this.Parent.ID;
                if (this.Parent.Parent is BaseApplicationTableControl) return this.Parent.Parent.ID;
                if (this.Parent.Parent.Parent is BaseApplicationTableControl) return this.Parent.Parent.Parent.ID;
                if (this.Parent.Parent.Parent.Parent is BaseApplicationTableControl) return this.Parent.Parent.Parent.Parent.ID;
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}
