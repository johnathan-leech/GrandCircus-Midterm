/*
Minefield by Nicholas, Ty, Johnathan, Katie
 */
namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput.StartMenu();
            //UserInput.Instruct();


            Board b = new Board();
            if (!b.WinsOrLoses())
            {
                UserInput.Credits();
            }

        }
    }
}
