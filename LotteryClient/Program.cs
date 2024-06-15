using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LotteryClient
{
    class Program
    {
        static ServiceReference.LotteryMachineServiceClient lotteryMachineClient;
        
        static void Main(string[] args)
        {
            lotteryMachineClient = new ServiceReference.LotteryMachineServiceClient();
            while (true)
            {
                Thread.Sleep(60000);
                lotteryMachineClient.DrawNumbers();
            }
        }
    }
}
