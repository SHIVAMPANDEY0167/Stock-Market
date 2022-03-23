using Microsoft.AspNetCore.Mvc;
using StockMarket.BLL.IService;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeBLL _tradeBLL;
        public TradeController(ITradeBLL tradeBLL)
        {
            _tradeBLL = tradeBLL;
        }
        // GET: api/<TradeController>
        [HttpGet]
        public List<TradeDTO> Get()
        {
            return _tradeBLL.GetAllTrade();
        }

        // GET api/<TradeController>/5
        [HttpGet("{id}")]
        public TradeDTO Get(int id)
        {
            return _tradeBLL.GetById(id);
        }

        // POST api/<TradeController>
        [HttpPost]
        public void Post([FromBody] TradeDTO trade)
        {
            _tradeBLL.AddTrade(trade);
        }

        // PUT api/<TradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TradeDTO trade)
        {
            _tradeBLL.UpdateTrade(id,trade);
        }

        // DELETE api/<TradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tradeBLL.DeleteTrade(id);
        }
    }
}
