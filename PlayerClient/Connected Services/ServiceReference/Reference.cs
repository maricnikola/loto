﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayerClient.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ILotteryMachineService")]
    public interface ILotteryMachineService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILotteryMachineService/DrawNumbers", ReplyAction="http://tempuri.org/ILotteryMachineService/DrawNumbersResponse")]
        void DrawNumbers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILotteryMachineService/DrawNumbers", ReplyAction="http://tempuri.org/ILotteryMachineService/DrawNumbersResponse")]
        System.Threading.Tasks.Task DrawNumbersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILotteryMachineServiceChannel : PlayerClient.ServiceReference.ILotteryMachineService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LotteryMachineServiceClient : System.ServiceModel.ClientBase<PlayerClient.ServiceReference.ILotteryMachineService>, PlayerClient.ServiceReference.ILotteryMachineService {
        
        public LotteryMachineServiceClient() {
        }
        
        public LotteryMachineServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LotteryMachineServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LotteryMachineServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LotteryMachineServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DrawNumbers() {
            base.Channel.DrawNumbers();
        }
        
        public System.Threading.Tasks.Task DrawNumbersAsync() {
            return base.Channel.DrawNumbersAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IPlayerService", CallbackContract=typeof(PlayerClient.ServiceReference.IPlayerServiceCallback))]
    public interface IPlayerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerService/InitPlayer", ReplyAction="http://tempuri.org/IPlayerService/InitPlayerResponse")]
        void InitPlayer(string playerName, int number1, int number2, double amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlayerService/InitPlayer", ReplyAction="http://tempuri.org/IPlayerService/InitPlayerResponse")]
        System.Threading.Tasks.Task InitPlayerAsync(string playerName, int number1, int number2, double amount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlayerServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPlayerService/MessageArrived")]
        void MessageArrived(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlayerServiceChannel : PlayerClient.ServiceReference.IPlayerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerServiceClient : System.ServiceModel.DuplexClientBase<PlayerClient.ServiceReference.IPlayerService>, PlayerClient.ServiceReference.IPlayerService {
        
        public PlayerServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PlayerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PlayerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void InitPlayer(string playerName, int number1, int number2, double amount) {
            base.Channel.InitPlayer(playerName, number1, number2, amount);
        }
        
        public System.Threading.Tasks.Task InitPlayerAsync(string playerName, int number1, int number2, double amount) {
            return base.Channel.InitPlayerAsync(playerName, number1, number2, amount);
        }
    }
}
