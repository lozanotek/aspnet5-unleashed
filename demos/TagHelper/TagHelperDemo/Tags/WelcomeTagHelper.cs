using Aspnet5MessageLibrary;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHelperDemo.Tags
{
    public class WelcomeTagHelper : TagHelper
    {
        [Activate]
        protected IMessageService MessageService { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Don't render the outer tag
            output.TagName = null;
            output.Content.SetContent(MessageService.GetWelcomeMessage());
        }
    }
}
