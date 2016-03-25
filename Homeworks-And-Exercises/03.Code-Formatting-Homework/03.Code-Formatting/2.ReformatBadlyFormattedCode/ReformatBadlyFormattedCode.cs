namespace _2.ReformatBadlyFormattedCode
{
    using System;

    internal class ReformatBadlyFormattedCode
    {
        internal static void Main(string[] args)
        {
        }

        protected virtual string GetParentTableControlID()
        {
            try
            {
                if (this.Parent is BaseApplicationTableControl)
                {
                    return this.Parent.ID;
                }

                if (this.Parent.Parent is BaseApplicationTableControl)
                {
                    return this.Parent.Parent.ID;
                }

                if (this.Parent.Parent.Parent is BaseApplicationTableControl)
                {
                    return this.Parent.Parent.Parent.ID;
                }

                if (this.Parent.Parent.Parent.Parent is BaseApplicationTableControl)
                {
                    return this.Parent.Parent.Parent.Parent.ID;
                }
            }
            catch (Exception)
            {
            }

            return string.Empty;
        }
    }
}
