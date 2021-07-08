namespace NameGenerator
{
    public interface IPersonNameGenerator
    {
        string GenerateRandomLastName();

        string GenerateRandomFirstName();

        string GenerateRandomFemaleFirstName();

        string GenerateRandomMaleFirstName();
    }
}