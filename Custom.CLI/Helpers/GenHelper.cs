using System.Text;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

namespace Custom.Cli.Helpers
{
    internal class GenHelper
    {
        private const string _list = "http://www.tcmap.com.cn/list/daima_list.html";

        private static async Task<List<string>> GetAreaCodes()
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetAsync(_list);
            var html = await res.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var linkNodes = doc.DocumentNode.SelectNodes("/html/body/div[2]/div[1]/div");
            var list = new List<string>();
            var regex = new Regex("[0-9]{6}");
            foreach (var linkNode in linkNodes)
            {
                var matches = regex.Matches(linkNode.InnerText);
                foreach (Match item in matches.Cast<Match>())
                {
                    list.Add(item.Value);
                }
            }
            return list;
        }

        private static string GenBirthday()
        {
            var sb = new StringBuilder(8);
            var r = new Random();
            sb.Append(r.Next(1960, DateTime.Now.Year + 1));
            var month = r.Next(1, 13).ToString();
            if (month.Length < 2) month = "0" + month;
            sb.Append(month);
            var day = r.Next(1, 28).ToString();
            if (day.Length < 2) day = "0" + day;
            sb.Append(day);
            return sb.ToString();
        }

        public static async Task<string> GenAsync()
        {
            var list = await GetAreaCodes();
            var r = new Random();
            var sb = new StringBuilder(18);
            sb.Append(list[r.Next(0, list.Count)]);
            sb.Append(GenBirthday());
            sb.Append(r.Next(1000, 9001));
            return sb.ToString();
        }
    }
}