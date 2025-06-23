namespace GerenciadorTarefas.Aplicacao
{
    using GerenciadorTarefas.Dominio;
    using GerenciadorTarefas.Persistencia;
    using System.Collections.Generic;

    public class TarefaService
    {
        private readonly TarefaRepository _repository;

        public TarefaService(TarefaRepository repository)
        {
            _repository = repository;
        }

        public void CriarTarefa(string descricao)
        {
            var tarefa = new Tarefa(descricao);
            _repository.Salvar(tarefa);
        }

        public List<Tarefa> ListarTarefas()
        {
            return _repository.ListarTodas();
        }

        public void ExcluirTarefa(string descricao)
        {
            var tarefa = _repository.BuscarPorDescricao(descricao);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada!");

            _repository.Excluir(tarefa);
        }

        public void EditarTarefa(string descricaoAntiga, string novaDescricao)
        {
            var tarefa = _repository.BuscarPorDescricao(descricaoAntiga);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada!");

            tarefa.EditarDescricao(novaDescricao);
        }

        public void ConcluirTarefa(string descricao)
        {
            var tarefa = _repository.BuscarPorDescricao(descricao);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada!");

            tarefa.Concluir();
        }
    }
}
