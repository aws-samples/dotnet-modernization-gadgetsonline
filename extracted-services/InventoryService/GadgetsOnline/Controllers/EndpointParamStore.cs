using System;
using System.Dynamic;

namespace GadgetsOnline.Controllers
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

        //public static dynamic GetConstructorContainer(dynamic endpointParams)
        //{
        //    var obj = endpointParams.GetType();

        //    if (endpointParams.GetProperty != null)
        //        return endpointParams.GetProperty("C_PARAMS");
        //    return endpointParams.C_PARAMS;
        //}

        public static dynamic GetConstructorContainer(dynamic endpointParams)
        {
            return endpointParams.GetProperty("C_PARAMS"); 
        }

        // public static dynamic GetMethodContainer(dynamic endpointParams)
        //{
        //	var obj = endpointParams.GetType();

        //          if (endpointParams.GetProperty != null)
        //		return endpointParams.GetProperty("M_PARAMS");
        //	return endpointParams.M_PARAMS;
        //}

        public static dynamic GetMethodContainer(dynamic endpointParams)
        {
            return endpointParams.GetProperty("M_PARAMS");
        }


       //public static string GetConstructorParamHash(dynamic endpointParams)
		//{
		//	if (endpointParams.GetProperty != null)
		//		return endpointParams.GetProperty("C_PARAMS_HASH").ToString();
		//	return endpointParams.C_PARAMS_HASH.ToString();
		//}
        public static string GetConstructorParamHash(dynamic endpointParams)
        {
            return endpointParams.GetProperty("C_PARAMS_HASH").ToString();
        }
        public static void SetConstructorParamHash(dynamic endpointParams, string hash)
		{
			endpointParams.C_PARAMS_HASH = hash;
		}
	}
}
