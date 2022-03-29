using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using System.Web;

namespace GadgetsOnline.EndpointAdapter
{
	public class EndpointUtils
	{
		private static readonly string CONNECTION_STRING_ENDPOINT_KEY = "EndpointConnectionString";
		private static readonly string APP_SETTINGS_ROUTING_SWITCH_KEY = "RemoteRoutingToMicroservice";
		private static readonly string SKIP_CERTIFICATE_VALIDATION = "SkipCertificateValidation";
		private static readonly string ENDPOINT_DELIMITER = "/";
		private static readonly string JSON_MEDIA_HEADER = "application/json";
		private static readonly string WEB_CONFIG_FILE = "~/EndpointAdapter";

		public static string getRemoteEndpoint()
		{
			Configuration config = WebConfigurationManager.OpenWebConfiguration(WEB_CONFIG_FILE);
			return config.ConnectionStrings.ConnectionStrings[CONNECTION_STRING_ENDPOINT_KEY].ConnectionString;
		}

		public static bool isRemoteRouting()
		{
			Configuration config = WebConfigurationManager.OpenWebConfiguration(WEB_CONFIG_FILE);
			return Convert.ToBoolean(config.AppSettings.Settings[APP_SETTINGS_ROUTING_SWITCH_KEY].Value);
		}

		public static bool isSkipCertValidation()
		{
			Configuration config = WebConfigurationManager.OpenWebConfiguration(WEB_CONFIG_FILE);
			return Convert.ToBoolean(config.AppSettings.Settings[SKIP_CERTIFICATE_VALIDATION].Value);
		}

		public static HttpClient initializeClientWithJsonMedia(string endpointAddress)
		{
			if (isSkipCertValidation())
			{
				// trust any certificate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				ServicePointManager.ServerCertificateValidationCallback +=
					(sender, cert, chain, sslPolicyErrors) => { return true; };
			} else
			{
				// validate the certificate chain but ignore domain name mismatches for endpoint
				ServicePointManager.ServerCertificateValidationCallback +=
					(sender, cert, chain, sslPolicyErrors) =>
					{
						return sslPolicyErrors == SslPolicyErrors.None || sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch;
					};
			}

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(endpointAddress);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_MEDIA_HEADER));
			return client;
		}

		public static HttpResponseMessage PostAndGetResponse<T>(HttpClient client, string endpointPrefix, string endpointSuffix, T param)
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
				var readTask = response.Content.ReadAsAsync<T>();
				readTask.Wait();
				T outputValue = readTask.Result;
				return outputValue;
			}
			else
			{
				throw new HttpRequestException();
			}
		}
	}
}
