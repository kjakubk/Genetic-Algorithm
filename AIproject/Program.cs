using System;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;




//install-package GeneticSharp tej komendy należy użyć w celu instalacji 
//pakietu GenetickSharp.



namespace FunctionOptimizationWithGeneticSharp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//Inicjujemy zmienne które będą granicznymi wartościami dla naszych punktów x1,x2,y1,y2.
			double maxWidth = 9999;

			double maxHeight = 8765;

			//Tworzymy strukture pojedyńczego chormosomu
			var chromosome = new FloatingPointChromosome(
				new double[] { -1000, -1000, -1000, -1000 },//Warości początkowe dla x1,x2,y1,y2
				new double[] { maxWidth, maxHeight, maxWidth, maxHeight },//Wartości maksymalne dla x1,x2,y1,y2
				new int[] { 64, 64, 64, 64 },//Liczba bitów użytych do uzyskania wyniku
				new int[] { 0, 0, 0, 0 });

			var population = new Population(10, 50, chromosome);//Określamy ilość chromosomów
																//(x,y,chromosome) x=minimalna liczba chromosomów, y=maksymalna liczba chormosomów
																//chromosome=odniesienie się do wyżej utworzonego chromosomu



			var fitness = new FuncFitness((c) =>//Implementacja funkcji fitness z chormosomem w zmiennej "c"
			{
				var fc = c as FloatingPointChromosome;//Rzutowanie powyższego chormosomu na FloatingPointChromosme

				var values = fc.ToFloatingPoints();  //konwertowanie FloatingPointChromosome do jego fenotypu 

				var x1 = values[0];                  //konwertowanie FloatingPointChromosome do jego fenotypu x1

				var y1 = values[1];                  //konwertowanie FloatingPointChromosome do jego fenotypu y1

				var x2 = values[2];                  //konwertowanie FloatingPointChromosome do jego fenotypu x2

				var y2 = values[3];                  //konwertowanie FloatingPointChromosome do jego fenotypu y2

				return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));//Przekazanie wartości do naszej funkcji 
			});

			var selection = new EliteSelection(); //Selekcja odpowiada za wybór chormosomów o największym dystanisie

			var crossover = new UniformCrossover(0.5f); //Ta sekcja pozwala na krzyżowanie się chromosomów aby generować nowe rozwiązania dla kolejnej generacji
														//Potomstwo przy parametrze 0.5 posiada mniej więcej połowę genów rodziców.

			var mutation = new FlipBitMutation();//Mutacja uniemożliwa "utknięcie" naszego algorytmu w optimum lokalnym, mutacja Flip-Bit lodowo wybiera
												 //gen i odwraca jego wartości, gen o wartości 1 stanie się genem o wartości 0

			var termination = new FitnessStagnationTermination(1000);//Warunek zakończenia działania algorytmu 
																	 //Jeżeli nasz program wygeneruje w ciągu 1000 pokoleń taką samą wartość funkcji fitness to działanie programu zostanie zakończone.

			//Poniższy fragment odpowiada ze wywołanie zdefiniowanych przez nas wartości komenda ga.Start() spodowuje rozpoczęcie działania funkcji
			var ga = new GeneticAlgorithm(
				population,
				fitness,
				selection,
				crossover,
				mutation);

			ga.Termination = termination;
			//Cały poniższy blok kodu podowuje wyświetlenie kolejnych kroków wyliczania AG na ekranie konsoli
			Console.WriteLine("Generation: (x1, y1), (x2, y2) = distance");

			var latestFitness = 0.0;

			ga.GenerationRan += (sender, e) =>
			{
				var bestChromosome = ga.BestChromosome as FloatingPointChromosome;
				var bestFitness = bestChromosome.Fitness.Value;

				if (bestFitness != latestFitness)
				{
					latestFitness = bestFitness;
					var phenotype = bestChromosome.ToFloatingPoints();

					Console.WriteLine(
						"Generation {0,2}: (X1={1},Y1={2}),(X2={3},Y2={4}) = Największy dystans między punktami {5}",
						ga.GenerationsNumber,
						phenotype[0],
						phenotype[1],
						phenotype[2],
						phenotype[3],
						bestFitness
					);
				}
			};

			ga.Start();

			Console.ReadKey();
		}
	}
}
