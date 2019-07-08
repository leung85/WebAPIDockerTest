using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCore3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            // Get a list of serial port names.             
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            // Display each port name to the console.             
            foreach (string port in ports)             {
                Console.WriteLine(port);
            }


            using (var led = new SerialPort("/dev/ttyUSB0", 19200, Parity.None, 8, StopBits.One))
            {
                led.Open();
                byte[] start = new byte[] { 0xA5, 0xFF };
                byte[] text = Encoding.UTF8.GetBytes("1984");
                byte[] end = new byte[] { 0x00 };
                byte[] rv = start.Concat(text).Concat(end).ToArray();
                led.Write(rv, 0, rv.Length);
            }
           

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
