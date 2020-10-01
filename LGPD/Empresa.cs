using System;
using System.Collections.Generic;
using System.Text;

namespace LGPD
{
    public class Empresa
    {
        public int Id { get; set; }

        [SensitiveData]                     // SensitiveData
        public string Nome { get; set; }

        public virtual IEnumerable<Cliente> ClienteNavigationList { get; set; }

        public Empresa()
        {
            ClienteNavigationList = new HashSet<Cliente>();
        }
    }
}
