using SimpleFastPortScanner.Ports;
using SimpleFastPortScanner.Scanner;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFastPortScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "127.0.0.1";
            var fromPort = "1";
            var toPort = "2000";

            var portScanners = new List<PortScanner>();

            for (int i = Convert.ToInt32(fromPort); i <= Convert.ToInt32(toPort); i++)          
                portScanners.Add(new PortScanner(host, new Port(i)));
            
            Console.WriteLine("Scanning started");
            Parallel.ForEach(portScanners,
                async s =>
                {
                    if (await s.CanConnect())
                        Console.WriteLine($"Open port: {s.Port.Nb}");              
                });

            Console.ReadLine();

        }

    }
}
