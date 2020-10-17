using System;

namespace Automapper_Bug_Report_10_1_1
{
    public class TestDtoWorkaround
    {
        public Guid Id { get; set; }

        public string Initials { get; set; } //ex: 'John Q.' or 'J. Q.' or 'J.Q.' or 'J.'

        public string GivenName { get; set; } //also known as 'first name'

        public string MiddleName { get; set; } //could be a church name

        public string FamilyNamePaternal { get; set; }

        public string FamilyNameInsertion { get; set; } //insertion between paternal and maternal name, or vice-versa

        public string FamilyNameMaternal { get; set; }

        public string GenerationalName { get; set; } //ex: 'Ze' 毛泽东 (Mao Ze Dong), name shared with all siblings.

        public string AbbreviatedTitle { get; set; } //ex: 'mba'

        public string FullTitle { get; set; } //ex: 'master of business'

        public string RelationalName { get; set; } //ex: 'son' or 'daughter', postfixed after lastname, Björk Guðmundsdóttir

        public string Gender { get; set; }

        public string ShortSalutation { get; set; }

        public string FormalSalulation { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public string GenerateShortSalutation()
        {
            throw new AccessViolationException("Automapper isn't supposed to run this method");
        }

        public string GenerateFormalSalutation()
        {
            throw new AccessViolationException("Automapper isn't supposed to run this method");
        }
    }
}
