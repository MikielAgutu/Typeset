using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        public void GeneratePdf()
        {
            GeneratePdfFromHtml().GetAwaiter().GetResult();
        }

        private async Task GeneratePdfFromHtml()
        {

        }
    }
}
