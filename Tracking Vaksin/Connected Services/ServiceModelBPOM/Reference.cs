﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceModelBPOM
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceModelBPOM.IServiceModelBPOM")]
    public interface IServiceModelBPOM
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelBPOM/login", ReplyAction="http://tempuri.org/IServiceModelBPOM/loginResponse")]
        ServiceModelBPOM.loginResponse login(ServiceModelBPOM.loginRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelBPOM/login", ReplyAction="http://tempuri.org/IServiceModelBPOM/loginResponse")]
        System.Threading.Tasks.Task<ServiceModelBPOM.loginResponse> loginAsync(ServiceModelBPOM.loginRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="login", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class loginRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Tracking_Vaksin_Services.BPOMS bpomS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int StatusCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string Message;
        
        public loginRequest()
        {
        }
        
        public loginRequest(Tracking_Vaksin_Services.BPOMS bpomS, string username, string password, int StatusCode, string Message)
        {
            this.bpomS = bpomS;
            this.username = username;
            this.password = password;
            this.StatusCode = StatusCode;
            this.Message = Message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="loginResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class loginResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool loginResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public Tracking_Vaksin_Services.BPOMS bpomS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int StatusCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string Message;
        
        public loginResponse()
        {
        }
        
        public loginResponse(bool loginResult, Tracking_Vaksin_Services.BPOMS bpomS, int StatusCode, string Message)
        {
            this.loginResult = loginResult;
            this.bpomS = bpomS;
            this.StatusCode = StatusCode;
            this.Message = Message;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IServiceModelBPOMChannel : ServiceModelBPOM.IServiceModelBPOM, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ServiceModelBPOMClient : System.ServiceModel.ClientBase<ServiceModelBPOM.IServiceModelBPOM>, ServiceModelBPOM.IServiceModelBPOM
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceModelBPOMClient() : 
                base(ServiceModelBPOMClient.GetDefaultBinding(), ServiceModelBPOMClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceModelBPOM.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelBPOMClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceModelBPOMClient.GetBindingForEndpoint(endpointConfiguration), ServiceModelBPOMClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelBPOMClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceModelBPOMClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelBPOMClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceModelBPOMClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelBPOMClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceModelBPOM.loginResponse ServiceModelBPOM.IServiceModelBPOM.login(ServiceModelBPOM.loginRequest request)
        {
            return base.Channel.login(request);
        }
        
        public bool login(ref Tracking_Vaksin_Services.BPOMS bpomS, string username, string password, ref int StatusCode, ref string Message)
        {
            ServiceModelBPOM.loginRequest inValue = new ServiceModelBPOM.loginRequest();
            inValue.bpomS = bpomS;
            inValue.username = username;
            inValue.password = password;
            inValue.StatusCode = StatusCode;
            inValue.Message = Message;
            ServiceModelBPOM.loginResponse retVal = ((ServiceModelBPOM.IServiceModelBPOM)(this)).login(inValue);
            bpomS = retVal.bpomS;
            StatusCode = retVal.StatusCode;
            Message = retVal.Message;
            return retVal.loginResult;
        }
        
        public System.Threading.Tasks.Task<ServiceModelBPOM.loginResponse> loginAsync(ServiceModelBPOM.loginRequest request)
        {
            return base.Channel.loginAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceModelBPOM))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceModelBPOM))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/TrackingVaksinServices/ServiceModelBPOM.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceModelBPOMClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceModelBPOM);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceModelBPOMClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceModelBPOM);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceModelBPOM,
        }
    }
}