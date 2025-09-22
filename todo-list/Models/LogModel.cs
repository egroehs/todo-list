using System;
namespace todo_list.Models
{
	public class LogModel
	{
		public DateTime DataHora { get; set; } = DateTime.Now;
		public string MetodoHttp { get; set; }
		public string Caminho { get; set; }
		public string EnderecoIp { get; set; }
		public string Status { get; set; }
		public double TempoExecucaoMs { get; set; }
	}
}

