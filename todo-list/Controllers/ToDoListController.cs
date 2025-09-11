using Microsoft.AspNetCore.Mvc;
using todo_list.Models;
using todo_list.Services;
using todo_list.DTOs;

namespace todo_list.Controllers
{
    public class ToDoListController : BaseController
    {
        [HttpGet("tarefas")]
        public IActionResult ListarTarefas([FromQuery] string? prioridade, [FromQuery] string? status)
        {
            var plataforma = Request.Headers["X-Plataforma"].ToString().ToLower();

            var tarefas = ToDoListService.Listar(prioridade, status); 

            if (tarefas == null || !tarefas.Any())
                return NotFound();

            if (plataforma == "mobile")
            {
                var tarefasMobile = tarefas.Select(t => new TarefaMobileDto
                {
                    Descricao = t.Descricao,
                    Status = t.Status
                });

                return Ok(tarefasMobile);
            }

            return Ok(tarefas);
        }

        [HttpGet("tarefa/{id}")]
        public IActionResult ListarTarefaPorId(int id)
        {
            var tarefa = ToDoListService.ListarPorId(id);

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult CriarTarefa([FromBody] ToDoListModel novaTarefa)
        {
            var tarefa = ToDoListService.CriarTarefa(novaTarefa);
            return CreatedAtAction(nameof(ListarTarefaPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, [FromBody] AtualizarTarefaDto dto)
        {
            var tarefaAtualizada = ToDoListService.Atualizar(id, dto.Descricao, dto.Prioridade);
            if (!tarefaAtualizada) return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/concluir")]
        public IActionResult ConcluirTarefa(int id)
        {
            var tarefaConcluida = ToDoListService.Concluir(id);
            if (!tarefaConcluida) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}/deletar")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefaDeletada = ToDoListService.Deletar(id);
            if (!tarefaDeletada) return NotFound();

            return NoContent();
        }
    }
}
