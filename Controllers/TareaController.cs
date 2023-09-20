using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.controllers;
[Route("[controller]")]
public class TareaController : ControllerBase
{
    protected readonly ITareaService tareaService;
    public TareaController(ITareaService tarea){
        tareaService = tarea;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(tareaService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody]Tarea tarea){
        tareaService.Save(tarea);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Tarea tarea, Guid id){
        tareaService.Update(id,tarea);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){
        tareaService.Delete(id);
        return Ok();
    }
}
