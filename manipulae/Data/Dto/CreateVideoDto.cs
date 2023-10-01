using System.ComponentModel.DataAnnotations;
using manipulae.Data.Models;

namespace manipulae.Data.Dto;

public class CreateVideoDto
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Id { get; set; }

    [MaxLength(200, ErrorMessage = "Insira no máximo 200 caracteres")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Title { get; set; }

    [MaxLength(400, ErrorMessage = "Insira no máximo 400 caracteres")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Description { get; set; }

    [MaxLength(100, ErrorMessage = "Insira  no máximo 100 caracteres")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Autor { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Url { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    public DateTime CreatedAt { get; set; }

    public static Video FromVideo(CreateVideoDto dto)
    {
        return new Video()
        {
            Id = dto.Id,
            Autor = dto.Autor,
            CreatedAt = dto.CreatedAt,
            Description = dto.Description,
            Title = dto.Title,
            Url = dto.Url
        };
    }
}