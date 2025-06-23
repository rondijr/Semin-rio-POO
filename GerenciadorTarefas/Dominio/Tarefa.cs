namespace GerenciadorTarefas.Dominio
{
    public class Tarefa
    {
        public string Descricao { get; private set; }
        public bool Concluida { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Tarefa(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("Descrição obrigatória!");

            Descricao = descricao;
            Concluida = false;
            DataCriacao = DateTime.Now;
        }

        public void Concluir()
        {
            Concluida = true;
        }

        public void EditarDescricao(string novaDescricao)
        {
            if (string.IsNullOrEmpty(novaDescricao))
                throw new Exception("Nova descrição não pode ser vazia.");

            Descricao = novaDescricao;
        }
    }
}
