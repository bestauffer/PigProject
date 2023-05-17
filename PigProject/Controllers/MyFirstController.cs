using Microsoft.AspNetCore.Mvc;
using PigProject.Models;
using System.Data;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PigProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstController : ControllerBase
    {
        // GET: api/<FirstController>
        [HttpGet]
        public List<CarData> Get()
        {
            FinalPigDBContext context = new();
            var carQuery = from eachCountEvent in context.CarDataTables
                           where eachCountEvent.CityId == 37
                           group eachCountEvent by eachCountEvent.CityId into g
                           orderby g.Count() descending
                           select new
                           {
                               CityId = g.Key,
                               NumberOfElectricVehicles = g.Count()
                           };

            var popQuery = from eachCountEvent in context.PopDataTables
                           where eachCountEvent.CityName == "Lynnwood"
                           select new
                           {
                               eachCountEvent.Pop2021
                           };
            List<CarData> myList = new();
            /*foreach (var item in carQuery)
            {
                String temp = item.NumberOfElectricVehicles.ToString();
                myList[0] = temp;
            }
            int xyz = 0;
            foreach (var item in popQuery)
            {
                xyz += item.Pop2021.Value;
            }
            myList[1] = xyz.ToString();*/
            return myList;
        }

        /*// GET api/<FirstController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/
    }

    public class CarData
    {
        public int? NumVehicles { get; set; }
        public int? PopNum { get; set; }
        public CarData(int carID, int popNum)
        {
            PopNum = popNum;
            NumVehicles = carID;
        }
    }

}
