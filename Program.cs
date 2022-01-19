using bertozzi.mattia._5H.Scaffolding.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bertozzi.mattia._5H.Scaffolding.Models.StudentiClassi db = new();

//i vincoli tipo il codice fiscale UNIQUE Funzionano
//perciò non ci possono essere 2 utenti con stesso codice fiscale

//QUESTI SONO COMMENTATI PERCHè risulterebero già inseriti.

// db.Studentes.Add(
//     new Studente{
//         Nome="alex", 
//         Cognome="mazzoni", 
//         CodiceFiscale="abcd10",
//         FkIdclasse=2}
// );

// db.Classes.Add(
//     new Classe{
//         AnnoScolastico="2021/2022", 
//         Anno=5, 
//         Sezione="H"}
// );

// db.SaveChanges();

//LEGGO I DATI NEL DATABASE
Console.WriteLine("Classi:");
foreach(var c in db.Classes){
    Console.WriteLine(c.ToString());
}
Console.WriteLine("\n");
Console.WriteLine("Studenti:");
foreach(var s in db.Studentes){
    Console.WriteLine(s.ToString());
}
