﻿namespace EtAlii.Ubigia.Infrastructure.Transport.Owin.WebApi
{
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Api.Transport.WebApi;
    using global::Owin;

    public class WebApiComponentManager : IWebApiComponentManager
    {
        private readonly HttpConfiguration _httpConfiguration;
        private readonly IWebApiComponent[] _components;

        private HttpListener _httpListener;

        public WebApiComponentManager(HttpConfiguration httpConfiguration, IWebApiComponent[] components)
        {
            _httpConfiguration = httpConfiguration;
            _components = components;
        }

        public void Start(object iAppBuilder)
        {
            var application = (IAppBuilder)iAppBuilder;
            var httpListenerName = typeof (HttpListener).FullName;
            if (application.Properties.ContainsKey(httpListenerName))
            {
                _httpListener = (HttpListener) application.Properties[httpListenerName];
            }

            foreach (var component in _components)
            {
                component.Start(application);
            }

            //_logger.Info("Starting WebAPI services");

            _httpConfiguration.MapHttpAttributeRoutes();
            _httpConfiguration.Formatters.Add(new PayloadMediaTypeFormatter());

            //if (_diagnostics.EnableLogging)
            //{
            //    _httpConfiguration.EnableSystemDiagnosticsTracing();
            //}

            application.UseWebApi(_httpConfiguration);

            _httpConfiguration.EnsureInitialized();

            //_logger.Info("Started WebAPI services");
        }

        public void Stop()
        {
            foreach (var component in _components.Reverse())
            {
                component.Stop();
            }

            // TODO: Why do we dispose this instance? Can the start be called again???
            _httpConfiguration.Dispose();

            if (_httpListener != null)
            {
                try
                {
                    _httpListener.Abort();
                    _httpListener = null;
                }
                catch
                {
                    Debugger.Break();
                }
            }
        }
    }
}