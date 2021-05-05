using System.IO;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Typeset
{
    internal static class PdfGenerator
    {
        public static async Task<Stream> GeneratePdfStreamFromHtml(string html)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            var launchOptions = new LaunchOptions
            {
                Headless = true,
                Args = new [] { "--no-sandbox" }
            };
            await using var browser = await Puppeteer.LaunchAsync(launchOptions);

            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);
            await page.SetJavaScriptEnabledAsync(true);
            return await page.PdfStreamAsync();
        }
    }
}