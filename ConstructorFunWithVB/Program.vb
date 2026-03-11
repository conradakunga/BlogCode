Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module

Public class Person
    Private ReadOnly FirstName as String
    Private ReadOnly Surname as String
    Private ReadOnly MiddleName as String

    Public Sub New(Firstname as String, Surname as String)
        Me.FirstName = Firstname
        Me.Surname = Surname
    End sub

    Public Sub New(Firstname as String, Surname as String, MiddleName as String)
        Me.New(Firstname, Surname)
        Me.MiddleName = MiddleName
    End sub
End class

Public class Teacher
    Inherits Person
    Private ReadOnly Subject as String

    Public Sub New(Firstname as String, Surname as String, Subject as string)
        MyBase.New(Firstname, Surname)
        Me.Subject = Subject
    End Sub

    Public Sub New(Firstname as String, Surname as String, MiddleName as string, Subject as string)
        MyBase.New(Firstname, Surname, MiddleName)
        Me.Subject = Subject
    End Sub
End class