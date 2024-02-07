
using System.Collections.Generic;
using System.Xml.Linq;
using File;
using Newtonsoft.Json;

//Person person = null;
//person = new Person
//{
//    Fullname = "elmar qarayev",
//    Age = 15
//};

//Serialize(person);
//person=Deserialize();
//Console.WriteLine(person);

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
SerializePersonList(lp);
string secim;
do
{
    Console.WriteLine("1.person yarat\n2.personlara bax");
    secim = Console.ReadLine();
    switch (secim)
    {
        case "1":
            AddPerson();
            break;
        case "2":
            LookPerson();
            break;
        default:
            Console.WriteLine("secim yanlisdir!");
            break;
    }
} while (secim!="0");

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
    if (String.IsNullOrWhiteSpace(fullname)|| !fullname.CheckFullname())
    {
        Console.WriteLine("duzgun daxil edin!");
        goto full;
    }
    age:
    Console.WriteLine("age daxil edin:");
    string ageStr = Console.ReadLine();
    int age;
    if (!int.TryParse(ageStr, out age)|| age<=0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto age;
    }
    Person person1 = new Person
    {
        Fullname = fullname,
        Age = age

    };
    lp = DeserializePersonList();
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
Console.ReadLine();

