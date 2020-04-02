using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex.Console
{
    class Program
    {
        private const string PATTERN_OF_LEGACY_API = @"CoCon/(?<Model>\w+)(/(?<Method>\w+))?/?";

        private const string PATTERN_OF_LEGACY_SUBSCRIBE_API = @"CoCon/Subscribe/";

        static void Main(string[] args)
        {
            var uri = @"http://localhost:8890/CoCon/Video/SetVideoConfigurationByName/?Name=jack";
            var match = new System.Text.RegularExpressions.Regex(PATTERN_OF_LEGACY_API).Match(uri);

            System.Console.WriteLine($"Uri = {uri}");
            System.Console.WriteLine($"Model = {match.Groups["Model"].Value}");
            System.Console.WriteLine($"Method = {match.Groups["Method"].Value}");

            var subscribe = @"http://localhost:8890/CoCon/Subscribe/?Model=ButtonLED_Event&id=e90b63de-be20-44ff-9583-6db776bb255d&details=true";
            var subMatch = new System.Text.RegularExpressions.Regex(PATTERN_OF_LEGACY_SUBSCRIBE_API).Match(subscribe);

            System.Console.WriteLine($"Uri = {subscribe}");
            System.Console.WriteLine($"Result = {subMatch.Success}");
            System.Console.WriteLine($"Model = {subMatch.Groups["Model"].Value}");
            System.Console.WriteLine($"Method = {subMatch.Groups["Method"].Value}");
            System.Console.ReadLine();
        }
    }
}
