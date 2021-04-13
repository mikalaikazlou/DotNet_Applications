using GrabberSite;

namespace grabber
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar = Grabber.GetArgument(args);

            if (Grabber.SaveInformation())
            {
                Grabber.GetParseSite(ar);
            }
            else
            {
                System.Console.WriteLine("SaveInformation method is not done");
            }
        }
    }
}