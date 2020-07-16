﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autofac.Integration.WCF.Client.TestService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TestService.ITestService")]
    public interface ITestService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestService/TestMethod", ReplyAction="http://tempuri.org/ITestService/TestMethodResponse")]
        void TestMethod();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestService/TestMethod", ReplyAction="http://tempuri.org/ITestService/TestMethodResponse")]
        System.Threading.Tasks.Task TestMethodAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestService/GetCalulation", ReplyAction="http://tempuri.org/ITestService/GetCalulationResponse")]
        int GetCalulation(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestService/GetCalulation", ReplyAction="http://tempuri.org/ITestService/GetCalulationResponse")]
        System.Threading.Tasks.Task<int> GetCalulationAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITestServiceChannel : Autofac.Integration.WCF.Client.TestService.ITestService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestServiceClient : System.ServiceModel.ClientBase<Autofac.Integration.WCF.Client.TestService.ITestService>, Autofac.Integration.WCF.Client.TestService.ITestService {
        
        public TestServiceClient() {
        }
        
        public TestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void TestMethod() {
            base.Channel.TestMethod();
        }
        
        public System.Threading.Tasks.Task TestMethodAsync() {
            return base.Channel.TestMethodAsync();
        }
        
        public int GetCalulation(int a, int b) {
            return base.Channel.GetCalulation(a, b);
        }
        
        public System.Threading.Tasks.Task<int> GetCalulationAsync(int a, int b) {
            return base.Channel.GetCalulationAsync(a, b);
        }
    }
}
