using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMonitorApp
{
    
    public partial class Service1 : ServiceBase
    {
        public static int number = 0;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (var log = new EventLog("Application"))
            {
                log.EnableRaisingEvents = true;
                log.EntryWritten += DisplayEntry;
                Console.ReadLine();
            }


            Console.ReadKey();
        }

        protected override void OnStop()
        {
        }

        static void DisplayEntry(Object sender, EntryWrittenEventArgs e)
        {
            EventLogEntry entry = e.Entry;
            number++;
            Console.WriteLine(number + ". ------------------------------------");
            Console.WriteLine(entry.Message);
            Console.WriteLine();
        }

    }
}




