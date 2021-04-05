using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserComment:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Comment Comment { get; set; }
    }
}
