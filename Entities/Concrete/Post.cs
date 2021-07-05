using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Post:IEntity
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }      
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

    }
}
