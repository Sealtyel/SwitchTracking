using System;
using System.Collections.Generic;
using System.IO;

using System.Text;


namespace SwitchTracking
{
    class Class1
    {
           //string prompt="";
         
        public static void Method()
        {
            string path = @"c:\prueba.txt";
            TelnetConnection tc = new TelnetConnection("asta", 23);
            string s = tc.Login("mexqueue", "mexicali", 2000);
            string prompt = "";
            string sData="";
            //prompt="100"+Environment.NewLine;
            bool ban = false;
           
            /*using (StreamWriter writer = File.AppendText(path))
            {
                //writer.WriteLine("Conectado");
                writer.Write(tc.Read()+tc.Read()+tc.Read());
            }*/
           
            //while connected
            tc.WriteLine(prompt);
            prompt = "";
            while (tc.IsConnected && prompt.Trim() != "exit")
            {
                sData += "\n" + tc.Read();

                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("Prueba");
                    writer.Write(sData);
                }

                tc.WriteLine("exit");
                //Console.Write(tc.Read());
                prompt = "exit";
            }
        }
    }
}
