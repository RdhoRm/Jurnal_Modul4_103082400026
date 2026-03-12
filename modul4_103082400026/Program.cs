using System;

namespace modul4_103082400026
{
    public enum NamaBuah
    {
        Apel, Aprikot, Alpukat, Pisang, Paprika, Kurma, Durian, Anggur, Melon, Semangka
    }

    public class KodeBuah
    {
        public string getKodeBuah(NamaBuah buah)
        {
            string[] kodeBuah = {
                "A00", "B00", "C00", "D00", "E00",
                "K00", "L00", "M00", "N00", "O00"
            };

            return kodeBuah[(int)buah];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KodeBuah tableKodeBuah = new KodeBuah();

            Console.WriteLine("=== Implementasi Table-Driven ===");

            Console.WriteLine("Kode Buah Apel \t\t: " + tableKodeBuah.getKodeBuah(NamaBuah.Apel));
            Console.WriteLine("Kode Buah Durian \t: " + tableKodeBuah.getKodeBuah(NamaBuah.Durian));
            Console.WriteLine("Kode Buah Semangka \t: " + tableKodeBuah.getKodeBuah(NamaBuah.Semangka));

            Console.WriteLine("\nTekan Enter untuk melanjutkan...");
            Console.ReadLine();
        }
    }
}
