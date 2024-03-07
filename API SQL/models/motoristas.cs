using System.ComponentModel.DataAnnotations;

namespace Lab01.models
{
    public class motoristas
    {
        [Key]
        public int motoristaId { get; set; }
        public string? nombreMotorista { get; set; }
    }
}
