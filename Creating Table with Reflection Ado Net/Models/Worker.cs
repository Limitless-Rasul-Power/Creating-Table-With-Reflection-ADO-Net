using System.Data.SqlTypes;

namespace Creating_Table_with_Reflection_Ado_Net
{
    public class Worker
    {
        [Not_Null]
        public string FullName { get; set; }
        public string Position { get; set; }

        [Not_Null]
        public decimal Salary { get; set; }
        
        [Not_Null]
        public SqlDateTime Birthdate { get; set; }        
        public int ExperienceYear { get; set; }

        [Unique]
        [Not_Null]
        public string CreditCardNumber { get; set; }
    }
}