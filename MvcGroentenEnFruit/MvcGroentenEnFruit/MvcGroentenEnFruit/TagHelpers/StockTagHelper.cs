using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Data;
using MvcGroentenEnFruit.ViewModels;

namespace MvcGroentenEnFruit.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("stock")]
    public class StockTagHelper : TagHelper
    {
        GFDbContext _context;
        public StockTagHelper(GFDbContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(StockDiv());
        }

        private TagBuilder StockDiv()
        {
            TagBuilder tb = new TagBuilder("div");
            tb.Attributes["class"] = "container";
            //header
            string[] header = { "Artikel", "Aankopen", "Verkopen", "Stock" };
            tb.InnerHtml.AppendHtml(StockRowHeader(header));
            //data
            var stockData = StockQuery();
            if (stockData != null)
            {
                foreach (var stockRow in stockData)
                {
                    tb.InnerHtml.AppendHtml(StockRowData(stockRow));
                }
            }
            return tb;
        }

        private TagBuilder StockRowHeader(IEnumerable<string> header)
        {
            TagBuilder tb = new TagBuilder("div");
            tb.Attributes["class"] = "row";
            foreach (string col in header)
            {
                tb.InnerHtml.AppendHtml(StockColData("bg-info", col));
            }
            return tb;
        }
        private TagBuilder StockColData(string color, string colData)
        {
            TagBuilder tb = new TagBuilder("div");
            tb.Attributes["class"] = $"col-2 m-2 {color} border border-2 border-dark text-center";
            tb.InnerHtml.Append(colData);

            return tb;
        }
        private TagBuilder StockRowData(StockViewModel data)
        {
            TagBuilder tb = new TagBuilder("div");
            tb.Attributes["class"] = "row";

            tb.InnerHtml.AppendHtml(
                StockColData("bg-primary", data.Artikel));
            tb.InnerHtml.AppendHtml(
                StockColData("bg-primary", data.Aankopen.ToString()));
            tb.InnerHtml.AppendHtml(
                StockColData("bg-primary", data.Verkopen.ToString()));
            tb.InnerHtml.AppendHtml(
                StockColData("bg-primary", data.Stock.ToString()));

            return tb;
        }

        private IQueryable<StockViewModel>? StockQuery()
        {
            var stock = _context.Artikels
                .Include(z => z.VerkoopOrders)
                .Include(z => z.AankoopOrders)
                .Select(x => new StockViewModel
                {
                    ArtikelId = x.ArtikelId,
                    Artikel = x.ArtikelNaam,
                    Aankopen = (x.AankoopOrders == null) ? 0 :
                        x.AankoopOrders.Sum(a => a.Hoeveelheid),
                    Verkopen = (x.VerkoopOrders == null) ? 0 :
                        x.VerkoopOrders.Sum(v => v.Hoeveelheid)
                });
            return stock;
        }
    }
}
