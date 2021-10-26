
using System;

namespace Core.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime Date { get; set; }

        public int CommentUserId { get; set; }
        public virtual User CommentUser { get; set; }

        public int CommentMadeById { get; set; }
        public virtual User CommentMadeBy { get; set; }

        public bool PubliclyVisible { get; set; }
    }
}
