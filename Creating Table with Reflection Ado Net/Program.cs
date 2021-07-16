namespace Creating_Table_with_Reflection_Ado_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new TableHelper().GenerateTable(new Worker()).FillTableWithDatas(DataGenerator.GetWorkers());
        }
    }
}