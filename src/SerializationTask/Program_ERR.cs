﻿using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationTask
{
    class Program
    {
        private const Int32 PERSON_NUM = 10;//0;//00;
        private static string exportFile = "Persons.json";

        public static void Main(string[] args)
		{
			List<Person> personList = GeneratePersonsList(new RandomPersonBuilder(), PERSON_NUM); 
			private string exportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + exportFile;
			SerializeToJsonFile(personList, exportPath);
			ClearPersonList(personList);
			DeserializeFromJsonFile(personList, exportPath);
			DisplayStatistics(personList);
		}
    }
}



            
	public static List<Person> GeneratePersonsList(PersonBuilder personBuilder, Int32 personNum = 1)
	{
		List<Person> list = new List<Person>();
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Generating persons with " + personBuilder.GetType().Name);
		for (Int32 i = 0; i < personNum; i++)
		{
			Person person = personBuilder.Build();
			person.SequenceId = i;
			list.Add(person);
			Console.WriteLine(person.ToString());
		};
		return list;
	}

	public static void SerializeToJsonFile(List<Person> personList, string filePath)
	{
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Serializing persons to file: " + filePath);
		var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
		File.WriteAllText(filePath, JsonSerializer.Serialize<List<Person>>(personList, options));
		Console.WriteLine($"Serialized {personList.Count()} persons.");
	}

	public static void ClearPersonList(List<Person> personList)
	{
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Clearing person list...");
		personList.Clear();
	}

	public static void DeserializeFromJsonFile(List<Person> personList, string filePath)
	{
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Loading persons from file: " + filePath);
		personList = await JsonSerializer.DeserializeAsync<List<Person>>(File.OpenRead(filePath));
		Console.WriteLine("Persons loaded: " + personList.Count);
	}

	public static void DisplayStatistics(List<Person> personList)
	{
		Console.WriteLine("------------------------------------");
		Console.WriteLine("Persons count: " + personList.Count);
	}
