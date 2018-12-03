using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //Get api/Calculator/Sum/5/5
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            decimal first = 0, second = 0;
            
          if(!decimal.TryParse(firstNumber, out first) || !decimal.TryParse(secondNumber, out second))
            {
                return BadRequest("valores inválidos");
            }
            return  Ok(first + second);
        }

        //Get api/Calculator/Subtraction/5/5
        [HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            decimal first = 0, second = 0;
            
          if(!decimal.TryParse(firstNumber, out first) || !decimal.TryParse(secondNumber, out second))
            {
                return BadRequest("valores inválidos");
            }
            return  Ok(first - second);
        }

        //Get api/Calculator/Division/5/5
        [HttpGet("Division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            decimal first = 0, second = 0;
            
          if(!decimal.TryParse(firstNumber, out first) || !decimal.TryParse(secondNumber, out second))
            {
                return BadRequest("valores inválidos");
            }
            return  Ok(first / second);
        }

        //Get api/Calculator/Multiplication/5/5
        [HttpGet("Multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            decimal first = 0, second = 0;
            
          if(!decimal.TryParse(firstNumber, out first) || !decimal.TryParse(secondNumber, out second))
            {
                return BadRequest("valores inválidos");
            }
            return  Ok(first * second);
        }
    }
}