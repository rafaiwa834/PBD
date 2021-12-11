using System;
using System.IO.Ports;

namespace PBD_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort port = new SerialPort("COM3", 9600);

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            port.Open();
            Console.ReadKey();
            port.Close();

        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            PBDDbContext dbContext = new PBDDbContext();
            DataModel dataModel = new DataModel();

            SerialPort sp = (SerialPort)sender;

            string indata = sp.ReadTo("e");

            var index = indata.LastIndexOf("s");

            var message = indata.Substring(index+1);

            message = message.Replace(".", ",");

            Console.WriteLine("Temperatura: " + message + "   Data: " + DateTime.Now);

            dataModel.Value = float.Parse(message);

            dbContext.Values.Add(dataModel);
            dbContext.SaveChanges();

        }
    }
}
