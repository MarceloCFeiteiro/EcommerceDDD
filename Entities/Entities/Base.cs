using Entities.Notifiations;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Base : Notifies
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public int Nome { get; set; }
    }
}