Imports System

Module Program
    Sub Main(args As String())
       Dim livingThings As New List(Of LivingThing)
	livingThings.AddRange(New LivingThing() {
		New LivingThing() With {.Kingdom = "Animal", .Name = "Dog", .Legs = 4},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Cat", .Legs = 4},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Horse", .Legs = 4},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Millipede", .Legs = 3_000},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Centi[ide", .Legs = 3_000},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Octopus", .Legs = 8},
		New LivingThing() With {.Kingdom = "Animal", .Name = "Squid", .Legs = 8},
		New LivingThing() With {.Kingdom = "Plant", .Name = "Rose", .Legs = 0},
		New LivingThing() With {.Kingdom = "Plant", .Name = "Cabbage", .Legs = 0},
		New LivingThing() With {.Kingdom = "Plant", .Name = "Kale", .Legs = 0}
		})

	Dim distinctElements = livingThings.DistinctBy(Function(t) New With {t.Kingdom, t.Legs})
	For Each element In distinctElements
		Console.WriteLine($"Kingdom: {element.Kingdom}; Legs: {element.Legs}")
	Next

	Console.WriteLine()

	distinctElements = livingThings.DistinctBy(Function(t) New With {Key t.Kingdom, Key t.Legs})
	For Each element In distinctElements
		Console.WriteLine($"Kingdom: {element.Kingdom}; Legs: {element.Legs}")
	Next
    End Sub
End Module

Public Class LivingThing
	Public Property Kingdom As String
	Public Property Name As String
	Public Property Legs As Int32
End Class
