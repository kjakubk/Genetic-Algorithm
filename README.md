**Sprawozdanie - laboratorium 3 **
 
**Autor:** Jakub Kępczyński 
**Grupa:** ININ4_PR 
**Data:** 28.11.2020r. 
Sprawozdanie to dotyczyć będzie zastosowania algorytmu genetycznego do znalezienia wartości wejściowych funkcji odległości euklidesowej: X1, Y1 i X2, Y2, które dają największą odległość między punktami znajdującymi się na zdefiniowanej przez nas powierzchni. Zadanie z punktu widzenia człowieka może wydawać się banalne, ze względu na to, iż wiemy, że największa odległość na polu prostokąta wyznacza się łącząc ze sobą przekątne figury. Komputer jednak takiej wiedzy nie posiada, przez co do najlepszego wyniku musi dojść poprzez wyliczanie wartości dla funkcji fitness.  
 
**Przykładowy schemat blokowy algorytmu genetycznego:** 

![1](https://user-images.githubusercontent.com/61251819/108840624-e9bf1f80-75d6-11eb-95dd-087afb81b97a.png)

**Pseudokod algorytmu:**  
```
START 
Generowanie populacji początkowej 
Obliczanie funkcji fitness 
 POWTÓRZ 
Wybór 
Krzyżowanie 
Mutacja 
Obliczanie funkcji fitness 
 Przestań gdy funkcja fitness osiągnie najkorzystniejszy wynik 
STOP 
```
 
**Zastosowanie algorytmu:**  
Algorytmy genetyczne znajdują zastosowanie w rozwiązywaniu wielu problemów nieliniowych, źle uwarunkowanych lub trudnych do sformułowania matematycznego. Są one niezwykle wydajne, co w połączniu z łatwą implementacją pozwala na rozwiązanie takich problemów, jak: konstrukcje strategii inwestycyjnych, modelowania finansowe lub harmonogramowanie pracy. Zastosowaniem AG w lotnictwie jest wielokryterialna optymalizacja konstrukcji skrzydeł samolotów poprzez m.in. minimalizację oporu aerodynamicznego. AG pozwala również na optymalizację działania maszyn w przemyśle chemicznym, dzięki jego zastosowaniu można modyfikować struktury parametrów w reakcjach chemicznych by znaleźć najbardziej korzystne warunki do ich przeprowadzania.  
**Kod źródłowy:**
Znajduje się w repozytorium
**Trzy przeprowadzone eksperymenty AG:**  
**Eksperyment 1:**  
Wartości wejściowe:
```
double maxWidth = 9999; double maxHeight = 8765; 
new double[] { -1000, -1000, -1000, -1000 } 
new double[] { maxWidth, maxHeight, maxWidth, maxHeight }, 
new int[] { 64, 64, 64, 64},
new int[] { 0, 0, 0, 0 }); 
var population = new Population(10, 50, chromosome);
var crossover = new UniformCrossover(0.5f); 
var termination = new FitnessStagnationTermination(1000); 
```

![2](https://user-images.githubusercontent.com/61251819/108840969-5afed280-75d7-11eb-93ea-abac4a91cf90.jpg)
![3](https://user-images.githubusercontent.com/61251819/108840970-5afed280-75d7-11eb-880e-952c81ae3c17.jpg)
![4](https://user-images.githubusercontent.com/61251819/108840966-59cda580-75d7-11eb-96a1-cfe9366479bb.jpg)
