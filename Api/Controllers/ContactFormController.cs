using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactFormController : ControllerBase
    {
        [HttpPost]
        public IActionResult SubmitContactForm([FromBody] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                // Handle the contact form submission here (save to database, send email, etc.)
                return Ok(new { message = "Form submitted successfully!" });
            }

            return BadRequest(ModelState);
        }
    }
}
