using System;

namespace modul4_103082400026
{
    // --- TAHAP 2: TABLE DRIVEN ---
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

    // --- TAHAP 3: STATE-BASED CONSTRUCTION ---
    public enum StateKarakter { Jongkok, Berdiri, Tengkurap, Terbang }
    public enum TriggerKarakter { TombolW, TombolS, TombolX }

    public class PosisiKarakterGame
    {
        public class Transition
        {
            public StateKarakter StateAwal;
            public StateKarakter StateAkhir;
            public TriggerKarakter Trigger;

            public Transition(StateKarakter awal, StateKarakter akhir, TriggerKarakter trigger)
            {
                StateAwal = awal;
                StateAkhir = akhir;
                Trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(StateKarakter.Berdiri, StateKarakter.Terbang, TriggerKarakter.TombolW),
            new Transition(StateKarakter.Berdiri, StateKarakter.Jongkok, TriggerKarakter.TombolS),
            new Transition(StateKarakter.Jongkok, StateKarakter.Berdiri, TriggerKarakter.TombolW),
            new Transition(StateKarakter.Jongkok, StateKarakter.Tengkurap, TriggerKarakter.TombolS),
            new Transition(StateKarakter.Tengkurap, StateKarakter.Jongkok, TriggerKarakter.TombolW),
            new Transition(StateKarakter.Terbang, StateKarakter.Berdiri, TriggerKarakter.TombolS),
            new Transition(StateKarakter.Terbang, StateKarakter.Jongkok, TriggerKarakter.TombolX)
        };

        public StateKarakter currentState = StateKarakter.Berdiri;

        private StateKarakter GetStateBerikutnya(StateKarakter stateAwal, TriggerKarakter trigger)
        {
            StateKarakter stateAkhir = stateAwal;
            foreach (var t in transisi)
            {
                if (t.StateAwal == stateAwal && t.Trigger == trigger)
                {
                    stateAkhir = t.StateAkhir;
                    break;
                }
            }
            return stateAkhir;
        }

        public void UbahState(TriggerKarakter trigger)
        {
            StateKarakter stateBerikutnya = GetStateBerikutnya(currentState, trigger);

            // Logika output khusus NIM mod 3 == 2
            if (currentState == StateKarakter.Berdiri && stateBerikutnya == StateKarakter.Terbang)
            {
                Console.WriteLine("posisi take off");
            }
            else if (currentState == StateKarakter.Terbang && stateBerikutnya == StateKarakter.Jongkok)
            {
                Console.WriteLine("posisi landing");
            }

            currentState = stateBerikutnya;
            Console.WriteLine("State saat ini menjadi: " + currentState);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Pemanggilan Table-Driven
            KodeBuah tableKodeBuah = new KodeBuah();
            Console.WriteLine("=== Implementasi Table-Driven ===");
            Console.WriteLine("Kode Buah Apel \t\t: " + tableKodeBuah.getKodeBuah(NamaBuah.Apel));
            Console.WriteLine("Kode Buah Semangka \t: " + tableKodeBuah.getKodeBuah(NamaBuah.Semangka));

            // Pemanggilan State-Based
            Console.WriteLine("\n=== Implementasi State-Based Construction ===");
            PosisiKarakterGame karakter = new PosisiKarakterGame();
            Console.WriteLine("State Awal: " + karakter.currentState);

            // Simulasi Trigger
            karakter.UbahState(TriggerKarakter.TombolW); // Take Off
            karakter.UbahState(TriggerKarakter.TombolX); // Landing
            karakter.UbahState(TriggerKarakter.TombolS);

            Console.WriteLine("\nTekan Enter untuk keluar...");
            Console.ReadLine();
        }
    }
}