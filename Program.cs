
namespace _tp_work_002
{
    /* @Developpeurs SOH ACHILLE ET SIM FRED */
    /* Nom d'application |*| KOTA  |*| */


    // Welcome , This project is a simpe
    internal class Program
    {
        public const int STOCKMAX = 2;
        public static string?[] TitreFilms = new string[STOCKMAX]; 
        public static int[] CotesDeFilm = new int[STOCKMAX];
        public static string ?GlobalChoixUtilisateur;
        public static bool ContinueADemander = true;
        public static int GlobalIncrementor = -1;
        public const int  COTEMAX = 10;
        public static int MovieCount = 0;

 

        // declaration des variable globas
        static void Main(string[] args)
        {

            // testing scope


            //implementation du scope
            do
            {

                // J'Appelle le manuel
                AfficherMenuUtilisation();
                LeChoixDeUtilisateur("Entrez votre choix :");

                switch (GlobalChoixUtilisateur)
                {
                    case "1":


                        GlobalIncrementor = GlobalIncrementor + 1;
                        MovieCount = MovieCount + 1;
                        MouvieCountTracker();
                        //Console.WriteLine("Global variable " + GlobalIncrementor);

                        //Ajouter

                        AjouterUnFilem();

                        break;

                    case "2":
                        // Afficher
                        AfficherListDesFilms(TitreFilms, CotesDeFilm);
                        break;
                    case "3":
                        ModifierCoteByID(TitreFilms, CotesDeFilm);

                        break;

                    case "4":
                        //Trouve(TitreFilms, CotesDeFilm);
                        TrouverFilmMoinEtPlusPayer(TitreFilms, CotesDeFilm);
                        break;
                    case "5":
                        // trouver la cote Moyens ici..
                        CalculerLaCoteMoyenDesFilms(CotesDeFilm);
                        break;
                    case "6":
                        /* quitter si le choix de l'utilisateur == 6
                         * le programe se ferme 
                         * */
                        ContinueADemander = false;
                        Console.WriteLine(MessageDeFermeture("Merci d'avoir utilisé le programme ! À bientôt ! "));

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($" Desole mais le choix {GlobalChoixUtilisateur} ".ToUpper() +
                            $"n'existe pas !!!".ToUpper());
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;

                }


            } while (ContinueADemander == true);

         
        }


        /* User manual for usage */
        public static void AfficherMenuUtilisation()
        {

            var Date = DateTime.Now.ToString("yyyy-MM-dd");
            if (GlobalIncrementor < 0)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("**Bienvenue dans |*|KOTA|*| **");
                Console.WriteLine($"**Stock Limit |*| {STOCKMAX} |*| **");
                Console.WriteLine($"**Jour : {Date} **");
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine(" ");
            Console.WriteLine("Menu :");
            Console.WriteLine(" ");
            Console.WriteLine("1. Ajouter des films et leurs cotes");
            Console.WriteLine($"2. Afficher tous les films et leurs cotes ({MovieCount})");
            Console.WriteLine("3. Modifier la cote d'un film");
            Console.WriteLine("4. Trouver le film le mieux et le moins bien noté");
            Console.WriteLine("5. Calculer la cote moyenne des films");
            Console.WriteLine("6. Quitter");

        }
        public static string LeChoixDeUtilisateur(string ChoixUtilisateurP)
        {
            Console.WriteLine(" ");
            Console.WriteLine(ChoixUtilisateurP);
            GlobalChoixUtilisateur = Console.ReadLine();

            return ChoixUtilisateurP;
        }
        // quitter le program || Et j'envoie un message de fermeture
        public static string MessageDeFermeture(string MessageFeme)
        {
           
            return MessageFeme;
        }

