List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!

//1. Use LINQ to find the first eruption that is in Chile and print the result.
// Eruption eruptionChile = eruptions.First(eruption => eruption.Location == "Chile");
// Console.WriteLine(eruptionChile.ToString());

//2. Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
// Eruption eruptionHawai = eruptions.FirstOrDefault(eruption => eruption.Location == "Hawaiian Is");
// if (eruptionHawai != null)
// {
//     Console.WriteLine(eruptionHawai.ToString());
// }
// else
// {
//     Console.WriteLine("No Hawaii eruption found.");
// }


//3. Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
// Eruption eruptionGreenland = eruptions.FirstOrDefault(eruption => eruption.Location == "Greenland");

// if (eruptionGreenland != null)
// {
//     Console.WriteLine(eruptionGreenland.ToString());
// }
// else
// {
//     Console.WriteLine("No Greenland eruption found.");
// }


//4. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
// Eruption eruptionAfter = eruptions.FirstOrDefault(eruption => eruption.Year > 1900 && eruption.Location == "New Zealand");

// if (eruptionAfter != null)
// {
//     Console.WriteLine($"The first eruption after 1900 in New Zealand occurred in {eruptionAfter.Year}.");
// }
// else
// {
//     Console.WriteLine("No eruption found that meets the criteria.");
// }

//5. Find all eruptions where the volcano's elevation is over 2000m and print them.
// List<Eruption> eruptionsOver2000m = eruptions.Where(eruption => eruption.ElevationInMeters > 2000).ToList();

// Eruption.PrintEach(eruptionsOver2000m, "Eruptions with elevation over 2000m:");

//6. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.

// List<Eruption> eruptionsStartingWithL = eruptions.Where(eruption => eruption.Volcano.StartsWith("L")).ToList();

// Eruption.PrintEach(eruptionsStartingWithL, "Eruptions with volcano name starting with 'L':");

// int eruptionCount = eruptionsStartingWithL.Count;
// Console.WriteLine($"Number of eruptions found: {eruptionCount}");

//7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
// int highestElevation = eruptions.Max(eruption => eruption.ElevationInMeters);

// Console.WriteLine("Highest Elevation: " + highestElevation);

//8. Use the highest elevation variable to find and print the name of the Volcano with that elevation.
// Eruption volcanoWithHighestElevation = eruptions.FirstOrDefault(eruption => eruption.ElevationInMeters == highestElevation);

// Console.WriteLine("Volcano with the highest elevation: " + volcanoWithHighestElevation?.Volcano);

//9. Print all Volcano names alphabetically.
// List<Eruption> sortedVolcanoNames = eruptions.OrderBy(eruption => eruption.Volcano).ToList();

// Eruption.PrintEach(sortedVolcanoNames, "Volcano names (alphabetically):");

//10. Print the sum of all the elevations of the volcanoes combined.

// double totalElevation = eruptions.Sum(eruption => eruption.ElevationInMeters);

// Console.WriteLine("Sum of all volcano elevations: " + totalElevation);

//11.
// bool anyEruptionsIn2000 = eruptions.Any(eruption => eruption.Year == 2000);

// Console.WriteLine("Did any volcanoes erupt in 2000? " + anyEruptionsIn2000);

//12.
// List<Eruption> stratovolcanoes = eruptions.Where(eruption => eruption.Type == "Stratovolcano").Take(3).ToList();

// Eruption.PrintEach(stratovolcanoes, "First three stratovolcanoes:");

//13. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
// List<Eruption> eruptionsBefore1000 = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano).ToList();

// Eruption.PrintEach(eruptionsBefore1000, "Eruptions before 1000 CE (alphabetically by volcano name):");

//14.
// List<string> volcanoNamesBefore1000 = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano).Select(eruption => eruption.Volcano).ToList();

// Eruption.PrintEach(volcanoNamesBefore1000, "Volcano names before 1000 CE (alphabetically):");








// Eruption.PrintEach(eruptions);


