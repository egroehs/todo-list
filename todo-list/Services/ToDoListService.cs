using todo_list.Models;

namespace todo_list.Services
{
    public static class ToDoListService
    {
        private static List<ToDoListModel> Tarefas = new List<ToDoListModel>();
        private static int nextId = 1;

        public static IEnumerable<ToDoListModel> Listar(string? prioridade, string? status)
        {
            var query = Tarefas.AsQueryable();

            if (!string.IsNullOrEmpty(prioridade))
                query = query.Where(t => t.Prioridade.ToString().Equals(prioridade, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(status))
                query = query.Where(t => t.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase));


            return query.ToList();
        }

        public static ToDoListModel? ListarPorId(int id)
        {
            return Tarefas.FirstOrDefault(t => t.Id == id);
        }


        public static ToDoListModel CriarTarefa(ToDoListModel tarefa)
        {
            tarefa.Id = nextId++;
            Tarefas.Add(tarefa);
            return tarefa;
        }

        public static bool Atualizar(int id, string descricao, PrioridadeModel prioridade)
        {
            var tarefa = ListarPorId(id);
            if (tarefa == null) return false;

            tarefa.Descricao = descricao;
            tarefa.Prioridade = prioridade;
            return true;
        }

        public static bool Concluir(int id)
        {
            var tarefa = ListarPorId(id);
            if (tarefa == null) return false;

            tarefa.Status = StatusTarefaModel.Concluida;
            return true;
        }

        public static bool Deletar(int id)
        {
            var tarefa = ListarPorId(id);
            if (tarefa == null) return false;

            Tarefas.Remove(tarefa);
            return true;
        }
    }
}
