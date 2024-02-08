
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using File;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

#region Practice
HttpClient httpClient1 = new HttpClient();

var response = httpClient1.GetStringAsync("https://jsonplaceholder.typicode.com/albums").Result;

List<Albums> albums = JsonSerializer.Deserialize<List<Albums>>(response);

//foreach (var item in albums)
//{
//    Console.WriteLine(item.Title);

//}
title:
Console.WriteLine("axtaracaginiz titleni daxil edin:");
string title = Console.ReadLine();
if (String.IsNullOrWhiteSpace(title))
{
    Console.WriteLine("duzgun daxil edin!");
    goto title;
}
bool check = false;
foreach (var item in albums) //title= for example, ==>> omnis laborum odio
{
    if (item.Title==title)
    {
        Console.WriteLine(item);
        check = true;
    }
}
if (!check)
{
    Console.WriteLine("title movcud deyil");
}


//Task.Run(() =>
//{
//    for (int i = 0; i < 200; i++)
//    {
//        Console.WriteLine(i+" ");
//    }
//});

HttpClient httpClient = new HttpClient();
//var task = GetGoogleSrc().ContinueWith(a => Console.WriteLine(a.Result));

//var task = ShowGoogleSrcAsync();

Task<string> GetGoogleSrc()
{
    var temp = Task<string>.Run(() =>
    {

        var result = httpClient.GetStringAsync("https://www.google.com/?client=safari&channel=mac_bm.tr").Result;
        return result;
    });
    return temp;
}
async Task ShowGoogleSrcAsync()
{
    var result = await httpClient.GetStringAsync("https://www.google.com/?client=safari&channel=mac_bm.tr");
    Console.WriteLine(result);
}
#endregion

#region File

DirectoryInfo di = new DirectoryInfo("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files");
Console.WriteLine(di.FullName);
Console.WriteLine(di.CreationTime);
Console.WriteLine(di.GetFiles());
Console.WriteLine(di.Name);
Console.WriteLine(di.LastAccessTime);
Console.WriteLine(di.Parent);
Console.WriteLine(di.GetFiles().Length);
Console.WriteLine(di.GetDirectories().Length);
Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
FileInfo fi = new FileInfo("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/person.json");
Console.WriteLine("Fullname: " + fi.FullName);
Console.WriteLine("Name: " + fi.Name);
Console.WriteLine("Creation time: " + fi.CreationTime);
Console.WriteLine("Last access time: " + fi.LastAccessTime);
Console.WriteLine("Length: " + fi.Length);
Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
foreach (var item in di.GetFiles())
{
    if (item.Length != 0)
    {
        Console.WriteLine(item.Name);
    }
}
Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
FileStream fd = new FileStream("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/person.json", FileMode.Open);
StreamReader sr = new StreamReader(fd);
var line = sr.ReadLine();
while (line != null)
{
    Console.WriteLine(line);
    line = sr.ReadLine();
}
fd.Close();

//Person person = null;
//person = new Person
//{
//    Fullname = "elmar qarayev",
//    Age = 15
//};
//Serialize(person);
//person=Deserialize();
//Console.WriteLine(person);

void Serialize(Person person)
{
    using (FileStream fs = new FileStream("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/person.json", FileMode.Create))
    {
        var jsonStr = JsonConvert.SerializeObject(person);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(jsonStr);
        sw.Close();
    }
}

Person Deserialize()
{
    Person person = null;
    using (FileStream fs = new FileStream("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/person.json", FileMode.Open))
    {
        StreamReader sr = new StreamReader(fs);
        var jsonStr = sr.ReadToEnd();
        person = JsonConvert.DeserializeObject<Person>(jsonStr);
    }
    return person;
}
#endregion

#region task


List<Person> lp = new List<Person>();

FileInfo fl = new FileInfo("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/personlist.json");

if (!fl.Exists)
{
    Console.WriteLine("axtardiginiz fayl yoxdur , yaradilsinmi? y/n");
    string secim1 = Console.ReadLine();
    if (secim1 == "y")
    {
        var fs = fl.Create();
        fs.Close();
    }
    else
    {
        return;
    }
}
string secim;
//SerializePersonList(lp);
do
{
    lp = DeserializePersonList();

    Console.WriteLine("1.person yarat\n2.personlara bax\n0.exit");
    secim = Console.ReadLine();
    switch (secim)
    {
        case "1":
            AddPerson();
            break;
        case "2":
            LookPerson();
            break;
        case "0":
            Console.WriteLine("Programdan cixildi!");
            break;
        default:
            Console.WriteLine("secim yanlisdir!");
            break;
    }
} while (secim != "0");

static void SerializePersonList(List<Person> personList)
{
    using (FileStream fs = new FileStream("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/personlist.json", FileMode.Create))
    {
        var jsonStr = JsonConvert.SerializeObject(personList);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(jsonStr);
        sw.Close();
    }
}
static List<Person> DeserializePersonList()
{
    List<Person> personList = null;
    using (FileStream fs = new FileStream("/Users/elmar/Desktop/CodeAcademy/Homeworks/File/File/File/Files/personlist.json", FileMode.Open))
    {
        StreamReader sr = new StreamReader(fs);
        var jsonStr = sr.ReadToEnd();
        personList = JsonConvert.DeserializeObject<List<Person>>(jsonStr);
    }
    return personList;

}
void AddPerson()
{
full:
    Console.WriteLine("ad soyad daxil edin:");
    string fullname = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(fullname) || !fullname.CheckFullname())
    {
        Console.WriteLine("duzgun daxil edin!");
        goto full;
    }
age:
    Console.WriteLine("age daxil edin:");
    string ageStr = Console.ReadLine();
    int age;
    if (!int.TryParse(ageStr, out age) || age <= 0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto age;
    }
    Person person1 = new Person
    {
        Fullname = fullname,
        Age = age
    };
    lp.Add(person1);
    SerializePersonList(lp);
}
void LookPerson()
{
    lp = DeserializePersonList();
    foreach (var item in lp)
    {
        Console.WriteLine(item);
    }
}
#endregion

Console.ReadLine();


