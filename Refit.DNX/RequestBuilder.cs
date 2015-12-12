using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Refit
{
    public interface IRequestBuilder
    {
        IEnumerable<string> InterfaceHttpMethods { get; }
        Func<HttpClient, object[], object> BuildRestResultFuncForMethod(string methodName);
    }

    interface IRequestBuilderFactory
    {
        IRequestBuilder Create(Type interfaceType, RefitSettings settings);
    }

    public static class RequestBuilder
    {
        static readonly IRequestBuilderFactory platformRequestBuilderFactory = new RequestBuilderFactory();
        
        public static IRequestBuilder ForType(Type interfaceType, RefitSettings settings)
        {
            return platformRequestBuilderFactory.Create(interfaceType, settings);
        }
    
        public static IRequestBuilder ForType(Type interfaceType)
        {
            return platformRequestBuilderFactory.Create(interfaceType, null);
        }

        public static IRequestBuilder ForType<T>(RefitSettings settings)
        {
            return ForType(typeof(T), settings);
        }

        public static IRequestBuilder ForType<T>()
        {
            return ForType(typeof(T), null);
        }
    }
}

