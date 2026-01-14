using gradeManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace gradeManagement.Services;

public class CalculadoraEscolar
{
    // Calcula a media da turma em cada uma das 5 disciplinas
    public double[] CalcularMediasPorDisciplina(List<Aluno> alunos)
    {
        double[] medias = new double[5];
        if (alunos.Count == 0) return medias;

        for (int i = 0; i < 5; i++)
        {
            // LINQ: Pega a nota de índice 'i' de todos os alunos e tira a média
            // i.e, tira a media de todos os alunos em cada disciplina
            medias[i] = alunos.Average(a => a.Notas[i]);
        }
        return medias;
    }

    // Filtra alunos com média individual acima da média geral da turma
    public List<string> ObterAlunosAcimaDaMedia(List<Aluno> alunos)
    {
        if (alunos.Count == 0) return new List<string>();

        // Calcula a média das médias de todos os alunos
        double mediaGeralTurma = alunos.Average(a => a.MediaNotas);

        return alunos
            .Where(a => a.MediaNotas > mediaGeralTurma)
            .Select(a => a.Nome)
            .ToList();
    }

    // Filtra alunos com frequência abaixo de 75%
    public List<string> ObterAlunosBaixaFrequencia(List<Aluno> alunos)
    {
        return alunos
            .Where(a => a.Frequencia < 75)
            .Select(a => a.Nome)
            .ToList();
    }
}