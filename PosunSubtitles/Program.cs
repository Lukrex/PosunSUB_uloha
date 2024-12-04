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
            int pocetFramovPosunu = (int)(Convert.ToDouble(Console.ReadLine()) * fps);
            Console.WriteLine("------------------------------------------------------------------------------");

            //ziskaj startFrames, endFrames a zmen ich hodnoty
            for (int i = 0; i < riadky.Count; i++)
            {
                startFrames.Add(Convert.ToInt32(riadky[i].Split('}')[0].Remove(0, 1)));
                endFrames.Add(Convert.ToInt32(riadky[i].Split('}')[1].Remove(0, 1)));
                startFrames[i] += pocetFramovPosunu;
                endFrames[i] += pocetFramovPosunu;
            }

            //zmen riadky
            for (int i = 0; i < riadky.Count; i++)
                riadky[i] = "{"+startFrames[i]+"}{"+endFrames[i]+"}"+riadky[i].Split('}')[2];
            
            //vypis do konzoly zmenene riadky
            foreach (var riadok in riadky)
                Console.WriteLine(riadok);

            //uloz nove data do noveho suboru
            Console.Write("\nAko chcete pomenovať nový súbor? (Pozor aby ste neprepísali existujúci súbor!): ");
            string menoSuboru = Console.ReadLine();

            StreamWriter writer = new StreamWriter(cesta + "\\"+ menoSuboru +".sub");
            foreach (var riadok in riadky)
                writer.WriteLine(riadok);

            writer.Close();
        }
    }
}
