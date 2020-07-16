using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Client
{
    public static class Service<TChannel>
    {
        public static ChannelFactory<TChannel> _channelFactory =
            new ChannelFactory<TChannel>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:1010/TestService"));

        public static TReturn Use<TReturn>(Func<TChannel, TReturn> codeBlock)
        {
            IClientChannel proxy = (IClientChannel)_channelFactory.CreateChannel();
            bool success = false;
            try
            {
                TReturn result = codeBlock((TChannel)proxy);
                proxy.Close();
                success = true;
                return result;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }

        public static void Use(Action<TChannel> codeBlock)
        {
            IClientChannel proxy = (IClientChannel)_channelFactory.CreateChannel();
            bool success = false;
            try
            {
                codeBlock((TChannel)proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }
    }
}
