using CSharpFunctionalExtensions;

namespace EFCorePractice.Entitites
{
    public class Name : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; set; }
        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }   
        public static Result<Name> Create(string firstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<Name>("First name is required");
            if (string.IsNullOrWhiteSpace(LastName))
                return Result.Failure<Name>("Last name is required");

            firstName = firstName.Trim();
            LastName = LastName.Trim();

            if (firstName.Length > 100)
                return Result.Failure<Name>("First name is too long");
            if (LastName.Length > 100)
                return Result.Failure<Name>("Last name is too long");
            return Result.Success(new Name(firstName, LastName));
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
