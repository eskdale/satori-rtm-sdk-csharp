﻿using System;
using System.Diagnostics;
using Satori.Rtm.Client;
using Newtonsoft.Json;

class Program
{
    const string endpoint = "YOUR_ENDPOINT";
    const string appkey = "YOUR_APPKEY";

    static void Main()
    {
        // Log messages from SDK to the console
        Trace.Listeners.Add(new ConsoleTraceListener());

        IRtmClient client = new RtmClientBuilder(endpoint, appkey).Build();

        client.OnEnterConnected += cn => Console.WriteLine("Connected to Satori RTM!");

        client.OnError += ex => 
            Console.WriteLine("Failed to connect: " + ex.Message);

        client.Start();

        // Publish, subscribe, and perform other operations here

        Console.ReadKey();

        // Stop and clean up the client before exiting the program
        client.Dispose().Wait();
    }
}