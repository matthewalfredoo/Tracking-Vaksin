﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceModelPemerintah
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PemerintahS", Namespace="http://schemas.datacontract.org/2004/07/Tracking_Vaksin_Services")]
    public partial class PemerintahS : object
    {
        
        private int idField;
        
        private string usernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceModelPemerintah.IServiceModelPemerintah")]
    public interface IServiceModelPemerintah
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelPemerintah/login", ReplyAction="http://tempuri.org/IServiceModelPemerintah/loginResponse")]
        ServiceModelPemerintah.loginResponse login(ServiceModelPemerintah.loginRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceModelPemerintah/login", ReplyAction="http://tempuri.org/IServiceModelPemerintah/loginResponse")]
        System.Threading.Tasks.Task<ServiceModelPemerintah.loginResponse> loginAsync(ServiceModelPemerintah.loginRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="login", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class loginRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ServiceModelPemerintah.PemerintahS pemerintahS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int StatusCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string message;
        
        public loginRequest()
        {
        }
        
        public loginRequest(ServiceModelPemerintah.PemerintahS pemerintahS, string username, string password, int StatusCode, string message)
        {
            this.pemerintahS = pemerintahS;
            this.username = username;
            this.password = password;
            this.StatusCode = StatusCode;
            this.message = message;
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
        public ServiceModelPemerintah.PemerintahS pemerintahS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int StatusCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string message;
        
        public loginResponse()
        {
        }
        
        public loginResponse(bool loginResult, ServiceModelPemerintah.PemerintahS pemerintahS, int StatusCode, string message)
        {
            this.loginResult = loginResult;
            this.pemerintahS = pemerintahS;
            this.StatusCode = StatusCode;
            this.message = message;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IServiceModelPemerintahChannel : ServiceModelPemerintah.IServiceModelPemerintah, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ServiceModelPemerintahClient : System.ServiceModel.ClientBase<ServiceModelPemerintah.IServiceModelPemerintah>, ServiceModelPemerintah.IServiceModelPemerintah
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceModelPemerintahClient() : 
                base(ServiceModelPemerintahClient.GetDefaultBinding(), ServiceModelPemerintahClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceModelPemerintah.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelPemerintahClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceModelPemerintahClient.GetBindingForEndpoint(endpointConfiguration), ServiceModelPemerintahClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelPemerintahClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceModelPemerintahClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelPemerintahClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceModelPemerintahClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceModelPemerintahClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceModelPemerintah.loginResponse ServiceModelPemerintah.IServiceModelPemerintah.login(ServiceModelPemerintah.loginRequest request)
        {
            return base.Channel.login(request);
        }
        
        public bool login(ref ServiceModelPemerintah.PemerintahS pemerintahS, string username, string password, ref int StatusCode, ref string message)
        {
            ServiceModelPemerintah.loginRequest inValue = new ServiceModelPemerintah.loginRequest();
            inValue.pemerintahS = pemerintahS;
            inValue.username = username;
            inValue.password = password;
            inValue.StatusCode = StatusCode;
            inValue.message = message;
            ServiceModelPemerintah.loginResponse retVal = ((ServiceModelPemerintah.IServiceModelPemerintah)(this)).login(inValue);
            pemerintahS = retVal.pemerintahS;
            StatusCode = retVal.StatusCode;
            message = retVal.message;
            return retVal.loginResult;
        }
        
        public System.Threading.Tasks.Task<ServiceModelPemerintah.loginResponse> loginAsync(ServiceModelPemerintah.loginRequest request)
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceModelPemerintah))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceModelPemerintah))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/TrackingVaksinServices/ServiceModelPemerintah.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceModelPemerintahClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceModelPemerintah);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceModelPemerintahClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceModelPemerintah);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceModelPemerintah,
        }
    }
}
