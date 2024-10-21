namespace GCB.Utility.Extensions
{
    public static class ObjectExtensions
    {
        public static void Dump(this object value)
        {
            Console.Write(value);
        }

        public static void DumpLine(this object value)
        {
            Console.WriteLine(value);
        }
    }
}
