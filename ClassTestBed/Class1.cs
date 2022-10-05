using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTestBed
{
    public class Class1
    {
    }
}
public class MyClass
{
    private string myString;
    public virtual string GetString()
    {
        return myString;
    }
    public string MyString
    {
        set
        {
            myString = value;
        }
    }

}
public class WriteString 
{
    private string myString;
    
}


