using Microsoft.AspNetCore.Mvc;
using FossilCarsApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace FossilCarsApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FossilCarsController : Controller
    {
        private static List<FossilCar> Cars = new List<FossilCar> {
        new FossilCar(1, "Citroën C3", 2268, -27),
        new FossilCar(2, "Peugeot 208", 2107, -24),
        new FossilCar(3, "Kia Ceed/Xceed", 1750, -1),
        new FossilCar(4, "Ford Kuga", 1619, -53),
        new FossilCar(5, "Toyota Yaris", 1515, -45),
        new FossilCar(6, "VW T-Roc", 1435, -7),
        new FossilCar(7, "Mercedes-Benz C-klasse", 1361, -9),
        new FossilCar(8, "Hyundai i10", 1300, -26),
        new FossilCar(9, "Nissan Qashqai", 1246, -42),
        new FossilCar(10, "Peugeot 2008", 1067, -29),
        new FossilCar(11, "Hyundai i20", 1043, 3),
        new FossilCar(12, "VW Polo", 1031, -30),
        new FossilCar(13, "Peugeot 3008", 1028, -22),
        new FossilCar(14, "VW Taigo", 978, 100),
        new FossilCar(15, "BMW 3-serie", 960, -50),
        new FossilCar(16, "Opel Corsa", 944, -53),
        new FossilCar(17, "Toyota Corolla", 935, -4),
        new FossilCar(18, "Cupra Formentor", 868, 145),
        new FossilCar(19, "Volvo XC40", 842, 1),
        new FossilCar(20, "VW T-Cross", 831, -37)
        };

        [HttpGet("GetData")]
        public async Task<ActionResult<IEnumerable<FossilCar>>> GetData()
        {
            try
            {
                return Ok(Cars);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("NewCar")]
        public async Task<ActionResult> AddData(FossilCarDTO request)
        {
            try
            {
                // rank 2, index 1
                Cars.Insert(request.rank - 1, new FossilCar(request.rank, request.model, request.quantity, request.changeQuantityProcent));

                // update rank +1 from index 2
                for (int i = request.rank; i < Cars.Count; i++)
                {
                    Cars[i].rank++;
                }

                string okMessage = "Car added";
                return Ok(new { okMessage });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("EditCar")]
        public async Task<ActionResult> EditData(FossilCarDTO request)
        {
            try
            {
                Cars[request.rank - 1].model = request.model;
                Cars[request.rank - 1].quantity = request.quantity;
                Cars[request.rank - 1].changeQuantityProcent = request.changeQuantityProcent;

                string okMessage = "Car changed";
                return Ok(new { okMessage });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteCar")]
        public async Task<ActionResult> DeleteData(DeleteDTO request)
        {
            try
            {
                Cars.RemoveAt(request.index - 1);
                for (int i = request.index - 1; i < Cars.Count; i++)
                {
                    Cars[i].rank--;
                }
                string okMessage = "Car deleted";
                return Ok(new { okMessage });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
