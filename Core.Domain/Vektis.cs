
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Vektis
    {
        public int Id { get; set; }

        public string Position { get; set; }

        public string Text { get; set; }
    }
}
