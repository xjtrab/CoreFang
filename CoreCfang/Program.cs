﻿using System;
using System.Text.RegularExpressions;
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
                var totalPrice = Regex.Replace(item.QuerySelector(".area").QuerySelector(".orange").InnerText.Replace(Environment.NewLine, "").Trim(),@"\s","");
                var mianji = Regex.Replace(item.QuerySelector(".horizontal").QuerySelector(".horizon-detail").InnerText.Replace(Environment.NewLine, "").Trim(),@"\s","").Replace("&nbsp;&nbsp;"," ");

                var href = item.QuerySelector("a").Attributes["href"];
                var id  = href.Value.Split("/")[3];
                Console.WriteLine("总价 : " + totalPrice + " 面积:" +mianji + " 单价:" + price + " id:" + id );
            }
        }
    }
}
