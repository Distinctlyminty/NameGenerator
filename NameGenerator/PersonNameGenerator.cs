using System;

namespace NameGenerator
{
    public class PersonNameGenerator : BaseNameGenerator, IPersonNameGenerator
    {
        private const string MaleFile = "dist.male.first.stripped";
        private const string FemaleFile = "dist.female.first.stripped";
        private const string LastNameFile = "dist.all.last.stripped";
        private static string[] _maleFirstNames;
        private static string[] _femaleFirstNames;
        private static string[] _lastNames;

        public PersonNameGenerator()
        {
            InitNames();
        }

        public PersonNameGenerator(Random randGen) : base(randGen)
        {
            if (randGen == null) throw new ArgumentNullException(nameof(randGen));

            InitNames();
        }

        private bool RandomlyPickIfNameIsMale => RandGen.Next(0, 2) == 0;

        public string GenerateRandomLastName()
        {
            var index = RandGen.Next(0, _lastNames.Length);

            return _lastNames[index];
        }

        public string GenerateRandomFirstName()
        {
            return !RandomlyPickIfNameIsMale
                ? GenerateRandomFemaleFirstName()
                : GenerateRandomMaleFirstName();
        }

        public string GenerateRandomFemaleFirstName()
        {
            var index = RandGen.Next(0, _femaleFirstNames.Length);

            return _femaleFirstNames[index];
        }

        public string GenerateRandomMaleFirstName()
        {
            var index = RandGen.Next(0, _maleFirstNames.Length);

            return _maleFirstNames[index];
        }


        private static void InitNames()
        {
            _maleFirstNames ??= ReadResourceByLine(MaleFile);

            _femaleFirstNames ??= ReadResourceByLine(FemaleFile);

            if (_lastNames != null)
                return;

            _lastNames = ReadResourceByLine(LastNameFile);
        }
    }
}