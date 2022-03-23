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
    public class BidController : ControllerBase
    {
        private readonly IBidBLL _bidBLL;
        public BidController(IBidBLL bidBLL)
        {
            _bidBLL = bidBLL;
        }
        // GET: api/<BidController>
        [HttpGet]
        public List<BidDTO> Get()
        {
            return _bidBLL.GetAllBid();
        }

        // GET api/<BidController>/5
        [HttpGet("{id}")]
        public BidDTO Get(int id)
        {
            return _bidBLL.GetById(id);
        }

        // POST api/<BidController>
        [HttpPost]
        public void Post([FromBody] BidDTO bid)
        {
            _bidBLL.AddBid(bid);
        }

        // PUT api/<BidController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BidDTO bid)
        {
            _bidBLL.UpdateBid(id,bid);
        }

        // DELETE api/<BidController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bidBLL.DeleteBid(id);  
        }
    }
}
