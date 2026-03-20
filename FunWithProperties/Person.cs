namespace v1
{
    public class Person
    {
        public string FirstName;
        public string Surname;
    }
}

namespace v2
{
    public class Person
    {
        public readonly string FirstName;
        public readonly string Surname;

        public Person(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
}

namespace v3
{
    public class Person
    {
        public string FirstName;
        public string Surname;

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            FirstName = firstName;
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentNullException(nameof(surname));

            Surname = surname;
        }
    }
}

namespace v4
{
    public class Person
    {
        private string _firstName;
        private string _surname;

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            _firstName = firstName;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentNullException(nameof(surname));

            _surname = surname;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_surname}";
        }
    }
}

namespace v5
{
    public class Person
    {
        private string _firstName;
        private string _surname;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string FullName
        {
            get { return $"{_firstName} {_surname}"; }
        }
    }
}

namespace v6
{
    public class Person
    {
        private string _firstName;
        private string _surname;

        public Person(string firstName, string surname)
        {
            _firstName = firstName;
            _surname = surname;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string Surname
        {
            get { return _surname; }
        }

        public string FullName
        {
            get { return $"{_firstName} {_surname}"; }
        }
    }
}

namespace v7
{
    public class Person
    {
        private string _firstName;
        private string _surname;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                _firstName = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                _surname = value;
            }
        }

        public string FullName
        {
            get { return $"{_firstName} {_surname}"; }
        }
    }
}

namespace v8
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string FullName => $"{FirstName} {Surname}";
    }
}

namespace v9
{
    public class Person
    {
        public string FirstName { get; }
        public string Surname { get; }
        public string FullName => $"{FirstName} {Surname}";

        public Person(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
}

namespace v10
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }

        public Person(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
}

namespace v11
{
    public class Person
    {
        public string FirstName { get; init; }
        public string Surname { get; init; }
    }
}

namespace v12
{
    public class Person
    {
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
    }
}