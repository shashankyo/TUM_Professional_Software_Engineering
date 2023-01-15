using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string Name, int id)
        {
            this.Name = Name;
            this.Id = id;
        }

    }
}
