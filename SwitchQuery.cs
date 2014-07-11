using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SwitchTracking
{
    
    class SwitchQuery
    {
        static List<Switch> switches;
        //static string switches = "10.16.222.11";
        static string sData = "";
        static string tipo = "";
        static string modulo = "";
        static string puerto = "";
        static string interfaz = "";
        static string nombre = "";
        static string status = "";
        static string vlan = "";
        static string duplex = "";
        static string velocidad = "";
        static int Count;

        //static DataManager oDataManager = new DataManager(ConfigurationManager.ConnectionStrings["ConnData"].ConnectionString);
       
        //static string[] Host = switches.Split(',');

        public static void spSwitchProcess()
        {
            switches=new List<Switch>();
            SqlConnection conexion = new SqlConnection("Data Source=MEXCASTILS\\SQLEXPRESS;Initial Catalog=SwitchDB;Integrated Security=True");
            conexion.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select idSwitch,ip from Switch", conexion);
            myReader = myCommand.ExecuteReader();
        
            while (myReader.Read())
            {
                 //= myReader.GetString(0);
                switches.Add(new Switch { Id = myReader.GetInt32(0).ToString(), Ip = myReader.GetString(1) });
               
            }
            //int ax = 0;
            //delete old data
            //oDataManager.ExecCommand("DELETE FROM [SwitchMonitor].[dbo].[IDFInterfaceStatus]");
            for (int ax = 0; ax < switches.Count; ax++)
            {
                Count = ax;
                TelnetConnection tc = new TelnetConnection(switches[ax].Ip, 23);
                sData = "";
                bool ban = false;
                //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
                string s = tc.Login("techm", "MexSWKSRead", 2000);

                string prompt = "";
                prompt = "sh int status";

                //while connected
                tc.WriteLine(prompt);
                prompt = "";
                while (tc.IsConnected && prompt.Trim() != "exit")
                {
                    StreamWriter writer = new StreamWriter("C:\\switchdata.txt");
                    
                    sData += tc.Read().Replace('\b', ',').Trim();
                    writer.Write(sData, true);
                    
                    while (sData.EndsWith("-"))
                    {
                        tc.WriteLine(" ");
                        sData += "\n" + tc.Read().Replace('\b', ',').Trim();
                        ban = true;
                    }
                    if (ban == true)
                    {
                        ProcessData(sData,switches[ax].Id);
                        tc.WriteLine("exit");
                        Console.Write(tc.Read());
                        prompt = "exit";
                    }
                    writer.Close();
                }
            }
        }

        private static void ProcessData(string Data, string idSwitch)
        {
            StreamWriter writer = new StreamWriter("C:\\failure.txt");
            string[] sDataPre = Data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] sDataProccesed;
            string[] DataToInsert;
            string sLine;
            string sLineProc;
            for (int x = 0; x < sDataPre.Length; x++)
            {
                sLine = sDataPre[x].Replace(" ", ",");
                if (sLine.Length > 20)
                {
                    sLine = sLine.Replace(sLine.Substring(8, 18), CleanFields(sLine.Substring(8, 18)));
                    if (sLine.Length < 80 && sLine.Length > 36)
                        sLine = sLine.Insert(43, ",,,,");
                    if (sLine.Substring(8, 3) == "   ")
                        sLine = sLine.Insert(8, ",NO NAME          ");
                }
                sDataProccesed = sLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                DataToInsert = new string[sDataProccesed.Length];
                if (sDataProccesed.Length == 6)
                {
                    sLine += sLine;
                }

                if (sDataProccesed.Length == 7)
                {     
                    //for (int y = 0; y < sDataProccesed.Length; y++)
                    //{
                        string sQueryInsert = "";
                        puerto=sDataProccesed[0].Trim();
                        if (puerto.Contains("Po"))
                        {
                            continue;
                        }
                        /*if ((puerto.Contains("Gi5/")) || (puerto.Contains("Gi6/")))//supervisores
                        {

                            continue;

                        }*/
                        nombre = sDataProccesed[1].Trim();
                        status = sDataProccesed[2].Trim();
                        vlan = sDataProccesed[3].Trim();
                        duplex = sDataProccesed[4].Trim();
                        velocidad = sDataProccesed[5].Trim();
                        tipo = sDataProccesed[6].Trim();
                        //////modulo/////
                        
                        /////////////////
                        //sLineProc = sDataProccesed[y].Replace(",", "");
                        if (sDataProccesed[0].Trim().Substring(0, 2) != "Po")
                            /*sQueryInsert = "EXECUTE [SwitchMonitor].[dbo].[spSaveSwitchData] " +
                                                 "'" + switches[Count] + "'" +
                                                 ",'" + sDataProccesed[0].Trim() + "'" +
                                                 ",'" + sDataProccesed[1].Trim() + "'" +
                                                 ",'" + sDataProccesed[2].Trim() + "'" +
                                                 ",'" + sDataProccesed[3].Trim() + "'" +
                                                 ",'" + sDataProccesed[4].Trim() + "'" +
                                                 ",'" + sDataProccesed[5].Trim() + "'" +
                                                 ",'" + sDataProccesed[6].Trim() + "'";*/
                        //

                        try
                        {
                            string query = "";
                            using(SqlConnection sqlConnection1 =
                            new SqlConnection("Data Source=MEXCASTILS\\SQLEXPRESS;Initial Catalog=SwitchDB;Integrated Security=True"))
                            { 
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.Text;
                            query = "INSERT Tracking (idPuerto,idSwitch, fecha, estado, nombre, vlan, duplex, velocidad, tipo) VALUES ('" + puerto + "','"+idSwitch+"', GetDate(),'" + status + "','" + nombre + "'," + vlan + ",'" + duplex + "','" + velocidad + "','"+tipo+"')";
                            cmd.CommandText = query;
                            cmd.Connection = sqlConnection1;

                            sqlConnection1.Open();
                            cmd.ExecuteNonQuery();
                            sqlConnection1.Close();
                            }
                        }
                        catch (Exception e)
                        {

                            writer.WriteLine(puerto, true);
                            writer.WriteLine(e.GetBaseException());
                            writer.WriteLine();
                            
                        }
                        

                        //oDataManager.ExecCommand(sQueryInsert);
                        int a = 0;
                    //}
                }
            }
            writer.Close();
        }

        private static string CleanFields(string sField)
        {
            sField = sField.Replace(",", " ");
            return sField;
        }

        public class Switch
        {
            public string Id { get; set; }
            public string Ip { get; set; }
        }
       
    }
}
