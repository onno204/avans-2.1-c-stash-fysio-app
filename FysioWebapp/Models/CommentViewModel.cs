using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime Date { get; set; }

        public UserViewModel CommentMadeBy { get; set; }

        public bool PubliclyVisible { get; set; }
    }
}
