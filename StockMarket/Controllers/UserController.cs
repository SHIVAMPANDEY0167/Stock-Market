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
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<UserDTO> Get()
        {
            return _userBLL.GetAllUser();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return _userBLL.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public string Post([FromBody] UserDTO user)
        {
            return _userBLL.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO user)
        {
            _userBLL.UpdateUser(id,user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userBLL.DeleteUser(id);
        }
    }
}
