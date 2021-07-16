using System;

namespace Creating_Table_with_Reflection_Ado_Net
{
    [AttributeUsage(AttributeTargets.All)]
    public class Not_Null : Attribute
    {
        public override string ToString()
        {
            return "NOT NULL";
        }
    }
}