using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LotteryMachine
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IPlayerService
    {
        [OperationContract]
        void InitPlayer(string playerName, int number1, int number2, double amount);
    }
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void MessageArrived(string message);
    }
}
