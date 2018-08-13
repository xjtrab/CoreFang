using System;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace CoreCfang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var html = @"http://www.czcfang.com/house/index?sug=cm:4062";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            
            var test = htmlDoc.DocumentNode.QuerySelectorAll(".houseInfo");
            foreach (var item in test)
            {
                var price = item.QuerySelector(".area").QuerySelector(".gray").InnerText.Replace(Environment.NewLine, "").Trim();
                var href = item.QuerySelector("a").Attributes["href"];
                var id  = href.Value.Split("/")[3];
                Console.WriteLine("Price : " + price);
            }
        }
    }
}
