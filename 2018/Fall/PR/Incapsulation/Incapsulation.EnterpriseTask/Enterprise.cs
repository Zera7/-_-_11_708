using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        public Enterprise(Guid guid)
        {
            this.guid = guid;
        }

        private Guid guid;
        public Guid Guid { get => guid; }

        public string Name { get; set; }

        private string inn;
        public string Inn
        {
            get => inn;
            set
            {
                if (inn.Length != 10 || !inn.All(z => char.IsDigit(z)))
                    throw new ArgumentException();
                inn = value;
            }
        }

        public DateTime EstablishDate { get; set; }

        public TimeSpan ActiveTimeSpan { get => DateTime.Now - EstablishDate; }

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == guid))
                amount += t.Amount;
            return amount;
        }
    }
}