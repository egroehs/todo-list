using todo_list.Models;

namespace todo_list.DTOs
{
        public class AtualizarTarefaDto
        {
            public string Descricao { get; set; }
            public PrioridadeModel Prioridade { get; set; }
        }
}
