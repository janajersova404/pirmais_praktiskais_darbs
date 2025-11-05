using pirmais_praktiskais_darbs;
using pirmais_praktiskais_darbs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


while (true) {
    Console.WriteLine("Izvēlies opciju:");
    Console.WriteLine("1. Darbinieki");
    Console.WriteLine("2. Amati");
    Console.WriteLine("3. Departmenti");
    Console.WriteLine("4. LINQ vaicājumi");
    Console.WriteLine("5. Iziet");

    string tabulas_izvele = Console.ReadLine();

    if (tabulas_izvele == "5") {
        break;
        
    }
    

    using (var db = new Context()) {
        switch (tabulas_izvele) {
            case "1":
                Console.WriteLine("1. Pievienot darbinieku");
                Console.WriteLine("2. Parādīt darbiniekus");
                string darbibaDarbinieki = Console.ReadLine();
                if (darbibaDarbinieki == "1")
                {
                    Console.WriteLine("Vārds: ");
                    string vards = Console.ReadLine();
                    Console.WriteLine("Uzvārds: ");
                    string uzvards = Console.ReadLine();
                    Console.WriteLine("Amata Id: ");
                    int amataid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Departamenta id: ");
                    int depid = int.Parse(Console.ReadLine());

                    db.Darbinieki.Add(new Darbinieks { Vards = vards, Uzvards = uzvards, AmatsId = amataid, DepartamentsId = depid });
                    db.SaveChanges();
                    Console.WriteLine("Darbinieks pievienots!");
                }
                else if (darbibaDarbinieki == "2") {
                    var viss = db.Darbinieki.Include(d => d.Amats).Include(d => d.Departaments).ToList();
                    foreach (var d in viss) {
                        Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} {d.AmatsId}, {d.Amats.Nosaukums}, {d.DepartamentsId}, {d.Departaments.Nosaukums}");
                    }
                }
                break;
            case "2":
                Console.WriteLine("1. Pievienot amatu");
                Console.WriteLine("2. Parādīt amatus");
                string darbibaAmati = Console.ReadLine();
                if (darbibaAmati == "1")
                {
                    Console.WriteLine("Amata nosaukums: ");
                    string nosaukums = Console.ReadLine();
                    db.Amati.Add(new Amats { Nosaukums = nosaukums });
                    db.SaveChanges();
                    Console.WriteLine("Amats pievienots!");
                }
                else if (darbibaAmati == "2") {
                    var viss = db.Amati.ToList();
                    foreach (var a in viss)
                    {
                        Console.WriteLine($"{a.Id}. {a.Nosaukums}");
                    }
                }
                break;

            case "3":
                Console.WriteLine("1. Pievienot departamentu");
                Console.WriteLine("2. Parādīt departamentus");
                string darbibaDep = Console.ReadLine();
                if (darbibaDep == "1")
                {
                    Console.WriteLine("Departamenta nosaukums: ");
                    string nosaukums = Console.ReadLine();
                    db.Departamenti.Add(new Departaments { Nosaukums = nosaukums });
                    db.SaveChanges();
                    Console.WriteLine("Departamenta pievients!");
                }
                else if (darbibaDep == "2") {
                    var viss = db.Departamenti.ToList();
                    foreach (var d in viss) {
                        Console.WriteLine($"{d.Id}. {d.Nosaukums}");
                    }
                }
                break;

            case "4":
                Console.WriteLine("Izvēlies LINQ vaicājumu: ");
                Console.WriteLine("1 - meklēt darbinieku pēc vārda");
                Console.WriteLine("2 - meklēt darbinieku pēc departamenta");
                Console.WriteLine("3 - meklēt darbiniekus pēc amata");
                Console.WriteLine("4 - parādīt visus darbiniekus un to amatu un departamentu");
                Console.WriteLine("5 - parādīt darbinieku skaitu katrā departamentā");
                Console.WriteLine("6 - parādīt amatu, kuros nav darbinieku");

                string vaicajuma_izvele = Console.ReadLine();

                switch (vaicajuma_izvele){
                    case "1":
                        Console.WriteLine("Ievadi vārdu: ");
                        string vards = Console.ReadLine();
                        var darbiniekiPecVarda = db.Darbinieki
                            .Include(d => d.Amats)
                            .Include(d => d.Departaments)
                            .Where(d => d.Vards == vards)
                            .ToList();
                        foreach (var d in darbiniekiPecVarda)
                        {
                            Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} - {d.Amats.Nosaukums}, {d.Departaments.Nosaukums}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ievadi departamenta nosaukumu: ");
                        string depNosaukums = Console.ReadLine();
                        var darbiniekiPecDepartamenta = db.Darbinieki
                            .Include(d => d.Amats)
                            .Include(d => d.Departaments)
                            .Where(d => d.Departaments.Nosaukums == depNosaukums)
                            .ToList();
                        foreach (var d in darbiniekiPecDepartamenta)
                        {
                            Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} - {d.Amats.Nosaukums}, {d.Departaments.Nosaukums}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Ievadi amata nosaukumu: ");
                        string amataNosaukums = Console.ReadLine();
                        var darbiniekiPecAmata = db.Darbinieki
                            .Include(d => d.Amats)
                            .Include(d => d.Departaments)
                            .Where(d => d.Amats.Nosaukums == amataNosaukums)
                            .ToList();
                        foreach (var d in darbiniekiPecAmata)
                        {
                            Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} - {d.Amats.Nosaukums}, {d.Departaments.Nosaukums}");
                        }
                        break;

                    case "4":
                        var visiDarbinieki = db.Darbinieki
                            .Include(d => d.Amats)
                            .Include(d => d.Departaments)
                            .ToList();
                        foreach (var d in visiDarbinieki)
                        {
                            Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} - {d.Amats.Nosaukums}, {d.Departaments.Nosaukums}");
                        }
                        break;

                    case "5":
                        var darbiniekuSkaitsDepartamentos = db.Darbinieki
                            .Include(d => d.Departaments)
                            .GroupBy(d => d.Departaments.Nosaukums)
                            .Select(g => new { Departaments = g.Key, Skaits = g.Count() })
                            .ToList();
                        foreach (var sk in darbiniekuSkaitsDepartamentos)
                        {
                            Console.WriteLine($"{sk.Departaments}: {sk.Skaits} darbinieki");
                        }
                        break;

                    case "6":
                        var amatiBezDarbiniekiem = db.Amati
                            .Include(a => a.Darbinieki)
                            .Where(a => !a.Darbinieki.Any())
                            .ToList();
                        foreach (var a in amatiBezDarbiniekiem)
                        {
                            Console.WriteLine($"{a.Id}. {a.Nosaukums}");
                        }
                        break;

                    default:
                        Console.WriteLine("Nederīga izvēle!");
                        break;
                }
                break;
            default:
                Console.WriteLine("Kļūda!");
                break;
        }
    }
}