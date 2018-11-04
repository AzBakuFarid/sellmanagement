using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Category c1 = new Category("Computer", "Path1");
            Category c2 = new Category("Phone", "Path2");
            Category c3 = new Category("TV", "Path3");
            Category c4 = new Category("Mebel", "Path4");
            List<Category> categories = new List<Category>();
            categories.Add(c1);
            categories.Add(c2);
            categories.Add(c3);
            categories.Add(c4);

            List<Product> products = new List<Product>();
            Dictionary<Product, int> selled = new Dictionary<Product, int>();
            products.Add(new Product("mouse", 10001, c1, 10, 8));
            products.Add( new Product("monitor", 10101, c1, 100,7));
            products.Add( new Product("keyboard", 11001, c1, 20,12));
            products.Add( new Product("IphoneX", 20001, c2, 2000,5));
            products.Add( new Product("Sofa", 40001, c4, 1000,2));
            int sira_nomresi;
            while (true)
            {
                Console.WriteLine("Farid Store-a xos gelmisiniz....");
                Console.WriteLine("mehsul almaq ucun -1-, gelirler barede melumat almaq ucun -2-, yeni mehsul elave etmek ucun -3-, yeni kategoriya elave etmek ucun -4- duymesini sec");

                int todo = int.Parse(Console.ReadLine());
                if (todo == 4) {
                    Console.WriteLine("daxil etmek istediyiniz kategoriyanin adini daxil edin");
                    string ad = Console.ReadLine();
                    Console.WriteLine("daxil etmek istediyiniz kategoriyanin seklini daxil edin");
                    string sekil = Console.ReadLine();
                    if ((categories.FirstOrDefault(f => f.Name.Trim() == ad)) == null) {
                        categories.Add(new Category(ad, sekil));
                    }
                    Console.WriteLine("Kategoriya ugurla yaradildi");
                }
                if (todo == 2) {
                    double gelir=0;
                    foreach (var item in selled)
                    {
                        gelir = selled.Sum(s => s.Key.SellPrice);
                    }
                    Console.WriteLine($"siz haziradek {gelir} manatliq mal satmisiz");
                }
                if (todo == 3) {
                    Console.Write("daxil etmek istediyiniz mehsulun adini daxil edin:");
                    string ad = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("daxil etmek istediyiniz mehsulun barcodun daxil edin (8 reqemli eded):");
                    int barkod = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("daxil etmek istediyiniz mehsulun anbardaki sayini daxil edin:");
                    int say = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("daxil etmek istediyiniz mehsulun satis qiymetini daxil edin:");
                    int qiymet = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("daxil etmek istediyiniz mehsulun tipini asagidaki siyahidan secin. categoriyanin ID nomresini daxil edin:");
                    sira_nomresi = 1;
                    foreach (var item in categories)
                    {
                        Console.WriteLine("sira nomresi | ID nomresi| adi");
                        Console.WriteLine($"{sira_nomresi} \t {item.Id} \t {item.Name}");
                        sira_nomresi++;
                    }

                    try
                    {
                    int categoryId = int.Parse(Console.ReadLine());
                    products.Add(new Product(ad, barkod, categories.First(f=>f.Id== categoryId), qiymet, say));
                        Console.WriteLine("Mehsul ugurla anbara daxil edildi");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("dedim axi, Kategoriyanin id-sini daxil ele.....  ");
                        Console.WriteLine("indi butun emeliyyatlari basdan ele");
                    }
                }
                if (todo == 1)
                {
                    Console.WriteLine("Dukanimizda asagidaki mehsullar var");
                    sira_nomresi = 1;
                    foreach (var item in products)
                    {
                        Console.WriteLine("sira nomresi | mehsulun nomresi | mehsulun adi | mehsulun sayi | mehsulun birinin qiymeti ");
                        Console.WriteLine($"{sira_nomresi} \t\t {item.Barcode} \t\t {item.Name} \t\t {item.ItemCount} \t\t{item.Price} manat");
                        sira_nomresi++;
                    }

                    Console.Write("Almaq istediyiniz ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("mehsulun nomresini");
                    Console.ResetColor();
                    Console.WriteLine(" daxil edin:");

                    int selected = int.Parse(Console.ReadLine());
                    var itemm = products.First(f => f.Barcode == selected);
                    Console.WriteLine($"You selected the {itemm.Name} of {itemm.category.Name}. There is (are) {itemm.ItemCount} of this item aviable in the stock. please select how much do you want");
                    int selectedCount = int.Parse(Console.ReadLine());
                    Console.WriteLine("please conform your pursuit. for OK press -1-, to cansel press -2-");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1) { itemm.ItemCount -= selectedCount; itemm.selledCount += selectedCount; itemm.SellPrice += itemm.Price * selectedCount; }
                    Console.WriteLine(itemm.selledCount);
                    if (selled.ContainsKey(itemm))
                    {
                        selled[itemm] += selectedCount;
                    }
                    else selled.Add(itemm, selectedCount);

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    sira_nomresi = 1;
                    foreach (var item in selled)
                    {
                        Console.WriteLine("sira nomresi | mehsulun nomresi | mehsulun adi | mehsulun sayi | gelir ");
                        Console.WriteLine($"{sira_nomresi} \t\t {item.Key.Barcode} \t\t {item.Key.Name} \t\t {item.Value} \t\t{item.Key.SellPrice} manat");
                        sira_nomresi++;
                    }
                    Console.ResetColor();
                }

            }
        }
    }
}
