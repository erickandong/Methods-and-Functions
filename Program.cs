using System.Security.Cryptography.X509Certificates;

namespace Les_Méthodes_ou_Fonctions
{
    internal class Program
    {
        //LECON 7: LES DELEGUES
        //se sont des types de données qui permettent de référencer des méthodes (ou fonctions)  avec une signature spécfique

        delegate void MyDelegate(int nb1, int nb2); //methode
        delegate int MyDelegate2(int nb1, int nb2); //fonction

        //LECON 3: LA METHODE MAIN: c'est l'endroit où le programme démarre l'exécution
        static void Main(string[] args) 
        {

            //LECON7: Exemple1: On crèe deux méthodes concernant les délégués

            void addition(int nb1, int nb2)
            {
                Console.WriteLine(nb1 + nb2);
            }

            void soustraction(int nb1, int nb2)
            {
                Console.WriteLine(nb1 - nb2);
            }

            MyDelegate operation = addition;
            operation(10, 10);

            operation = soustraction ;
            operation(11, 11);


            //LECON7: Exemple2: On crèe deux fonctions concernant les délégués
            int add(int x, int y)
            {
                return (x + y);
            }

            int sous(int x, int y)
            {
                return (x - y);
            }

            MyDelegate2 ope = add;
            Console.WriteLine(ope(20, 20));

            ope = sous;
            Console.WriteLine(ope(30, 20));
            


            foreach (string a in args)
            {
                Console.WriteLine(a);
            }

            //LECON 0: DEFINITION D'UNE METHODE

            void AffichageErreur()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*************");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*************");
                Console.ForegroundColor = ConsoleColor.Yellow;

            }

            //AffichageErreur();

            //Créeons une méthode qui permet d'afficher une table de multiplication

