namespace Lib.FaceDetect
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ServiceExtensions
    {
        public class ServiceOptions
        {
            public string ApiKey { get; set; }
            public string URI { get; set; }
        }
        public static void AddFaceDetection(this IServiceCollection services, ServiceOptions options)
        {
            if (options == null)
            {
                throw new ArgumentException(nameof(options));
            }

            if (string.IsNullOrEmpty(options.ApiKey))
            {
                throw new ArgumentException("Invalid API key.");
            }

            if (string.IsNullOrEmpty(options.URI))
            {
                throw new ArgumentNullException("Invalid service URL");
            }

            services.AddHttpClient<IFaceDetectService, FaceDetectService>(c =>
            {
                c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", options.ApiKey);
                c.BaseAddress = new Uri(options.URI);
                c.Timeout = TimeSpan.FromSeconds(30);
                
            });
        }
    }
}
