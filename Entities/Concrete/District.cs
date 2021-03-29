using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class District:IEntity
    {
        //Şimdilik db tarafında kullanılmayacak.
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