            void Table2( int x)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine($"{i}*{x}={x * i}");
                }
            }

            Table2(2);
            Console.WriteLine();
            Table2(9);



            Console.WriteLine();
            // LECON 1: LES ARGUMENTS DE METHODE


            void ditBonjour(string prenom, int nb)
            {
                for (int i = 0;i <=nb; i++)
                {
                    Console.WriteLine("Bonjour " + prenom);
                }
                
            }

            ditBonjour("Ericka", 4);



            //LECON 2: LES FONCTIONS: c'est une méthode qui renvoi une valeur

            Console.WriteLine();
            //Exemple1
            int Somme(int nb1, int nb2)
            {
                int resultat = nb1 + nb2;
                return resultat;
            }

            Console.WriteLine(Somme(10, 11));


            Console.WriteLine();
            //Exemple2
            string pgq10(int nb)
            {
                if (nb > 10) return "Plus grand que 10";
                if (nb > 10) return "Plus petit que 10";
                return "Egal à 10";
            }

            Console.WriteLine(pgq10(30));


            //LECON3: SURCHARGE DE METHODE : cela fonctionne également avec les fonctions
           
            Console.WriteLine();
            static int Somme1(int nb1, int nb2, int nb3)
            {
                return (nb1 + nb2 + nb3);
            }

            Somme1(1 ,1, 1);


            //LECON4: LES METHODES GENERIQUES

            Console.WriteLine();
            int n = 5;
            string str = "Azerty";
            bool condition = true;

            void Affiche<T>(T element) // Type générique
            {
                Console.WriteLine($"Valeur:{element}");
                Console.WriteLine($"type:{element.GetType()}");
                Console.WriteLine();
                
            }

            Affiche(str);



            //LECON5:  LE TYPE: VAR = VARIABLE IMPLICITE

            Console.WriteLine();

            var i = "azerty"; // c'est peu conseillé de l'utilisé
            Console.WriteLine(i.GetType());



            //LECON6: MOTS-CLES "ref" ET "out"

            Console.WriteLine();
            // methode par valeur: elle donne juste en sortie Jean et ne considère pas ce qui est définie dans la méthode
            void MethodeParVal(string str)
            {
                str = "Toto";
            }

            string prenom = "jean";
            MethodeParVal(prenom);
            Console.WriteLine("MethodeParVal " + prenom);


            // methode par référence: change Jean en Toto
            void MethodeParRef( ref string str)
            {
                str = "Toto";
            }


            string prenom2 = "jean";
            MethodeParRef(ref prenom2);
            Console.WriteLine("MethodeParRef " + prenom2);

            // methode out: mm fonctionnement que ref mais on peut décider de ne pas initialiser la variable "prenom3" au depart
            void MethodeOut(out string str)
            {
                str = "Tata";
            }


            string prenom3;
            MethodeOut(out prenom3);
            Console.WriteLine("MethodeOut " + prenom3);


            //LECON 8:  DELEGUE ACTION
            // Action est un type de délégué prédéfini qui encapsule une méthode qui ne retourne pas de valeur
            //Il peut accepter jusqu'à 16 paaramètres de types différents
            //C'est souvent utilisés pour représenter des cations à exécuter comme des opérations ou des ta ches qui n'ont pas besoins de renvoyer une valeur

            //Exemple1
            void print(string s)
            {
                Console.WriteLine(s);
            }

            Action<string> affiche;
            affiche = print;
            print("Salut toi");

            //Exemple2 (plus simplifié)
            Action<string> affiche2 = str => Console.WriteLine(str);
            affiche2("toto");

            //Exemple3: Methode anonyme
            Action<string> affiche3 = delegate (string str)
            {
                Console.WriteLine(str);
            };
            affiche3("Bonjour toi");




            //LECON 9: Date et Heure

            //Date
            DateTime maintenant = DateTime.Now; // date actuelle
            Console.WriteLine(maintenant);
            Console.WriteLine("jour" + maintenant.Day);
            Console.WriteLine("mois" + maintenant.Month);
            Console.WriteLine("année" + maintenant.Year);

            //Heure
            Console.WriteLine("Heure" + maintenant.Hour);
            Console.WriteLine("Minutes" + maintenant.Minute);
            Console.WriteLine("Secondes" + maintenant.Second);
            Console.WriteLine("MilliSec" + maintenant.Millisecond);

            TimeSpan heureDuJour = maintenant.TimeOfDay;//ajoute une intervalle
            Console.WriteLine("heure actuelle" + heureDuJour);

            //Augmente ou réduit l'heure
            TimeSpan interval = new TimeSpan(0, 10, 0);
            Console.WriteLine("Heure +10m" + heureDuJour.Add(interval));
            Console.WriteLine("Heure -10m" + heureDuJour.Subtract(interval));

            //ajoute deux mois de plus a une date actuelle
            DateTime nouvelleDate = maintenant.AddMonths(2);
            Console.WriteLine("Date +2mois" + nouvelleDate);

            //enlève deux mois  a une date actuelle
             nouvelleDate = maintenant.AddMonths(-2);
            Console.WriteLine("Date -2mois" + nouvelleDate);


            //ajoute 15 jours de plus a une date
            nouvelleDate = maintenant.AddDays(15);
            Console.WriteLine("Date +15jours" + nouvelleDate);

            
            DateTime ceJour = DateTime.Today;
            Console.WriteLine("Nous somme le " + ceJour); //affiche la date du jour
            Console.WriteLine("Hier nous etions le " + ceJour.AddDays(-1)); // //affiche la date d'hier

            //CALCULS ENTRE LES DATES

            //Différence entre les dates
            DateTime dmaintenant = DateTime.Now;
            DateTime dnaissance = new DateTime(1974, 11, 24);

            TimeSpan resultat = dmaintenant.Subtract(dnaissance);
            Console.WriteLine("Resultat " + resultat);

            Console.WriteLine(" nbjour" + resultat.Days);
            Console.WriteLine(" nb h" + resultat.Hours);
            Console.WriteLine(" nb m" + resultat.Minutes);
            Console.WriteLine(" nb sec" + resultat.Seconds);
            Console.WriteLine(" nb millisec" + resultat.Milliseconds);

            //Comparaison entre les dates
            DateTime d1 = new DateTime(2021, 2, 1);
            DateTime d2 = new DateTime(2021, 1, 1);

            int compare =(DateTime.Compare(d1,d2));
            if (compare == -1) Console.WriteLine(d1 + " plus tot que" + d2);
            if (compare ==  1) Console.WriteLine(d2 + " plus tot que" + d1);

            //Formatage de date
            DateTime maintenant2 = DateTime.Now;
            Console.WriteLine(maintenant2.ToString("d"));
            Console.WriteLine(maintenant2.ToString("dd"));
            Console.WriteLine(maintenant2.ToString("ddd"));
            Console.WriteLine(maintenant2.ToString("dddd"));

            Console.WriteLine(maintenant2.ToString("MMMM"));
            Console.WriteLine(maintenant2.ToString("yyyy"));
            Console.WriteLine(maintenant2.ToString("dddd dd MMMM yyyy"));


            //Formatage de l'heure
            Console.WriteLine(maintenant2.ToString("H:mm:ss"));

            //Nombre de jour entre deux dates
            DateTime an1 = new DateTime(1974, 11, 24);
            DateTime m = DateTime.Now;

            TimeSpan diffDate = m - an1;
            Console.WriteLine("j'ai " + diffDate.Days + " jours.");

            int min = diffDate.Days * 1440;
            Console.WriteLine("j'ai " + min + " min.");


            //LECON 10: MANIPULER LES CHAINES DE CARACTERES

            string myString = "  Le C# c'est TOP  "; 
            myString = myString.Trim(); //permet de supprimer les espaces
            myString = myString.ToLower(); //permet de mettre les caractères en minuscule
            myString = myString.ToUpper(); //permet de mettre les caractères en majuscules
            myString = myString.Replace("Le", "The"); //permet de changer une chaine de caractère
            myString = myString.Replace('C', 'F'); //permet de changer un caractère
            myString = myString.Remove(0, 3); //permet de supprimer un caractère à l'aide des indices

            if (myString.Contains("TOP"))
                Console.WriteLine("TOP est present");

            myString = myString.Substring(0, 5);
            Console.WriteLine(myString.IndexOf("W")); //donne l'index de la lettre W dans le texte myString
            Console.WriteLine(myString.LastIndexOf("0"));//donne l'index du dernier mot que contient la lettre recherchée

            //Chaine de caractères transformée en Tableau
            string myString2 = "jean,luc,marc,zoe,lana";
            string[] tabmyString2 = myString2.Split(","); //methode qui permet de ranger les chaines de caractères dans un tableau

            foreach (string item in tabmyString2)
            {
                Console.WriteLine(item);
            }

            //Tableau transformer en chaine de caractères

            string myString3 = String.Join(",", tabmyString2);
            Console.WriteLine(myString3);




            //LECON 11 : CLASSE "ARRAY"
            //Elle va nous permettre de faire des opérations sur les tableaux

            string[] tableau1 = { "Zoe", "Luc", "Marc", "Alan", "Jean", "Zoe" };
            string[] tableau2 = new string[tableau1.Length];

            Array.Copy(tableau1, tableau2, tableau1.Length); //met le tab2 a la mm taille que le tab1
            Array.Clear(tableau2, 0, 2); //supprime les 03 premiers éléments du tableau2
            Console.WriteLine("Index de Alan " + Array.IndexOf(tableau2,"Alan")); //permet de chercher l'index d'une chaine de caractères dans le tableau2
            Console.WriteLine("Index du dernier Zoe " + Array.LastIndexOf(tableau2,"Zoe"));
            Array.Reverse(tableau2); //inverse l'ordre du tableau
            Array.Resize(ref tableau2, 10);//redimensionnement d'un tableau à 10 éléments
            Array.Sort(tableau2);//Tri d'un tableau par ordre alphabetique
            tableau2 = null; //Supprimer un tableau




            Console.ReadKey();

        }
    }
}
