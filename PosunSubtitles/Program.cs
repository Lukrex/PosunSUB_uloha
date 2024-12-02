using System;
using System.IO;
using System.Collections.Generic;

namespace PosunSUB
{
    class Program
    {
        static void Main(string[] args)
        {
            //PREPISTE SI TO PROSIM
            string cesta = "C:\\Users\\lenovo\\Desktop\\posunSUB";

            StreamReader reader = new StreamReader(cesta + "\\titulky.sub");
            List<string> riadky = new List<string>();
            List<int> startFrames = new List<int>();
            List<int> endFrames = new List<int>();
            const int fps = 25;

            //precitaj subor, ziskaj riadky
            while (true)
            {
                string riadok = reader.ReadLine();
                if (riadok == null) break;

                riadky.Add(riadok);
            }
            reader.Close();

            //input od uzivatela
            Console.Write("O koľko sekúnd chcete posunúť titulky? (pri zápornych číslach sa posunú vzad): ");
            int pocetFramovPosunu = Convert.ToInt32(Convert.ToDouble(Console.ReadLine()) * fps);
            Console.WriteLine("------------------------------------------------------------------------------");

            //ziskaj startFrames, endFrames
            for (int i = 0; i < riadky.Count; i++)
            {
                startFrames.Add(Convert.ToInt32(riadky[i].Split('}')[0].Remove(0, 1)));
                endFrames.Add(Convert.ToInt32(riadky[i].Split('}')[1].Remove(0, 1)));
            }

            //zmen framy
            for (int i = 0; i < startFrames.Count; i++)
            {
                startFrames[i] += pocetFramovPosunu;
                endFrames[i] += pocetFramovPosunu;
            }

            //zmen riadky
            for (int i = 0; i < riadky.Count; i++)
                riadky[i] = "{"+startFrames[i]+"}{"+endFrames[i]+"}"+riadky[i].Split('}')[2];
            
            //vypis do konzoly zmenene riadky
            foreach (var i in riadky)
                Console.WriteLine(i);

            //uloz nove data do noveho suboru

        }
    }
}
