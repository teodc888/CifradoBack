using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jose;

namespace BackendEncriptamiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Encriptamiento : Controller
    {

        private object secretkey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

        [HttpGet("encriptar")]
        public IActionResult Get([FromHeader] string encriptado)
        {
            try
            {

                string encript = Jose.JWT.Encode(encriptado, secretkey, JweAlgorithm.DIR, JweEncryption.A128CBC_HS256);

                return Ok(encript);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("desEncriptar")]
        public IActionResult Desencriptamiento([FromHeader] string encriptado)
        {
            try
            {

                string encript = Jose.JWT.Decode(encriptado, secretkey, JweAlgorithm.DIR, JweEncryption.A128CBC_HS256);

                return Ok(encript);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