        /* Ajouter un film dans le programme */
        public static void AjouterUnFilem()
        {
          
            bool LookingForCote = false;
            /* Je demande a l'utilisateur d'entree un titre */
            Console.WriteLine("Entrez le titre du film :");
            string? Titre = Console.ReadLine();

            if (GlobalIncrementor >= STOCKMAX)
            {
                Console.Clear();
                GlobalIncrementor = 0;
                Console.WriteLine(" ERREUR ");
                Console.WriteLine(" \n ");
                Console.WriteLine($"| ERREUR | Desole le stockage maximal est de {STOCKMAX} " +
                    " | ERREUR | ");
                Console.WriteLine(" \n ");
                Console.WriteLine(" ERREUR ");

                // arrete toi la |  STOP return |
                return;
            }
            else
            {
                TitreFilms[GlobalIncrementor] = Titre;

            }

            



            do
            {
              
               
                Console.WriteLine("Entrez la cote du film (sur 10) :");
                string? CoteF = Console.ReadLine();
                if(int.TryParse(CoteF, out int CoteDuFilm))
                {
                    if (CoteDuFilm > 10 || CoteDuFilm < 0)
                    {
                        LookingForCote = true;
                        Console.WriteLine("Desole Mais la cote du film doit varier de (0 - 10)");
                    }
                    else
                    {

                        LookingForCote = false;

                        // else j'ajoute le fillm dans le pagner.

                        CotesDeFilm[GlobalIncrementor] = CoteDuFilm;

                    }

                }
                else
                {
                    LookingForCote = true;
                    Console.WriteLine("Desole Mais la cote du film doit varier de (0 - 10)");
                }



            } while (LookingForCote == true);
            Console.Clear();
            LogoFilmAjoute();



        }
        // Afficher touus les films et les cote
        public static void AfficherListDesFilms(string?[] films, int[] cote)
        {
            
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("|*| Liste des films |*|");
                Console.WriteLine("");

            for (int i = 0; i < films.Length; i++)
                {
                    if (films[i] != null)
                    {
                        Console.WriteLine($"{i + 1}.{films[i]} - {cote[i]} /{COTEMAX}");
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("");



        }
        public static void ModifierCoteByID(string?[] Films, int[] Cote)
        {
            Console.Clear();
            if (MovieCount == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("You need to add a movie before you can modify!".ToUpper());
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"Entrez l'index du film à modifier (1 à {MovieCount})  ");
                string? ChoixIndexString = Console.ReadLine();
                int.TryParse(ChoixIndexString, out int ChoixIndexInt);
                if(ChoixIndexInt > MovieCount)
                {
                    Console.WriteLine("There is no movie on this index!");
                }
                else if (ChoixIndexInt > 0 && ChoixIndexInt <= MovieCount)
                {
                    Console.WriteLine("Entrez la nouvelle cote :");
                    string? CoteIndexString = Console.ReadLine();

                    bool SiIndexConvertir = int.TryParse(ChoixIndexString, out int Index);
                    bool SiCoteConvertir = int.TryParse(CoteIndexString, out int NouvelleCote);

                    
                    if(NouvelleCote >= 0 && NouvelleCote <= 10 && SiCoteConvertir != false)
                    {
                        if (SiCoteConvertir == true && SiIndexConvertir == true)
                        {


                            Cote[Index - 1] = NouvelleCote;
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Cote mise à jour avec succès !");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The new score must be between 0 and 10");
                    }
                }
                else
                {
                    Console.WriteLine("This isn't a valid choice!!");
                }
            }
        }


        public static void TrouverFilmMoinEtPlusPayer(string?[] Films, int[] Cote)
        {
            Console.Clear();


            int Max = Cote[0];
            int Min = Cote[0];

            int IndexMax = 0;
            int IndexMin = 0;
            for(int i = 0; i < Cote.Length; i++)
            {
                
                    if (Cote[i] > Max)
                    {
                   
                        Max = Cote[i];
                        IndexMax = i;

                    }
                    if (Cote[i] < Min)
                    {
                        Min = Cote[i];
                        IndexMin = i;
                    }




            }
            //Console.WriteLine($"Max {Max}");
            //Console.WriteLine($"Min {Min}");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Film le mieux noté : {Films[IndexMax]} - {Max}/10");
            Console.WriteLine($"Film le moin noté : {Films[IndexMin]} - {Min}/10");
            //Console.WriteLine($"Film le moins bien noté : {Films[IndexMin - 1]} - {Min}/10");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void CalculerLaCoteMoyenDesFilms(int[] Cote)
        {
            Console.Clear();
            // verification
            int Moyenne = 0;
            int Somme = 0;
          

            for(int i = 0; i < Cote.Length; i++)
            {
                
                    Somme = Somme + Cote[i];
                

            }
            /* Determiner la cote moyen */

            Moyenne = Somme / Cote.Length;

            AfficherLaCoteMoyenDesFilms(Moyenne);
            

           

        }
        public static void AfficherLaCoteMoyenDesFilms(int CoteMoyen)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"La cote moyenne des films est de : {CoteMoyen}.0/10".ToUpper());
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public static void MouvieCountTracker()
        {
            if (MovieCount > STOCKMAX)  MovieCount = STOCKMAX;
            
        }
        //public static bool ErrorValidation(int[] Cote)
        //    => Cote.Length
        
        public static void LogoFilmAjoute()
        {
            Console.WriteLine(@" _____ ___ _     __  __         _       _  ___  _   _ _____ _____ ____      
|  ___|_ _| |   |  \/  |       / \     | |/ _ \| | | |_   _| ____|  _ \     
| |_   | || |   | |\/| |      / _ \ _  | | | | | | | | | | |  _| | |_) |    
|  _|  | || |___| |  | |     / ___ \ |_| | |_| | |_| | | | | |___|  _ <   _ 
|_|   |___|_____|_|  |_|    /_/   \_\___/ \___/ \___/  |_| |_____|_| \_\ (_)");
        }

         


    }
    /*
     *@Developpeurs SOH ACHILLE ET SIM FRED
     *@Institut Teccart de Montreal*/
    






}
