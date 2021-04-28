using System.IO;

namespace Typeset
{
    public class StringResourceProvider : IStringResourceProvider
    {
        public string Get(string resourceName)
        {
            return File.ReadAllText(Path.Join("Resources", resourceName));
        }
    }
}