using System;
using System.Collections.Generic;

namespace ExercVotacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votacao = new Dictionary<string, int>();

            Console.Write("Informe o caminho e nome do arquivo para a leitura dos votos: ");
            string path = Console.ReadLine();
            Console.WriteLine("Realizando a leitura do arquivo..."); 
            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while (!(sr.EndOfStream))
                    {
                        string[] aux = sr.ReadLine().Split(',');
                        string name = aux[0];
                        int votos = Convert.ToInt32(aux[1]);

                        if (votacao.ContainsKey(name))
                        {
                            votacao[name] = votacao[name] + votos;
                        }
                        else
                        {
                            votacao[name] = votos;
                        }
                        
                    }
                }
                Console.WriteLine("Resultado: ");
                foreach (var candidato in votacao)
                {
                    Console.WriteLine(candidato.Key+": "+candidato.Value);
                }
            
            }
            catch (IOException ex)
            {
                Console.WriteLine("Houve um erro durante a leitura do arquivo.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve uma falha ao criar o dicionário de dados!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}