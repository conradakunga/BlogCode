var smiley = new Agent { Name = "George Smiley" };
var bond = new FieldAgent { Name = "James Bond" };
var evelyn = new SleeperAgent { Name = "Evelyn Salt", Station = "USA" };
var phil = new SleeperAgent { Name = "Phil Jennings", Station = "USA" };
var bourne = new FieldAgent { Name = "Jason Bourne" };
var montes = new UndercoverAgent { Name = "Anna Montes" };

// Add all agents to a collection
Agent[] agents = [smiley, bond, evelyn, phil, bourne, montes];

// Get all sleepers
var sleepers = agents.Where(x => x.GetType() == typeof(SleeperAgent))
    .ToList();

sleepers.ForEach(sleeper => Console.WriteLine(sleeper.Name));

// Get all sleepers into a list of sleeper agents
var sleeperAgents = agents.OfType<SleeperAgent>().ToList();
sleeperAgents.ForEach(sleeper => Console.WriteLine(sleeper.Name));

// Get all sleepers into a SleeperAgent List
var sleeperAgentsFiltered = agents.Where(x => x.GetType() == typeof(SleeperAgent))
    .Cast<SleeperAgent>()
    .ToList();

sleeperAgentsFiltered.ForEach(sleeper => Console.WriteLine(sleeper.Name));

var fieldAgents = agents.OfType<FieldAgent>().ToList();
fieldAgents.ForEach(field => Console.WriteLine(field.Name));