using ATM.Models;
using System.Transactions;

namespace ATM
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            List<string> EmeliyyatlarSiyahisi = new();
            Dictionary<DateTime, string> EmeliyyatSiyahisi = new()
            { { DateTime.Now.AddDays(20), "Ilk emeliyyatdir bu eslinde sbhdjs" },
              { DateTime.Now.AddMonths(2), "Bu iyula dushecey" }  };


            Random rand = new Random();
            
            int[] MexaricStandartlari = new int[] { 10, 50, 100, 500, 1000 };
            Card C1 = new("KapitalBank", "MahammadGguziev", "4169738872819999", "1999", rand.NextInt64(100, 999).ToString(), "0526", 1222) ;
            Card C2 = new Card("KapitalBank", "SuzuaKing", "4169738899988999", "2000", rand.NextInt64(100, 999).ToString(), "0128", 1000);  

            User U1 = new User(Guid.NewGuid(), "maham", "Guziev", 23, 999, C1);    // U1.AddAccountToUser(C2);
            User U2 = new User(Guid.NewGuid(), "Gapko", "Kody", 26, 888, C2);
            BankClass bc = new();    bc.AddClient(U1);  bc.AddClient(U2);     // bc.AddClient(C2); //bc.AddCard()
             
            bool firstWhile = true;
            int choose1 = 0;
            Console.BackgroundColor = ConsoleColor.Cyan;  Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t\tWelcome Bank\n\n"); Card find = new();
            Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ;
            ///////Girish PIN ile olacag ki, BankClassi ozunde kartlar Listi saxliyir, Daxil olan pin ile kardin movcudlugu yoxlanir
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black  ; Console.ForegroundColor = ConsoleColor.DarkYellow ;
                Console.Write("Card PIN daxil edin : "); Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ;
                string IncPin = Console.ReadLine();  int chec = 0;

                foreach (Card co in bc.Cards)
                {
                    if (co.PIN == IncPin) { find = co; chec++; }
                }
                try
                {
                    if (chec == 0)
                    {
                        throw new Exception("Dail eddiyiniz pin ile Card mevcut deyil...");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.BackgroundColor = ConsoleColor.Black    ; Console.ForegroundColor = ConsoleColor.Red ;
                    Console.WriteLine(ex.Message);
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------\n");
                    
                    continue;
                }
            }


            ////////////Mevcud Pin daxil edildikden sonra ish bashlanir
            while (firstWhile )
            {
                Console.Clear();
                
            if (choose1 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Blue ; }
            Console.WriteLine("\tBalance");
            if (choose1 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Blue; }
            Console.WriteLine("\tNagd Pul");
            if (choose1 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Blue; }
            Console.WriteLine("\tEmeliyyat siyahisi");
            if (choose1 == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Blue; }
            Console.WriteLine("\tKartdan karta kochurme");
            if(choose1 == 4) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Blue; }
                Console.WriteLine("\tEXIT");
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;


                dynamic upDown = Console.ReadKey(true);
                    if (upDown.Key == ConsoleKey.UpArrow && choose1 != 0) { choose1--;  }
                    else if (upDown.Key == ConsoleKey.DownArrow  && choose1 != 4) { choose1++;   }
                    else if(upDown.Key == ConsoleKey.Enter )
                    {
                    if(choose1 == 0) {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkGreen ; Console.ForegroundColor = ConsoleColor.Black ;
                        Console.WriteLine("\t\tBalance Melumati ");
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White ;
                        Console.WriteLine($"Balansiniz : {find.Balance}\n");
                        Console.WriteLine("Menuya qayitmaqchun istenilen simvolu dail edin .");     //Console.ReadKey(true); 
                    } 

                    else if(choose1 == 1) 
                    {
                        // Console.Clear();
                        int sechimMex = 0;
                        while (true) 
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen; Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\t\tNagd pul");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Cekmek istediyiniz meblegi daxil edin :\n");
                            if(sechimMex == 0) { Console.BackgroundColor = ConsoleColor.White;  Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ; }
                            Console.Write("1) 10 AZN  \t");
                            if (sechimMex == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.Write(" 2) 50 AZN\n  ");
                            if (sechimMex == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.Write("  3) 100 AZN \t ");
                            if (sechimMex == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine(" 4) 500 AZN  ");
                            if (sechimMex == 4) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.Write("5) 1000 AZN \t ");
                            if (sechimMex == 5) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Red; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("6)  DIGER > >");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                            dynamic Rmexaric = Console.ReadKey();
                            if (Rmexaric.Key == ConsoleKey.UpArrow && sechimMex != 0) { sechimMex--; continue; }
                            else if (Rmexaric.Key == ConsoleKey.DownArrow && sechimMex != 5) { sechimMex++; continue; }
                            else if (Rmexaric.Key == ConsoleKey.Enter)
                            {
                                try
                                {
                                    if (sechimMex == 0)
                                    {
                                        if (find.Balance < 10) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= 10; Console.WriteLine("Balansinizdan 10 azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, "Mexaric : 10 AZN");
                                    }
                                    else if (sechimMex == 1)
                                    {
                                        if (find.Balance < 50) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= 50; Console.WriteLine("Balansinizdan 50 azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, "Mexaric : 50 AZN");
                                    }
                                    else if (sechimMex == 2)
                                    {
                                        if (find.Balance < 100) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= 100; Console.WriteLine("Balansinizdan 100 azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, "Mexaric : 100 AZN");
                                    }
                                    else if (sechimMex == 3)
                                    {
                                        if (find.Balance < 500) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= 500; Console.WriteLine("Balansinizdan 500 azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, "Mexaric : 500 AZN");
                                    }
                                    else if (sechimMex == 4)
                                    {
                                        if (find.Balance < 1000) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= 1000; Console.WriteLine("Balansinizdan 1000 azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, "Mexaric : 1000 AZN");
                                    }
                                    else if (sechimMex == 5)
                                    {
                                        Console.Write("Enter Mexaric edmey istediyiniz mebleg : ");
                                        int Dek = int.Parse(Console.ReadLine());
                                        if (find.Balance < Dek) throw new Exception("Balansda kifayet qeder mebleg yoxdur ..");
                                        find.Balance -= Dek; Console.WriteLine($"Balansinizdan {Dek} azn cixarildi. Pullar hazirlanir ...");
                                        find.AddCardOperations(DateTime.Now, $"Mexaric : {Dek} AZN");
                                    }
                                }  
                                
                                catch (Exception ex) 
                                {
                                    Console.WriteLine("---------------------------------------------------------");
                                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message} \n Enter any key for Back"); 
                                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("---------------------------------------------------------\n"); Console.ReadKey(true); continue;
                                   
                                }
                                
                                Console.WriteLine("\n\nEnter any key for go back ."); 
                                break;
                            }
                            else { continue; }
                        }
                    }
                          ///////Yuxaridaki her bir emeliyyati string halinda ozunde saxlayacah olan bir list yaradacam ve her bir emeliyyatin icrasindan sonra 
                          ///hemin liste add edeceyem hemin emeliyyati ve choose 1 == 2 olan ashagidaki sechim ile ekrana yazdiracayam ...
                    else if(choose1 == 2) 
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkGreen; Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t\tEmeliyyatsiyahisi");
                        Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ;
                        var siraliAnahtarlar = find.GetCardOperations().OrderBy(x => x.Key);
                        {
                            //Console.WriteLine("son neche gunun emeliyyatlar siyahisini gormek istediniz : ");
                            //int day = int.Parse(Console.ReadLine());
                            
                            foreach (var eleman in siraliAnahtarlar)
                            {   
                                Console.WriteLine("{0}: {1}", eleman.Key, eleman.Value);
                            }
                        }
                    }

                    else if(choose1 == 3) 
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkGreen; Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t\tTransfer");
                        Console.BackgroundColor = ConsoleColor.Black ; Console.ForegroundColor = ConsoleColor.White ;
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Meblegi transfer edeceyiniz kartin PIN  daxil edin .."); Console.ForegroundColor = ConsoleColor.White;
                        
                        string Pn = Console.ReadLine(); int check2 = 0;
                        foreach (var a in bc.Cards)
                        {
                            if (a.PAN == Pn)
                            {
                                check2++; break;
                            }
                        }
                        try
                        {
                            if (check2 == 0) throw new Exception("Daxil etdiyiniz PAN ile Card hesabi mevcut deil ...");
                        }
                        catch (Exception ex) 
                        { 
                            //Console.WriteLine($"{ex.Message} \n Enter any key for go back "); Console.ReadKey(true); continue;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{ex.Message} \n Enter any key for Back");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------------------------------------------\n"); Console.ReadKey(true); continue;
                        }
                       
                        
                        
                        Console.Write("Transfer edmek istediyiniz meblegi daxil edin : ");
                        int meblegTr = int.Parse(Console.ReadLine());
                        try
                        {
                            if (find.Balance < meblegTr) throw new Exception($"Balansda kifayet qeder veftsait yoxdur. Balansiniz {find.Balance} tehskil edir.");
                        }
                        catch (Exception ex) 
                        { 
                            
                            Console.WriteLine("---------------------------------------------------------");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{ex.Message} \n Enter any key for Back");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------------------------------------------\n"); Console.ReadKey(true); continue;
                        }
                        find .Balance -= meblegTr;
                        Console.WriteLine($"{meblegTr} AZN {Pn} PAN Cardina kochuruldu.  Balansiniz {find.Balance} AZN teshkil edir ");
                        find.AddCardOperations(DateTime.Now, $"{meblegTr} AZN {Pn} PAN Cardina kochuruldu.");
                        
                       Console.ReadKey(true);
                    }
                    
                    else break;
                    dynamic maham = Console.ReadKey(true);
                   




                }
                    


            
                //Console.Write("MAahaamamam");   Console.ReadKey(true);
        }


        }
    }
}

