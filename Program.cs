// See https://aka.ms/new-console-template for more information
string logo = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
";

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("AC/DC", new List<int> { 10, 9, 8, 7, 6 });
bandasRegistradas.Add("Aerosmith", new List<int> { 5, 2, 7, 7, 9 });
bandasRegistradas.Add("Black Sabbath", new List<int> { });

void ExibirLogo()
{
    Console.WriteLine(logo);
}

void ExibirOpcoesMenu()
{
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Avaliar");
    Console.WriteLine("4 - Média");
    Console.WriteLine("5 - Sair");

    Console.WriteLine("Digite uma opção: ");
    string opcao = Console.ReadLine()!;
    if (int.TryParse(opcao, out int opcaoNumero))
    {
        switch (opcaoNumero)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                ListarBanda();
                break;
            case 3:
                AvaliarBanda();
                break;
            case 4:
                ExibirMedia();
                break;
            case 5:
                Console.WriteLine("Até a próxima!");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
    else
    {
        Console.WriteLine("Por favor, digite um número válido.");
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Cadastro de Bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"A banda {nomeBanda} foi cadastrada com sucesso!");
    Thread.Sleep(2200);
    Console.Clear();
    ExibirLogo();
    ExibirOpcoesMenu();
}

void ListarBanda()
{
    Console.Clear();
    ExibirTitulo("Lista de Bandas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
    ExibirOpcoesMenu();
}

void ExibirTitulo(string titulo)
{
    int qntdAsteriscos = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qntdAsteriscos, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulo("Avaliar Banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.WriteLine($"Digite a nota para a banda {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota);

        if (nota < 0 || nota > 10)
        {
            Console.WriteLine("Nota inválida, digite uma nota entre 0 e 10");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
            ExibirLogo();
            ExibirOpcoesMenu();
        }
        Console.WriteLine($"A banda {nomeBanda} foi avaliada com sucesso!");
        Thread.Sleep(2200);
        Console.Clear();
        ExibirLogo();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine("\nBanda não encontrada");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

void ExibirMedia()
{
    Console.Clear();
    ExibirTitulo("Média de Avaliação");
    Console.WriteLine("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        if (bandasRegistradas[nomeBanda].Count == 0)
        {
            Console.WriteLine("A banda ainda não foi avaliada");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
            ExibirLogo();
            ExibirOpcoesMenu();
        }
        else
        {
            List<int> notasBanda = bandasRegistradas[nomeBanda];
            Console.WriteLine($"\nA média da banda {nomeBanda} é {notasBanda.Average()}");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
            ExibirLogo();
            ExibirOpcoesMenu();
        }
    }
    else
    {
        Console.WriteLine("\nBanda não encontrada");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirLogo();
        ExibirOpcoesMenu();
    }
}

ExibirLogo();
ExibirOpcoesMenu();
