using System.Net;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Configuration;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace GadgetsOnline.EndpointAdapter
{
	public class EndpointUtils
	{
        private static readonly string ENDPOINT_SETTINGS = "EndpointSettings";
		private static readonly string CONNECTION_STRING_ENDPOINT_KEY = "EndpointConnectionString";
		private static readonly string APP_SETTINGS_ROUTING_SWITCH_KEY = "RemoteRoutingToMicroservice";
		private static readonly string SKIP_CERTIFICATE_VALIDATION = "SkipCertificateValidation";
		private static readonly string ENDPOINT_DELIMITER = "/";
		private static readonly string JSON_MEDIA_HEADER = "application/json";
		private static readonly string WEB_CONFIG_FILE = "~/EndpointAdapter";
 		private static Dictionary<string, HttpClient> _endpointHttpClientCache = new Dictionary<string, HttpClient>();

		public static string getRemoteEndpoint()
		{
            return ConfigurationManager.Configuration.GetSection(ENDPOINT_SETTINGS)[CONNECTION_STRING_ENDPOINT_KEY];
		}

		public static bool isRemoteRouting()
		{
			return Convert.ToBoolean(ConfigurationManager.Configuration.GetSection(ENDPOINT_SETTINGS)[APP_SETTINGS_ROUTING_SWITCH_KEY]);
		}

		public static bool isSkipCertValidation()
		{
            return Convert.ToBoolean(ConfigurationManager.Configuration.GetSection(ENDPOINT_SETTINGS)[SKIP_CERTIFICATE_VALIDATION]);
		}

		public static HttpClient initializeClientWithJsonMedia(string endpointAddress)
		{
 			lock (_endpointHttpClientCache)
 			{
 				if (!_endpointHttpClientCache.ContainsKey(endpointAddress))
 				{
 					_endpointHttpClientCache[endpointAddress] = new HttpClient();
 					if (isSkipCertValidation())
 					{
 						// trust any certificate
 						ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
 						ServicePointManager.ServerCertificateValidationCallback +=
 							(sender, cert, chain, sslPolicyErrors) => { return true; };
 					}
 					else
 					{
 						// validate the certificate chain but ignore domain name mismatches for endpoint
 						ServicePointManager.ServerCertificateValidationCallback +=
 							(sender, cert, chain, sslPolicyErrors) =>
 							{
 								return sslPolicyErrors == SslPolicyErrors.None || sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch;
 							};
 					}
 					_endpointHttpClientCache[endpointAddress].BaseAddress = new Uri(endpointAddress);
 					_endpointHttpClientCache[endpointAddress].DefaultRequestHeaders.Accept.Clear();
 					_endpointHttpClientCache[endpointAddress].DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_MEDIA_HEADER));
 				}
 			}
 			return _endpointHttpClientCache[endpointAddress];
		}

		public static HttpResponseMessage PostAndGetResponse<T>(HttpClient client, string endpointPrefix, string endpointSuffix, T param)
		{
			string endpointUri = endpointPrefix + ENDPOINT_DELIMITER + endpointSuffix;
			var postTask = client.PostAsJsonAsync<T>(endpointUri, param);
			postTask.Wait();
			return postTask.Result;
		}

        public static HttpResponseMessage PostAndGetResponseDict<T>(HttpClient client, string endpointPrefix, string endpointSuffix, T param)
        {
            string endpointUri = endpointPrefix + ENDPOINT_DELIMITER + endpointSuffix;
            var postTask = client.PostAsJsonAsync<T>(endpointUri, param);
            postTask.Wait();
            return postTask.Result;
        }

        public static T ReadResponse<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				var readResult = response.Content.ReadAsStringAsync().Result;                
				T outputValue = JsonSerializer.Deserialize<T>(readResult, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
				return outputValue;
			}
			else
			{
				throw new HttpRequestException();
			}
		}
	}
}
