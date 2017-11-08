using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Family
{
    private List<Person> family;

    public Family()
    {
        family = new List<Person>();
    }

    public void AddMember(Person person)
    {
        family.Add(person);
    }

    public Person GetOldestMember()
    {
        return family.Find(m => m.Age == family.Max(f => f.Age));
    }
}
