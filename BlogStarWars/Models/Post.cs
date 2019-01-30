using System.ComponentModel.DataAnnotations;

namespace BlogStarWars.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [MinLength(3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [MinLength(3)]
        public string Content { get; set; }

        [Display(Name = "Likes")]
        public int QuantLikes { get; set; }

        [Display(Name = "Views")]
        public int QuantViews { get; set; }

        public Post()
        {
        }

        public Post(string title, string descripiton, string content)
        {
            Title = title;
            Description = descripiton;
            Content = content;
            QuantLikes = 0;
            QuantViews = 0;
        }
    }
}
