
using System;

namespace Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime Date { get; set; }

        public User MadeBy { get; set; }

        public bool PubliclyVisible { get; set; }
    }
}
