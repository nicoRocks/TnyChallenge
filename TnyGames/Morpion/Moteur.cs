using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Morpion
{
    public class Moteur
    {
        public string GetValue(string p, int? dernierCoupJoue = null) 
        {


            Plateau plateau = new Plateau(p, dernierCoupJoue);
            Console.WriteLine(plateau.ToString());

            int max = -1000;
            int tmp = 0;
            int position = 1;

            if (plateau.Cases.Where(x => x.motif == Motif.Vide).Count() == 9)
            {
                return "1";
            }
            if (plateau.Cases.Where(x => x.motif == plateau.motifMin).Count() == 1 && plateau.Cases.Where(x => x.motif == Motif.Vide).Count() == 8)
            {
                var c = plateau.Cases.Where(x => x.motif == plateau.motifMin).First();
                return c.Position==5?"1":"5";
            }

            foreach (var c in plateau.Cases)
            {
                if (c.motif == Motif.Vide)
                {
                    c.motif = plateau.motifMax;
                    Console.WriteLine(plateau.ToString());
                    tmp = min(plateau);
                    if (tmp > max)
                    {
                        max = tmp;
                position = c.Position;
                    } 
                    c.motif = Motif.Vide;
                Console.WriteLine("Position {0} : coef {1}", position.ToString(),max);
                }
            }
            return position.ToString() ;
        }

        private string debut(Plateau plateau)
        {
            throw new NotImplementedException();
        }

        private static int max(Plateau plateau)
        {
            if (plateau.IsFull())
            {
                return eval(plateau);
            }
            int coef = -10000;
                 int tmp =0;
            foreach (var c in plateau.Cases)
            {
                if (c.motif == Motif.Vide)
                {
                    c.motif = plateau.motifMax;
                    Console.WriteLine(plateau.ToString());
                    tmp = min(plateau);

                    if (tmp > coef)
                    {
                        coef = tmp;
                    }
                    c.motif = Motif.Vide;
                }
            }
            return coef;
        }

        private static int eval(Plateau plateau)
        {
            var nbPions = plateau.Cases.Where(x => x.motif != Motif.Vide).Count();
            string resultat = "égalité";
            if (plateau.MotifMaxGagne())
            {
                resultat = plateau.motifMax + " gagne";
                Console.WriteLine(resultat);
                return 1000 - nbPions;
            }
            if (plateau.MotifMinGagne())
            {
                resultat = plateau.motifMin + " gagne";
                Console.WriteLine(resultat);
                return -1000 + nbPions;
            }
            Console.WriteLine(resultat);
            return 0;
        }

        private static int min(Plateau plateau)
        {
            if (plateau.IsFull())
            {
                return eval(plateau);
            }
            int coef = 10000;
            int tmp = 0;
            foreach (var c in plateau.Cases)
            {
                if (c.motif == Motif.Vide)
                {
                    c.motif = plateau.motifMin;
                    Console.WriteLine(plateau.ToString());
                    tmp = max(plateau);
                    if (tmp < coef)
                    {
                        coef = tmp;
                    }
                    c.motif = Motif.Vide;
                }
            }
            return coef;
        }

        // public string GetValue(string plateau)
        //{
        //     ///premier coup
        //    if (plateau == new string('0',9))
        //        return "1";

        //    int[,] jeu = new int[3,3];
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            jeu[i,j] = int.Parse(plateau.Substring((i + 1) + ((j * 3))-1, 1));
        //        }
        //    }
        //    affiche(jeu);
        //    int max = -10000;
        //    int tmp, maxi=0, maxj=0, profondeur=5;
        //     //on parcourt toute les cases
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (jeu[i,j] == 0)
        //            {
        //                jeu[i,j] = 1;
        //                Console.WriteLine("joueur 1 joue {0}", (i + 1 + (j) * 3).ToString());
        //                affiche(jeu);
        //                tmp = Min(jeu, profondeur - 1); 
        //                if (tmp > max)
        //                {
        //                    max = tmp;
        //                    maxi = i; 
        //                    maxj = j;
        //                } 
        //                jeu[i,j] = 0;
        //            }
        //        }
        //    }
        //    affiche(jeu);
        //    return (maxi+1 + (maxj)*3).ToString();
        //}

        // private void affiche(int[,] jeu)
        // {
        //    for (int j = 0; j < 3; j++)
        //    {
        //        for (int i = 0; i< 3; i++)
        //        {
        //            string pion = "_";
        //            if(jeu[i,j] ==1)pion = "O";
        //            if(jeu[i,j] ==2)pion = "X";
        //            Console.Write(pion);
        //        }
        //        Console.WriteLine();
        //    }
        // }

        // private int Max(int[,] jeu, int profondeur)
        // {
        //     if (profondeur == 0 || gagnant(jeu) != 0)
        //     {
        //         return eval(jeu);
        //     }
        //     int max = -10000;
        //     int i, j, tmp;
        //     for (i = 0; i < 3; i++)
        //     {
        //         for (j = 0; j < 3; j++)
        //         {
        //             if (jeu[i, j] == 0)
        //             {
        //                 jeu[i, j] = 2;
        //                 Console.WriteLine("joueur 2 joue {0}", (i + 1 + (j) * 3).ToString());
        //                 affiche(jeu);
        //                 tmp = Min(jeu, profondeur - 1);
        //                 if (tmp > max)
        //                 {
        //                     max = tmp;
        //                 }
        //                 jeu[i, j] = 0;
        //             }
        //         }
        //     } return max;
        // }

        // private int gagnant(int[,] jeu)
        // {
        //     int i, j;
        //     int j1 = 0, j2 = 0;
        //     nb_series(jeu, ref j1, ref j2, 3);
        //     if (j1 == 1)
        //     {
        //         return 1;
        //     }
        //     else if (j2 == 1)
        //     {
        //         return 2;
        //     }
        //     else
        //     {          //Si le jeu n'est pas fini et que personne n'a gagné, on renvoie 0      
        //         for (i = 0; i < 3; i++)
        //         {
        //             for (j = 0; j < 3; j++)
        //             {
        //                 if (jeu[i, j] == 0)
        //                 {
        //                     return 0;
        //                 }
        //             }
        //         }
        //     }      //Si le jeu est fini et que personne n'a gagné, on renvoie 3   
        //     return 3;
        // }

        //private int eval(int[,] jeu)
        //{
        //    int vainqueur, nb_de_pions = 0; 
        //    int i, j;      //On compte le nombre de pions présents sur le plateau     
        //    for (i = 0; i < 3; i++)
        //    {
        //        for (j = 0; j < 3; j++) { 
        //            if (jeu[i,j] != 0) {
        //                nb_de_pions++; 
        //            } 
        //        }
        //    }
        //    affiche(jeu);
        //    if ((vainqueur = gagnant(jeu)) != 0)
        //    {
        //        if (vainqueur == 1) 
        //        { 
        //            return 1000 - nb_de_pions; 
        //        }
        //        else if (vainqueur == 2)
        //        {
        //            return -1000 + nb_de_pions;
        //        }
        //        else { 
        //            return 0; 
        //        }
        //    }      //On compte le nombre de séries de 2 pions alignés de chacun des joueurs   
        //    int series_j1 = 0, series_j2 = 0; 
        //    nb_series(jeu, ref series_j1, ref series_j2, 2);
        //    return series_j1 - series_j2;

        //}

        //private void nb_series(int[,] jeu, ref int series_j1, ref int series_j2, int n)
        //{
        //    int compteur1, compteur2, i, j;  series_j1 = 0;
        //     series_j2 = 0; 
        //    compteur1 = 0;
        //    compteur2 = 0;       //Diagonale descendante     
        //    for (i = 0; i < 3; i++)
        //    {
        //        if (jeu[i,i] == 1)
        //        {
        //            compteur1++; compteur2 = 0;
        //            if (compteur1 == n) { series_j1++; }
        //        }
        //        else if (jeu[i,i] == 2)
        //        {
        //            compteur2++; compteur1 = 0; if (compteur2 == n) { series_j2++; }
        //        }
        //    } compteur1 = 0; compteur2 = 0;      //Diagonale montante     
        //    for (i = 0; i < 3; i++)
        //    {
        //        if (jeu[i,2 - i] == 1)
        //        {
        //            compteur1++; compteur2 = 0;
        //            if (compteur1 == n) { series_j1++; }
        //        }
        //        else if (jeu[i,2 - i] == 2)
        //        {
        //            compteur2++; compteur1 = 0; if (compteur2 == n) { series_j2++; }
        //        }
        //    }      //En ligne    
        //    for (i = 0; i < 3; i++)
        //    {
        //        compteur1 = 0; compteur2 = 0;                   //Horizontalement    
        //        for (j = 0; j < 3; j++)
        //        {
        //            if (jeu[i,j] == 1)
        //            {
        //                compteur1++; compteur2 = 0; if (compteur1 == n)
        //                {
        //                    series_j1++;
        //                }
        //            }
        //            else if (jeu[i,j] == 2)
        //            {
        //                compteur2++; compteur1 = 0; if (compteur2 == n) { series_j2++; }
        //            }
        //        } compteur1 = 0; compteur2 = 0;           //Verticalement 
        //        for (j = 0; j < 3; j++)
        //        {
        //            if (jeu[j,i] == 1)
        //            {
        //                compteur1++; compteur2 = 0; if (compteur1 == n)
        //                {
        //                    series_j1++;
        //                }
        //            }
        //            else if (jeu[j,i] == 2)
        //            {
        //                compteur2++; compteur1 = 0;
        //                if (compteur2 == n) { series_j2++; }
        //            }
        //        }
        //    }
        //}
        //private int Min(int[,] jeu, int profondeur)
        //{
        //    if (profondeur == 0 || gagnant(jeu) != 0)
        //    {
        //        return eval(jeu);
        //    }
        //    int min = 10000;
        //    int i, j, tmp;
        //    for (i = 0; i < 3; i++)
        //    {
        //        for (j = 0; j < 3; j++)
        //        {
        //            if (jeu[i,j] == 0)
        //            {
        //                jeu[i, j] = 1;
        //                Console.WriteLine("joueur 1 joue {0}", (i + 1 + (j) * 3).ToString());
        //                affiche(jeu);
        //                tmp = Max(jeu, profondeur - 1);
        //                if (tmp < min) { min = tmp; } jeu[i,j] = 0;
        //            }
        //        }
        //    }
        //    return min;
        //}
    }
    
    public static class Extensions
    {
        public static string ToLetter(this int x)
        {
            if (x == 0) return "A";
            if (x == 1) return "B";
            if (x == 2) return "C";
            throw new Exception("mauvaise coordonnée");
        }
    }
}
