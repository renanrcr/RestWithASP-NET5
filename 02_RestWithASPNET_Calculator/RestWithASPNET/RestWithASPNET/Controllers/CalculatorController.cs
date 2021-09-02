using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsValidNumbers(firstNumber, secondNumber))
            {
                var calc = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsValidNumbers(firstNumber, secondNumber))
            {
                var calc = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsValidNumbers(firstNumber, secondNumber))
            {
                var calc = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsValidNumbers(firstNumber, secondNumber))
            {
                var calc = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsValidNumbers(firstNumber, secondNumber))
            {
                var calc = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsValidNumbers(firstNumber))
            {
                var calc = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsValidNumbers(params string[] values)
        {
            return values.Count(var => IsNumeric(var)) == values.Count();
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
                return decimalValue;

            return decimalValue;
        }
    }
}
