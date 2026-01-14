using System;
using System.Linq;

namespace gradeManagement.Models;

public class Aluno
{
    public string Nome { get; set; } = string.Empty;
    public double[] Notas { get; set; } = new double[5];
    public double Frequencia { get; set; }
    
    // Robustez para previnir erros de calculo causados pela entrada.
    // Uso do Linq para calcular este valor.
    public double MediaNotas => Notas.Length > 0 ? Notas.Average() : 0;
}
