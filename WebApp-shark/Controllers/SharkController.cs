using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.AccessControl;
using WebApp_shark.Models;

namespace WebApp_shark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharkController : ControllerBase
    {
        private static List<Shark> sharks = new List<Shark> { 
            
                new Shark
                {
                    Id = Guid.NewGuid(),
                    CommonName = "Great White Shark",
                    Specie = "Carcharodon carcharias",
                    Family= "Lamnidae",
                    Size = "Up to 20 feet",
                    Countries = new List<string> { "Mexico", "Australia", "South Africa", "United States" },
                    Depth = "0-3,900 feet",
                    Info = "The great white shark is one of the most well-known and feared predato…"

                },
           new Shark {
                    Id = Guid.NewGuid(),
                    CommonName = "Hammerhead Shark",
                    Specie = "Sphyrnidae",
                    Family= "Sphyrnidae",
                    Size = "Varies by species",
                    Countries = new List<string> {"Tropical and temperate waters worldwide" },
                    Depth = "0-1,600 feet",
                    Info = "Hammerhead sharks are known for their distinctive hammer-shaped heads,…"

                }
            };
        [HttpGet("GetAll")]

        public async Task<ActionResult<Shark>> GetAllSharks()
        {
            return Ok(sharks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Shark>>> GetAllSharks( Guid id)
        {
            var shark = sharks.Find(x=>x.Id == id);
            return Ok(shark);
        }

        [HttpPost("AddShark")]
        public async Task<ActionResult<Shark>> AddShark([FromBody]Shark shark)
        {
            shark.Id = Guid.NewGuid();
            sharks.Add(shark);
            return Ok(shark);
        }


        [HttpPut("UpdateShark/{id}")]
        public async Task<ActionResult<Shark>> UpdateShark(Guid id, Shark request)
        {
            var shark = sharks.Find(x => x.Id == id);
            if (shark == null)
            {
                return NotFound("Not found");
            }

            shark.CommonName = request.CommonName;
                shark.Specie = request.Specie;
                shark.Family = request.Family;
                shark.Size = request.Size;
                shark.Countries = request.Countries;
                shark.Depth = request.Depth;
                shark.Info = request.Info;
                return Ok(shark);
            
        }

        [HttpDelete("DeleteShark/{id}")]
        public async Task<ActionResult<Shark>> DeleteShark(Guid id)
        {
            var shark = sharks.Find(x=> x.Id == id);
            sharks.Remove(shark);
            return Ok(shark);
        }
    }
}
