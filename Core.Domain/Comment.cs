
using System;

namespace Core.Domain
{
    public class Comment
    {
        private int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime Date { get; set; }

        private int CommentUserId { get; set; }
        public virtual User CommentUser { get; set; }

        private int CommentMadeById { get; set; }
        public virtual User CommentMadeBy { get; set; }

        public bool PubliclyVisible { get; set; }
    }
}
