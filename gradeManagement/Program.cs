using System;
using System.Linq;
using System.Text;
using gradeManagement.Models;
using System.Globalization; //Para robustez da leitura dos dados

List<Aluno> listaAlunos = new List<Aluno>();

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