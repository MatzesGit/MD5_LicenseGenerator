namespace Calculation
{
    public class Calc
    {
        public static int Add(int Variable1, int Variable2)
        {
            return Variable1 + Variable2;
        }
    }
    class test_class
    {
        int x;

        // konstructor wird wie die Klasse benannt und gibt vor wo gelesen werden soll
        public test_class(int x)
        {
            //irgendetwas
            this.x = x;
        }

        public int Test(int number)
        {
            return number + x;
        }

        // poperty
        public int Name
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
    }
}