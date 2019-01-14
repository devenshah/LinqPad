<Query Kind="Program">
  <NuGetReference>System.Collections.Immutable</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
    var dinosaurs = new List<string>();
    dinosaurs.Add("Tyrannosaurus");
    dinosaurs.Add("Amargasaurus");
    dinosaurs.Add("Deinonychus");
    dinosaurs.Add("Compsognathus");
    //Create Readonly list
    var readOnlyDinosaurs = new ReadOnlyCollection<string>(dinosaurs);
    //Create Immutable list
    var immutableList = ImmutableList.CreateRange(dinosaurs);
    //changing under lying collection
    dinosaurs.Add("Megathesaurus");
    
    //Readonly is updated
    readOnlyDinosaurs.Dump();   
        
    //Immutable is unchanged
    immutableList.Dump();
}

// Define other methods and classes here
