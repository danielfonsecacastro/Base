using System.ComponentModel.DataAnnotations;

namespace ProjectBase.Web.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string CnpjNumber { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Manager { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Email { get; set; }
        public string WhatsApp { get; set; }
    }
}
