using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ROB.Web.TagHelpers
{
    [HtmlTargetElement("main-attribute")]
    public class MainAttributeTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string Variable { get; set; }
        public int BaseValue { get; set; }
        public int ModifierValue { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
#pragma warning disable CA1305 // Specify IFormatProvider
            var str = string.Format(@"
            <div class='border rounded card' onclick='sideBar{1}()'>
                {0}
                <div class='major_stat'>
                    <input id='{1}'  name='strength' type='hidden' value='{2}' readonly />
                    <input id='{1}Modifier' name='{1}Modifier' type='hidden' value='{3}' readonly />
                    <div id='{1}Display'> 0 </div>
                </div>
            </div>", Name, Variable, BaseValue.ToString(), ModifierValue.ToString());
#pragma warning restore CA1305 // Specify IFormatProvider
            output.Content.SetHtmlContent(str);
            output.Attributes.Add("class", "container-main-attribute col-6 col-sm-4 col-md");
        }
    }
}
