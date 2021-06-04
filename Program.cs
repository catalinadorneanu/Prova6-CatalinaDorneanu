using System;

namespace Prova6_CatalinaDorneanu
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------
            //RISPOSTE PROVA
            // 1. a, e, g;
            // 2. b, d;
            // 3. c;
            //-----------------

            //- Mostrare tutti gli agenti di polizia
            //- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
            //- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
            //- Inserire un nuovo agente solo se non è già presente nel database
          


            DbConnectedMode caserma = new DbConnectedMode();
           
            Console.WriteLine("--- Caserma ---");
            do
            {
                Console.WriteLine("\n------ Menu ------");
                Console.WriteLine("Premi 1 - Visualizza tutti gli agenti");
                Console.WriteLine("Premi 2 - Visualizza tutti gli agenti per area geografica");
                Console.WriteLine("Premi 3 - Visualizza tutti gli agenti per anni di servizio");
                Console.WriteLine("Premi 4 - Inserisci un nuovo agente");
                Console.WriteLine("Premi 0 - Exit");

                int scelta;
                do
                {
                    Console.Write("\nFai la tua scelta: ");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                  
                    case 1:
                        caserma.GetAll();

                        break;
                    case 2:
                        caserma.GetAllByArea();
                        break;
                    case 3:
                        caserma.GetAllBySeniority();
                        break;
                    case 4:
                        caserma.AddAgent();
                        break;
                    case 0:
                        return;

                }

            } while (true);

        }
    }
}
