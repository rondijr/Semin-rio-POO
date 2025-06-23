namespace GerenciadorTarefas.Persistencia
{
    using GerenciadorTarefas.Dominio;
    using System.Collections.Generic;
    using System.Linq;

    public class TarefaRepository
    {
        private readonly List<Tarefa> _tarefas = new();

        public void Salvar(Tarefa tarefa)
        {
            _tarefas.Add(tarefa);
        }

        public List<Tarefa> ListarTodas()
        {
            return _tarefas;
        }

        public Tarefa BuscarPorDescricao(string descricao)
        {
            return _tarefas.FirstOrDefault(t => t.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }

        public void Excluir(Tarefa tarefa)
        {
            _tarefas.Remove(tarefa);
        }
    }
}
