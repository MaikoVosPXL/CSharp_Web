using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MvcSportStore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("a" , Attributes="border")]
    public class PageLinkTagHelper : TagHelper
    {
        public string Border { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn {Border} border-secondary");
        }
    }
}
