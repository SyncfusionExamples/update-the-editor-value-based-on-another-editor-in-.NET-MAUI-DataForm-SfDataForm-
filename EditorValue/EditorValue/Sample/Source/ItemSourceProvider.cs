using Syncfusion.Maui.DataForm;

namespace EditorValue
{
    public class ItemSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "City")
            {
                List<string> city = new List<string>() { "Chennai", "Mumbai", "Delhi", "Cochin", "Bengaluru" };
                return city;
            }

            if (sourceName == "Country")
            {
                List<string> country = new List<string>() { "USA", "Italy", "India", "Indonesia", "Ireland" };
                return country;
            }

            return new List<string>();
        }
    }
}