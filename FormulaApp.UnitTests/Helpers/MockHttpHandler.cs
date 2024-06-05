﻿using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace FormulaApp.UnitTests.Helpers
{
    // Success
    public class MockHttpHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupGetRequest(List<T> response) 
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) 
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            mockResponse.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
                
        }

        // NotFound

        internal static Mock<HttpMessageHandler> SetupReturnNotFound()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("")
            };

            mockResponse.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;

        }
    }
}
