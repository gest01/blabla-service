using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace BlaBlaService.Api.Models
{
    public class BlaBlaService
    {
        private static readonly HttpClient _http = new HttpClient();

        public async Task<BlaBlaResult> CheckBlaBlaMeterAsync(string text)
        {
            BlaBlaResult blabla = new BlaBlaResult();
            if (string.IsNullOrWhiteSpace(text))
                return blabla;

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("bc_ip", text);

            HttpContent content = new FormUrlEncodedContent(values);

            HttpClient _http = new HttpClient();
            var response = await _http.PostAsync(ConfigurationManager.AppSettings["BlaBlaMeterUrl"], content);
            var result = await response.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);

            var node = doc.GetElementbyId("infobox");
            if (node != null && node.ChildNodes.Count == 3)
            {
                var list = node.ChildNodes.ToList();
                blabla.Result = list[0].InnerText;
                blabla.Index = list[1].InnerText;
                blabla.Description = list[2].InnerText;

                Trace.TraceInformation("Result={0};Index={1};Description={2}", blabla.Result, blabla.Index, blabla.Description);

            }

            return blabla;
        }
    }
}