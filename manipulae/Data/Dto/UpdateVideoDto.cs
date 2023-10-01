using System.ComponentModel.DataAnnotations;

namespace manipulae.Data.Dto;

public class UpdateVideoDto
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(200, ErrorMessage = "Insira no máximo 200 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]

    [MaxLength(400, ErrorMessage = "Insira no máximo 400 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(100, ErrorMessage = "Insira  no máximo 100 caracteres")]
    public string Autor { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    [MinLength(30, ErrorMessage = "Insira no mínimo 30 caracteres")]
    public string Url { get; set; }
}