using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Creating_Table_with_Reflection_Ado_Net
{
    public static class DataGenerator
    {
        public static List<Worker> GetWorkers()
        {
            return new List<Worker>
            {
                new Worker
                {
                    FullName = "Charlz Schab",
                    Position = "Investor",
                    Salary  = 1_000_000_000,
                    Birthdate = new SqlDateTime(1970, 12, 2),
                    ExperienceYear  = 20,
                    CreditCardNumber = "3581177802586120"
                },

                new Worker
                {
                    FullName = "Charlz Dickens",
                    Position = "Best Writer",
                    Salary  = 100_000_000,
                    Birthdate = new SqlDateTime(1966, 6, 4),
                    ExperienceYear  = 15,
                    CreditCardNumber = "5002359779395836"
                },

                new Worker
                {
                    FullName = "Anthony Robbins",
                    Position = "Life Changer",
                    Salary  = 1_000_000_000,
                    Birthdate = new SqlDateTime(1976, 2, 29),
                    ExperienceYear  = 20,
                    CreditCardNumber = "58930449158524746"
                }
            };
        }
    }
}