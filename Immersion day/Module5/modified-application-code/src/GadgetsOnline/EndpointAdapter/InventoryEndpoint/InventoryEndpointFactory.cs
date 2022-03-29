namespace GadgetsOnline.EndpointAdapter
{
    public class InventoryEndpointFactory
    {
		// Knob that controls branch by abstraction (local / remote call)
		private static bool useRemoteEndpoint = false;

		// Endpoint address of remote endpoint
		private static string remoteEndpoint = "http://localhost:8080";

		private static bool initialized = false;

		// Initiate uses config file to read the value of this knob and endpoint address. Alternatively, can be overridden with parameters
		public static void initEndpointFactory()
		{
			if (initialized)
			{
				return;
			}
			remoteEndpoint = EndpointUtils.getRemoteEndpoint();
			useRemoteEndpoint = EndpointUtils.isRemoteRouting();
			initialized = true;
		}

		
		public static IInventoryEndpoint GetEndpointAdapter()
		{
			initEndpointFactory();
			if (useRemoteEndpoint)
			{
				return new InventoryRemoteEndpoint(remoteEndpoint);
			}
			else
			{
				return new InventoryLocalEndpoint();
			}
		}


	}
}
