﻿namespace EtAlii.Ubigia.Api.Transport.Tests
{
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.Ubigia.Api.Transport.WebApi;
    using Xunit;

    
    public class PayloadMediaTypeFormatterTests
    {
        [Fact]
        public void PayloadMediaTypeFormatter_Create()
        {
            var formatter = new PayloadMediaTypeFormatter();
        }
    }
}
