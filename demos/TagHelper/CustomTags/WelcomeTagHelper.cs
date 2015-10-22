using Aspnet5MessageLibrary;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace CustomTags
{
    public class WelcomeTagHelper : TagHelper
    {
        private readonly IMessageService _messageService;

        public WelcomeTagHelper(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Don't render the outer tag
            output.TagName = null;
            output.Content.SetContent(_messageService.GetWelcomeMessage());
        }
    }
}
