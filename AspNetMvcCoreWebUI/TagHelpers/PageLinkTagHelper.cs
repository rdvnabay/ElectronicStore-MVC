using AspNetMvcCoreWebUI.Models.Paging;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='store-pagination'>");

            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'>", i == PageModel.CurrentPage ? "active" : "");
                if (string.IsNullOrEmpty(PageModel.CurrentCategoryName))
                {
                    stringBuilder.AppendFormat("<a href='/products?page={0}'>{0}</a>", i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a href='/products/{0}?page={1}'>{1}</a>", PageModel.CurrentCategoryName, i);
                } 
                stringBuilder.Append("</li>");
            }
            //if (string.IsNullOrEmpty(PageModel.CurrentCategoryName))
            //{
            //    if (PageModel.TotalPages()>5)
            //    {
            //        stringBuilder.AppendFormat("<li><a href='/products?page={0}'><i class='fa fa-angle-right'></i></a></li>", PageModel.TotalPages()+1);
            //    }
               
            //}
            //if (PageModel.TotalPages() > 5)
            //{
            //    stringBuilder.AppendFormat("<li><a href='/products/{0}?page={1}'><i class='fa fa-angle-right'></i></a></li>", PageModel.CurrentCategoryName, PageModel.TotalPages() + 1);
            //}
            //stringBuilder.AppendFormat("<li><a href='#'><i class='fa fa-angle-right'></i></a></li>");
            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
