namespace todo_list.Models
{
    public class ToDoListModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataAbertura { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public PrioridadeModel Prioridade { get; set; }
        public StatusTarefaModel Status { get; set; } = StatusTarefaModel.Pendente;
    }
}
