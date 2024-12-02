using System;
using System.IO;
using System.Collections.Generic;

namespace PosunSUB
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\lenovo\\Desktop\\posunSUB\\titulky.sub");
            List<string> riadky = new List<string>();
            const int fps = 25;

            while (true)
            {   //precitaj subor, ziskaj riadky
                string riadok = reader.ReadLine();
                if (riadok == null) break;

                riadky.Add(riadok);
            }
            reader.Close();

            Console.Write("O koľko sekúnd chcete posunúť titulky? (pri zápornych číslach sa posunú vzad): ");
            int pocetFramov = Convert.ToInt32(Convert.ToDouble(Console.ReadLine()) * fps);

            //ziskaj startFrame, endFrame
            
        }
    }
}
