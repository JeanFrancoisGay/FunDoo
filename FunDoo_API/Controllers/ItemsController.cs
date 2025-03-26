using FunDoo_API.DAL;
using FunDoo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunDoo_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ToDoItemModel>> Get()
        {
            try
            {
                return FunDooDBDAL.GetAllItems();
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ToDoItemModel> Get(int id)
        {
            try
            {
                return FunDooDBDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public ActionResult Post(ToDoItemModel toDoItem)
        {
            try
            {
                FunDooDBDAL.AddItem(toDoItem);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPut]
        public ActionResult Put(ToDoItemModel model)
        {
            try
            {
                FunDooDBDAL.UpdateItem(model);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                FunDooDBDAL.DeleteItem(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }   
        }
    }
}
