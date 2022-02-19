using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBclass;

namespace Pictures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpGet("List")]
        public List<Picture> GetAllBooks(int Id)
        {
            return new List<Picture>()
            {
                new Picture()
                {
                    Id = 1,
                    Name = "Помидор",
                    Sourse = "https://pickimage.ru/wp-content/uploads/images/detskie/tomato/pomidor6.jpg",
                },
                new Picture()
                {
                    Id = 2,
                    Name = "Пепега",
                    Sourse = "https://ic.pics.livejournal.com/imhotype/24051864/433166/433166_original.png"
                },
                new Picture()
                {
                    Id = 3,
                    Name = "ХМхмХМ",
                    Sourse = "https://pbs.twimg.com/media/EBmsLq2XkAA83GO.jpg:large"
                }
            };
        }
    }
}