using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models
{
    public interface ICar
    {
        string Name { get; }
        public float CalculatePrice();
        public string GetAllParams();

    }
}
