
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime Date { get; set; }

        private int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        private int? CommentMadeById { get; set; }
        [ForeignKey("CommentMadeById")]
        public virtual User CommentMadeBy { get; set; }

        public bool PubliclyVisible { get; set; }
    }
}
