using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace GadgetsOnline.EndpointAdapter
{
	public class ParamObject {

        public string C_PARAMS { get; set; }
        public string M_PARAMS { get; set; }
    }
	public class EndpointParamStore
	{
		public static dynamic NewEndpointContainer(dynamic CtorParams, dynamic methodParams)
		{
			dynamic endpointContainer = new ExpandoObject();
			endpointContainer.C_PARAMS = CtorParams;
			endpointContainer.M_PARAMS = methodParams;
			return endpointContainer;
		}

		//     public static ParamObject NewEndpointContainer(dynamic CtorParams, dynamic methodParams)
		//     {
		//         CtorParams.FirstOrDefault(x => x.Key == "C_PARAM_HASH");

		//         var paramObject = new ParamObject {
		//  C_PARAMS = CtorParams,
		//  M_PARAMS = methodParams

		//};

		//         return paramObject;
		//     }

		public static dynamic NewContainer()
		{
            //return new ExpandoObject();
            return new ExpandoObject();
        }

		public static dynamic GetConstructorContainer(dynamic endpointParams)
		{
			if (endpointParams.GetProperty != null)
				return endpointParams.GetProperty("C_PARAMS");
			return endpointParams.C_PARAMS;
        }

		public static dynamic GetMethodContainer(dynamic endpointParams)
		{
			if (endpointParams.GetProperty != null)
				return endpointParams.GetProperty("M_PARAMS");
			return endpointParams.M_PARAMS;
		}

		public static string GetConstructorParamHash(dynamic endpointParams)
		{
			if (endpointParams.GetProperty != null)
				return endpointParams.GetProperty("C_PARAMS_HASH").ToString();
			return endpointParams.C_PARAMS_HASH.ToString();
		}

		public static void SetConstructorParamHash(dynamic endpointParams, string hash)
		{
			endpointParams.C_PARAMS_HASH = hash;
		}
	}
}
