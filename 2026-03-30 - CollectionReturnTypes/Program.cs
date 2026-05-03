using v2;

var repo = new Repository();
var processor = new SpyProcessor();
// Get the spies 
var spies = repo.GetSpies();
// process spies
processor.ProcessSpies(spies);