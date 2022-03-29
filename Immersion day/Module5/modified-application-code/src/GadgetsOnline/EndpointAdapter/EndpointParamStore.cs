using System.Dynamic;

namespace GadgetsOnline.EndpointAdapter
{
	public class EndpointParamStore
	{
		public static dynamic NewEndpointContainer(dynamic CtorParams, dynamic methodParams)
		{
			dynamic endpointContainer = new ExpandoObject();
			endpointContainer.C_PARAMS = CtorParams;
			endpointContainer.M_PARAMS = methodParams;
			return endpointContainer;
		}

		public static dynamic NewContainer()
		{
			return new ExpandoObject();
		}

		public static dynamic GetConstructorContainer(dynamic endpointParams)
		{
			return endpointParams.C_PARAMS;
        }

		public static dynamic GetMethodContainer(dynamic endpointParams)
		{
			return endpointParams.M_PARAMS;
		}

		public static string GetConstructorParamHash(dynamic endpointParams)
		{
			return endpointParams.C_PARAMS_HASH;
		}

		public static void SetConstructorParamHash(dynamic endpointParams, string hash)
		{
			endpointParams.C_PARAMS_HASH = hash;
		}
	}
}
