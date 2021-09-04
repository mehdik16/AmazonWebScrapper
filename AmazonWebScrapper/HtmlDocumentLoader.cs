using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWebScrapper
{
    internal class HtmlDocumentLoader : IHtmlDocumentLoader
    {
        public HtmlDocument LoadDocumentFromUrl(string url)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument html = web.Load(url);
            return html;
        }
    }
}
