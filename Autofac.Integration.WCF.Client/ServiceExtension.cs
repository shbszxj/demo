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
            try
            {
                return codeBlock((TChannel)proxy);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }

        public static void Use(Action<TChannel> codeBlock)
        {
            IClientChannel proxy = (IClientChannel)_channelFactory.CreateChannel();
            try
            {
                codeBlock((TChannel)proxy);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }

        public async static Task UseAsync(Func<TChannel, Task> codeBlock)
        {
            var proxy = (IClientChannel)_channelFactory.CreateChannel();
            try
            {
                await codeBlock.Invoke((TChannel)proxy);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }

        public async static Task<TReturn> UseAsync<TReturn>(Func<TChannel, Task<TReturn>> codeBlock)
        {
            var proxy = (IClientChannel)_channelFactory.CreateChannel();
            try
            {
                return await codeBlock.Invoke((TChannel)proxy);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }
    }
}
