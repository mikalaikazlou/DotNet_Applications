namespace GrabberSite
{
    public class Searcher
    {
        public static bool IsItAddressSite(string enter)
        {
            bool addressSite = false;
            switch (enter)
            {
                case string a when enter.EndsWith(".by"):
                case string b when enter.EndsWith(".ru"):
                case string c when enter.EndsWith(".com"):
                case string d when enter.EndsWith(".ua"):
                case string e when enter.EndsWith(".pl"):
                case string f when enter.EndsWith(".de"):
                case string g when enter.EndsWith(".uk"):
                case string h when enter.EndsWith(".net"):
                case string i when enter.EndsWith(".web"):
                case string j when enter.EndsWith(".org"):
                case string k when enter.EndsWith(".co"):
                    addressSite = true;
                    break;
            }
            return addressSite;
        }
    }
}