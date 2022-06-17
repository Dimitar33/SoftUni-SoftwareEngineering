namespace Task_6._Delegates_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coffe coffee = new Coffe();

            coffee.MakeCoffe();
            coffee.MakeCoffe();
            coffee.MakeCoffe();
            coffee.MakeCoffe();
        }

        public class Coffe
        {
            public EventArgs e = null;
            public delegate void OutOfBeensHandler(Coffe cofee, EventArgs args);
            public event OutOfBeensHandler outOfBeens;

            int currentStock = 1;
            int minStock = 2;


            public void MakeCoffe()
            {
                currentStock--;

                if (currentStock < minStock)
                {
                    if (outOfBeens != null)
                    {
                        outOfBeens(this, e);
                    }
                }
            }
        }
    }
}