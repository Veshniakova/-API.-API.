using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Reflection;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        [HttpGet("find-by-name")]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (name == null || name == " ")
            { return BadRequest("������� ���!"); }
            else
                Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            { return BadRequest("����� ������ ��������!!!"); }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
                return Ok(Summaries);
            else if (sortStrategy == 1) //������� ��������������� ������ �� �����������.
            {
                Summaries.Sort();
                return Ok();
            }
            else if (sortStrategy == -1) //������� ��������������� ������ �� ��������.
            {
                Summaries.Reverse();
                return Ok();
            }
            else 
            { return BadRequest("������������ �������� ��������� sortStrategy"); }
        }

        //�������� �������� ��� ���� �������, � ������� ����������� ��������
        //(�������� �� ��������� �������� �������������� �������)


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}