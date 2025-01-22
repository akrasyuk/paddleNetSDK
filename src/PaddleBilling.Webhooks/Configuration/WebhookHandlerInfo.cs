using System.Reflection;

namespace PaddleBilling.Webhooks.Configuration;

public class WebhookHandlerInfo(Type handlerType, Type genericType, Type parameterType, MethodInfo handleMethod)
{
    public Type HandlerType { get; init; } = handlerType;
    public Type GenericType { get; init; } = genericType;
    public Type ParameterType { get; init; } = parameterType;
    public MethodInfo HandleMethod { get; init; } = handleMethod;
}