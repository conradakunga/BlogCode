var marks = new int[] { 30, 40, 70, 90, 105 };

foreach (var mark in marks)
{
    Console.WriteLine($"A mark of {mark} is Grade {GradeByIfV1(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeByIfV2(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV1(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV2(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV3(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV4(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV5(mark)}");
    Console.WriteLine($"A mark of {mark} is Grade {GradeBySwitchV6(mark)}");
}

char GradeByIfV1(int grade)
{
    if (grade < 40)
        return 'F';
    else if (grade >= 40 && grade < 50)
        return 'E';
    else if (grade >= 50 && grade < 60)
        return 'D';
    else if (grade >= 60 && grade < 70)
        return 'C';
    else if (grade >= 70 && grade < 80)
        return 'B';
    else if (grade >= 80 && grade <= 100)
        return 'A';
    return 'X';
}
char GradeByIfV2(int grade)
{
    if (grade > 100)
        return 'X';
    else if (grade >= 80)
        return 'A';
    else if (grade >= 70)
        return 'B';
    else if (grade >= 60)
        return 'C';
    else if (grade >= 50)
        return 'D';
    else if (grade >= 40)
        return 'E';
    else
        return 'F';
}

char GradeBySwitchV1(int grade)
{
    switch (grade)
    {
        case int x when x < 40:
            return 'F';
        case int x when x >= 40 && x < 50:
            return 'E';
        case int x when x >= 50 && x < 60:
            return 'D';
        case int x when x >= 60 && x < 70:
            return 'C';
        case int x when x >= 70 && x < 80:
            return 'B';
        case int x when x >= 80 && x <= 100:
            return 'A';
        default:
            return 'X';

    }
}
char GradeBySwitchV2(int grade)
{
    switch (grade)
    {
        case int x when x < 40:
            return 'F';
        case int x when x is >= 40 and < 50:
            return 'E';
        case int x when x is >= 50 and < 60:
            return 'D';
        case int x when x is >= 60 and < 70:
            return 'C';
        case int x when x is >= 70 and < 80:
            return 'B';
        case int x when x is >= 80 and <= 100:
            return 'A';
        default:
            return 'X';

    }
}
char GradeBySwitchV3(int grade) =>
     grade switch
     {
         int x when x < 40 => 'F',
         int x when x is >= 40 and < 50 => 'E',
         int x when x is >= 50 and < 60 => 'D',
         int x when x is >= 60 and < 70 => 'C',
         int x when x is >= 70 and < 80 => 'B',
         int x when x is >= 80 and <= 100 => 'A',
         _ => 'X'
     };

char GradeBySwitchV4(int grade) =>
    grade switch
    {
        int x when x > 100 => 'X',
        int x when x is >= 80 => 'A',
        int x when x is >= 70 => 'B',
        int x when x is >= 60 => 'C',
        int x when x is >= 50 => 'D',
        int x when x is >= 40 => 'E',
        _ => 'F'
    };

char GradeBySwitchV5(int grade) =>
     grade switch
     {
         < 40 => 'F',
         >= 40 and < 50 => 'E',
         >= 50 and < 60 => 'D',
         >= 60 and < 70 => 'C',
         >= 70 and < 80 => 'B',
         >= 80 and <= 100 => 'A',
         _ => 'X'
     };

char GradeBySwitchV6(int grade) =>
    grade switch
    {
        > 100 => 'X',
        >= 80 => 'A',
        >= 70 => 'B',
        >= 60 => 'C',
        >= 50 => 'D',
        >= 40 => 'E',
        _ => 'F'
    };