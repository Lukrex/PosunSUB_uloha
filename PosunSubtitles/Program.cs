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

            while (true)
            {   //precitaj subor, ziskaj riadky
                string riadok = reader.ReadLine();
                if (riadok == null) break;

                riadky.Add(riadok);
            }
            reader.Close();

            Console.Write("O koľko sekúnd chcete posunúť titulky? (pri zápornych číslach sa posunú vzad): ");
            int pocetFramovPosunu = Convert.ToInt32(Convert.ToDouble(Console.ReadLine()) * fps);

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

            //vypis do konzoly zmenene riadky


            //uloz nove data do noveho suboru

        }
    }
}
