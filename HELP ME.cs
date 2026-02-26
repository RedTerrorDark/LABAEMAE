/// <summary>
///######################
///# Некрасов           #
///# Антон              #
///# ПИ-251             #
///######################
///</summary>

using System;
using System.Collections.Generic;

public abstract class Animal {
  public string Name { get; set; }
  public int Age { get; set; }
  public string Habitat { get; set; }
  public string DietType { get; set; }

  public Animal(string name, int age, string habitat, string dietType) {
    Name = name;
    Age = age;
    Habitat = habitat;
    DietType = dietType;
  }

  public virtual string GetInfo() {
    return $"Name: {Name}, Age: {Age}, Habitat: {Habitat}, Diet: {DietType}";
  }
}

public class Mammal : Animal {
  public bool HasFur { get; set; }

  public Mammal(string name, int age, string habitat, string dietType, bool hasFur)
    : base(name, age, habitat, dietType) {
    HasFur = hasFur;
  }

  public override string GetInfo() {
    return base.GetInfo() +
      $", Type: Mammal, Fur: {(HasFur ? "yes" : "no")}";
  }
}

public class Bird : Animal {
  public double WingSpan { get; set; }

  public Bird(string name, int age, string habitat, string dietType, double wingSpan)
    : base(name, age, habitat, dietType) {
    WingSpan = wingSpan;
  }

  public override string GetInfo() {
    return base.GetInfo() +
      $", Type: Bird, Wing Span: {WingSpan} m";
  }
}

public class Fish : Animal {
  public string WaterType { get; set; }

  public Fish(string name, int age, string habitat, string dietType, string waterType)
    : base(name, age, habitat, dietType) {
    WaterType = waterType;
  }

  public override string GetInfo() {
    return base.GetInfo() +
      $", Type: Fish, Water Type: {WaterType}";
  }
}

public class Reptile : Animal {
  public bool IsVenomous { get; set; }

  public Reptile(string name, int age, string habitat, string dietType, bool isVenomous)
    : base(name, age, habitat, dietType) {
    IsVenomous = isVenomous;
  }

  public override string GetInfo() {
    return base.GetInfo() +
      $", Type: Reptile, Venomous: {(IsVenomous ? "yes" : "no")}";
  }
}

public class Amphibian : Animal {
  public string SkinMoisture { get; set; }

  public Amphibian(string name, int age, string habitat, string dietType, string skinMoisture)
    : base(name, age, habitat, dietType) {
    SkinMoisture = skinMoisture;
  }

  public override string GetInfo() {
    return base.GetInfo() +
      $", Type: Amphibian, Skin Moisture: {SkinMoisture}";
  }
}

public class AnimalManager {
  private static AnimalManager _instance;

  public static AnimalManager Instance {
    get {
      if (_instance == null)
        _instance = new AnimalManager();
      return _instance;
    }
  }

  private List<Animal> animals = new List<Animal>();

  private AnimalManager() { }

  public void AddAnimal(Animal animal) {
    animals.Add(animal);
  }

  public void ShowAllAnimals() {
    if (animals.Count == 0) {
      Console.WriteLine("But, no one came.");
      return;
    }

    for (int index = 0; index < animals.Count; ++index) {
      Console.WriteLine($"{index + 1}. {animals[index].GetInfo()}");
    }
  }

  public void Menu() {
    while (true) {
      Console.WriteLine("\n1 - show me animals.");
      Console.WriteLine("2 - add animal");
      Console.WriteLine("0 - nah. bye.");

      string choice = Console.ReadLine();

      switch (choice) {
        case "1":
          ShowAllAnimals();
          break;

        case "2":
          CreateAnimal();
          break;

        case "0":
          return;

        default:
          Console.WriteLine("no.");
          break;
      }
    }
  }

  private void CreateAnimal() {
    Console.WriteLine("Type:");
    Console.WriteLine("1 - Mammal");
    Console.WriteLine("2 - Bird");
    Console.WriteLine("3 - Fish");
    Console.WriteLine("4 - Reptile");
    Console.WriteLine("5 - Amphibian");

    string type = Console.ReadLine();

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Age: ");
    int age = int.Parse(Console.ReadLine());

    Console.Write("Habitat: ");
    string habitat = Console.ReadLine();

    Console.Write("Diet: ");
    string diet = Console.ReadLine();

    switch (type) {
      case "1":
        Console.Write("Has Fur? (true/false): ");
        bool fur = bool.Parse(Console.ReadLine());
        AddAnimal(new Mammal(name, age, habitat, diet, fur));
        break;

      case "2":
        Console.Write("Wing Span: ");
        double wing = double.Parse(Console.ReadLine());
        AddAnimal(new Bird(name, age, habitat, diet, wing));
        break;

      case "3":
        Console.Write("Water type: ");
        string water = Console.ReadLine();
        AddAnimal(new Fish(name, age, habitat, diet, water));
        break;

      case "4":
        Console.Write("Venomous? (true/false): ");
        bool venom = bool.Parse(Console.ReadLine());
        AddAnimal(new Reptile(name, age, habitat, diet, venom));
        break;

      case "5":
        Console.Write("Skin color: ");
        string moisture = Console.ReadLine();
        AddAnimal(new Amphibian(name, age, habitat, diet, moisture));
        break;

      default:
        Console.WriteLine("nah.");
        break;
    }
  }