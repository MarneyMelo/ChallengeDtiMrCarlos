using gradeManagement.Models;
using gradeManagement.Services;
using System;
using System.Globalization; //Para robustez da leitura dos dados
using System.Text;

List<Aluno> listaAlunos = new List<Aluno>();
CalculadoraEscolar calculadora = new CalculadoraEscolar();

Console.WriteLine("Insira os dados dos alunos conforme modelo: \n " +
    "<nome_aluno> <nota1> <nota2> <nota3> <nota4> <nota5> <frequencia%> \n" +
    "Ou insira -1 para finalizar:");

while (true)
{
    string entrada = Console.ReadLine();

    // Condição de parada: se o usuário digitar -1, encerra o loop, sinalizando o fim da leitura.
    if (entrada == "-1") break;

    try
    {
        // Quebra strings por espaços
        string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Cria o objeto Aluno e preenche os dados
        Aluno aluno = new Aluno();
        aluno.Nome = partes[0];

        // Converte as 5 notas lidas como string para double
        for (int i = 0; i < 5; i++)
        {
            aluno.Notas[i] = double.Parse(partes[i + 1], CultureInfo.InvariantCulture);
        }

        //Remove o '%' e converte a frequência para double
        string freqLimpa = partes[6].Replace("%", "");
        aluno.Frequencia = double.Parse(freqLimpa, CultureInfo.InvariantCulture);

        listaAlunos.Add(aluno);
    }
    catch (Exception)
    {
        Console.WriteLine("Erro na leitura dos dados. Tente novamente ou digite -1 para sair.");
    }
}
if (listaAlunos.Any()) // if (listaAlunos.Count > 0) tmb funciona
{
    // Console.WriteLine("Nome, Média e Frequência por aluno");
    foreach (var aluno in listaAlunos)
    {
        Console.WriteLine($"{aluno.Nome} {aluno.MediaNotas:F0} {aluno.Frequencia}%");
    }
    //Console.WriteLine("Média da turma em cada disciplina:");
    var mediasTurma = calculadora.CalcularMediasPorDisciplina(listaAlunos);
    Console.WriteLine(string.Join(" ", mediasTurma.Select(m => m.ToString("F0"))));

    //Console.WriteLine("Alunos Acima da Média da turma:");
    var acimaMedia = calculadora.ObterAlunosAcimaDaMedia(listaAlunos);
    Console.WriteLine(acimaMedia.Any() ? string.Join(", ", acimaMedia) : "");

    // Console.WriteLine("Alunos com frequência abaixo de 75%:");
    var baixaFreq = calculadora.ObterAlunosBaixaFrequencia(listaAlunos);
    Console.WriteLine(baixaFreq.Any() ? string.Join(", ", baixaFreq) : "");
}
