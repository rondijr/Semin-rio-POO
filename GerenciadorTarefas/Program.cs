using GerenciadorTarefas.Aplicacao;
using GerenciadorTarefas.Dominio;
using GerenciadorTarefas.Persistencia;

var repository = new TarefaRepository();
var service = new TarefaService(repository);

while (true)
{
    Console.WriteLine("\n=== Gerenciador de Tarefas ===");
    Console.WriteLine("1. Criar nova tarefa");
    Console.WriteLine("2. Listar tarefas");
    Console.WriteLine("3. Excluir tarefa");
    Console.WriteLine("4. Editar tarefa");
    Console.WriteLine("5. Marcar como concluída");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");
    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Console.Write("Digite a descrição da tarefa: ");
                var descricao = Console.ReadLine();
                service.CriarTarefa(descricao);
                Console.WriteLine("Tarefa criada com sucesso!");
                break;
            case "2":
                Console.WriteLine("\n=== Tarefas ===");
                foreach (var tarefa in service.ListarTarefas())
                {
                    Console.WriteLine($"- {tarefa.Descricao} | Concluída: {tarefa.Concluida}");
                }
                break;
            case "3":
                Console.Write("Digite a descrição da tarefa para excluir: ");
                var tarefaExcluir = Console.ReadLine();
                service.ExcluirTarefa(tarefaExcluir);
                Console.WriteLine("Tarefa excluída com sucesso!");
                break;
            case "4":
                Console.Write("Digite a descrição atual da tarefa: ");
                var descAtual = Console.ReadLine();
                Console.Write("Digite a nova descrição: ");
                var novaDesc = Console.ReadLine();
                service.EditarTarefa(descAtual, novaDesc);
                Console.WriteLine("Tarefa editada com sucesso!");
                break;
            case "5":
                Console.Write("Digite a descrição da tarefa a ser concluída: ");
                var descConcluir = Console.ReadLine();
                service.ConcluirTarefa(descConcluir);
                Console.WriteLine("Tarefa marcada como concluída!");
                break;
            case "6":
                Console.WriteLine("Encerrando...");
                return;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}
