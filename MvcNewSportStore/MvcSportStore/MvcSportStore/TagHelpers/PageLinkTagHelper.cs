using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcSportStore.ViewModels;

namespace MvcSportStore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("page-link", Attributes = "paging-info")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PagingInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(GetPagingInfoLinks());
        }

        private TagBuilder GetPagingInfoLinks()
        {
            // Uses PagingInfo object.
            TagBuilder ul = new("ul");
            ul.Attributes["class"] = "row";
            bool active = false;
            for (int page = 1; page <= PagingInfo.TotalPages; page++)
            {
                active = page == PagingInfo.CurrentPage;
                ul.InnerHtml.AppendHtml(GetPagingInfoLink(page, active));
            }
            return ul;
        }

        private TagBuilder GetPagingInfoLink(int page, bool active)
        {
            TagBuilder li = new("li");
            li.Attributes["class"] = "nav-link col-1";
            li.InnerHtml.AppendHtml(GetPagingInfoHyperLink(page, active));
            return li;
        }

        private TagBuilder GetPagingInfoHyperLink(int page, bool active)
        {
            string linkActive = "btn border border-primary";
            string link = "btn border border-secondary";
            TagBuilder a = new("a");
            a.Attributes["class"] = active ? linkActive : link;
            a.Attributes["href"] = (PagingInfo.Category is null)
                ? $"/Home/Index/{page}"
                : $"/Home/Index/{page}?category={PagingInfo.Category}";
            a.Attributes["title"] = $"Click to go to {page}";
            a.InnerHtml.Append($"{page}");
            return a;
        }
    }
}
