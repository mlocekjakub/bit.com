using System.Xml.Linq;



string[][] ConvertCSVTo2DArray(string filePath){
    StreamReader sr = new StreamReader(filePath);
    var lines = new List<string[]>();
    int Row = 0;
    while (!sr.EndOfStream)
    {
        string[] Line = sr.ReadLine().Split(';');
        lines.Add(Line);
        Row++;
    }
    var data = lines.ToArray();
    return data;
}

string filePath = @"C:\Users\zimor\Downloads\Test\Praca.csv"; //zmienić path 
string[][] data = ConvertCSVTo2DArray(filePath);
XElement[] root = new XElement[data.Length * data[0].Length];
XElement[] xmlDayOfPlans = new XElement[data.Length * data[0].Length];
int xmlDaysOfPlanIterator = 0;
int rootIterator = 0;
XElement xml = null;
for (int j = 3; j < data.Length; j++)
{
    XElement[] xmlDayOfPlan = new XElement[data.Length * data[0].Length];
    int xmlDayOfPlanIterator = 0;
    for (int i = 1; i < data[0].Length; i++)
    {
        xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Pracownik", data[j][0]);
        xmlDayOfPlanIterator++;
        xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Data", data[2][i]);
        xmlDayOfPlanIterator++;
        switch (data[j][i])
        {
            case "1":
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Definicja", "Pracy");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("OdGodziny", "06:00");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Czas", "08:00");
                xmlDayOfPlanIterator++;
                break;
            case "2":
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Definicja", "Pracy");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("OdGodziny", "14:00");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Czas", "08:00");
                xmlDayOfPlanIterator++;
                break;
            case "3":
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Definicja", "Pracy");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("OdGodziny", "22:00");
                xmlDayOfPlanIterator++;
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Czas", "08:00");
                xmlDayOfPlanIterator++;
                break;
            case "X":
                xmlDayOfPlan[xmlDayOfPlanIterator] = new XElement("Definicja", "Wolny");
                break;
        }

        xmlDayOfPlans[xmlDaysOfPlanIterator] = new XElement("DzienPlanu", xmlDayOfPlan);
        xmlDaysOfPlanIterator++;
        xmlDayOfPlan = new XElement[data.Length * data[0].Length];
    }
    
    root[xmlDaysOfPlanIterator] = new XElement("DniPlanu", xmlDayOfPlans);
    rootIterator++;
    xmlDayOfPlans = new XElement[data.Length * data[0].Length];
}

xml = new XElement("Root", root);
xml.Save(@"C:\Users\zimor\Downloads\Test\Wyniki.xml");