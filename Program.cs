using pirmais_praktiskais_darbs;
using pirmais_praktiskais_darbs.Models;
using Microsoft.EntityFrameworkCore;
using System;


while (true) {
    Console.WriteLine("Izvēlies tabulu:");
    Console.WriteLine("1. Darbinieki");
    Console.WriteLine("2. Amati");
    Console.WriteLine("3. Departmenti");
    Console.WriteLine("4. Iziet");

    string tabulas_izvele = Console.ReadLine();

    if (tabulas_izvele == "4") {
        break;
        
    }
    Console.WriteLine("Izvēlies darbību:");
    Console.WriteLine("1. Pievienot");
    Console.WriteLine("2. Parādīt");
    string darbibas_izvele = Console.ReadLine();

    using (var db = new Context()) {
        switch (tabulas_izvele) {
            case "1":
                if (darbibas_izvele == "1")
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
                else if (darbibas_izvele == "2") {
                    var viss = db.Darbinieki.Include(d => d.Amats).Include(d => d.Departaments).ToList();
                    foreach (var d in viss) {
                        Console.WriteLine($"{d.Id}. {d.Vards} {d.Uzvards} {d.AmatsId}, {d.Amats.Nosaukums}, {d.DepartamentsId}, {d.Departaments.Nosaukums}");
                    }
                }
                break;
            case "2":
                if (darbibas_izvele == "1")
                {
                    Console.WriteLine("Amata nosaukums: ");
                    string nosaukums = Console.ReadLine();
                    db.Amati.Add(new Amats { Nosaukums = nosaukums });
                    db.SaveChanges();
                    Console.WriteLine("Amats pievienots!");
                }
                else if (darbibas_izvele == "2") {
                    var viss = db.Amati.ToList();
                    foreach (var a in viss)
                    {
                        Console.WriteLine($"{a.Id}. {a.Nosaukums}");
                    }
                }
                break;

            case "3":
                if (darbibas_izvele == "1")
                {
                    Console.WriteLine("Departamenta nosaukums: ");
                    string nosaukums = Console.ReadLine();
                    db.Departamenti.Add(new Departaments { Nosaukums = nosaukums });
                    db.SaveChanges();
                    Console.WriteLine("Departamenta pievients!");
                }
                else if (darbibas_izvele == "2") {
                    var viss = db.Departamenti.ToList();
                    foreach (var d in viss) {
                        Console.WriteLine($"{d.Id}. {d.Nosaukums}");
                    }
                }
                break;
            default:
                Console.WriteLine("Kļūda!");
                break;
        }
    }
}