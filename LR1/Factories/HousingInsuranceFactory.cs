using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1.Factories
{
    internal class HousingInsuranceFactory : IModelFactory
    {
        public IModel Create()
        {
             return new HousingInsurance(0, string.Empty, string.Empty, string.Empty, new DateTime(), string.Empty, decimal.Zero);
        }
    }
}
