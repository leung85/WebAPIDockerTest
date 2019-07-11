using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppCore3
{
    public class KeypadeService : BackgroundService
    {
        const string portName = "/dev/ttyUSB0";
        private SerialPort port;
        public KeypadeService()
        {
            port = new SerialPort(portName, 19200, Parity.None, 8, StopBits.One);
            port.Open();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int rc;
           
            Console.WriteLine("Start Keypad");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    rc = port.ReadByte();
                    Console.WriteLine(rc);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await Task.Delay(10);
            }
        }

    }
}
