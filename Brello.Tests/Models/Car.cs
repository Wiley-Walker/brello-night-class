using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brello.Models
{
   public interface ICar
    {
        string Honk();
    }
    public class Car
    { 
        public virtual string Horn()
        {
            ReadyEngines();
            return "HONK!";
        }
        public virtual void ReadyEngines()
        {

        }
    }
}
