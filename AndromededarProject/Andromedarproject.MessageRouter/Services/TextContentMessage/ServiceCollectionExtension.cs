using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using Andromedarproject.MessageRouter.BasicMessagePipe.TextContentMessage.OutputGenerators;
using Andromedarproject.MessageRouter.Output.OutputCache;
using Andromedarproject.MessageRouter.Output.OutputServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.Services.TextContentMessage
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddTextContentService(this IServiceCollection sc)
        {
            sc.TryAddBasicMessagePipe<TextContent>()
                .AddOutputGenerators<TextContent>()
                .TryAddOutputServcies<TextContent>()
                .TryAddOutputCache<TextContent>()
                .TryAddTransient<IBasicMessagePipeOutput<TextContent>>();
            return sc;
        }
    }
}
