using manipulae.Data.Dto;
using manipulae.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manipulae_unit_test.Mock
{
    static class VideosMock
    {

        static public Video CreateVideoEntity()
        {
            return new Video()
            {
                Id = "xpto",
                Autor = "Marcos",
                CreatedAt = new DateTime(2023, 10, 1),
                Title = "Title",
                Description = "Descubra o que é uma formula manipulada!",
                IsDeleted = false,
                Url = "https://mock.com/video-manipulado"
            };
        }

        static public CreateVideoDto CreateVideoDto()
        {
            return new CreateVideoDto()
            {
                Id = "xpto",
                Autor = "Marcos",
                CreatedAt = new DateTime(2023, 10, 1),
                Title = "Title",
                Description = "Descubra o que é uma formula manipulada!",
                Url = "https://mock.com/video-manipulado",
            };
        }

        static public UpdateVideoDto UpdateVideoDto()
        {
            return new UpdateVideoDto()
            {
                Autor = "Marcos",
                Title = "Title",
                Description = "Descubra o que é uma formula manipulada!",
                Url = "https://mock.com/video-manipulado",
            };
        }
    }
}
