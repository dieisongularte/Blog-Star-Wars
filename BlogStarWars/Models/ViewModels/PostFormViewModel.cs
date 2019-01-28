using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogStarWars.Models.ViewModels
{
    public class PostFormViewModel
    {
        public Post Post { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int TotalLikes { get; set; }
        public int TotalViews { get; set; }
    }
}
