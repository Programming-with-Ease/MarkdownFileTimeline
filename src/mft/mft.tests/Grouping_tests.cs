using System;
using System.Collections;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace mft.tests
{
    public class Grouping_tests
    {
        [Fact]
        public void Group()
        {
            var files = new[] {
                // week 33
                new_File("GGG", new DateTime(2020,8,14)), // Fri
                
                
                // week 35
                new_File("A", new DateTime(2020,8,25)), // Tue
                new_File("B2", new DateTime(2020,8,24)), // Mon

                // week 34
                new_File("CCc", new DateTime(2020,8,23, 10,0,0)), // Sun
                new_File("CCa", new DateTime(2020,8,23, 8,0,0)),
                
                new_File("EE", new DateTime(2020,8,20)), // Thu
                
                new_File("FFF", new DateTime(2020,8,17)), // Mon

                                
                // week 35 again
                new_File("B2", new DateTime(2020,8,24)),

                
                // week 34 again
                new_File("D", new DateTime(2020,8,21)), // Fri
                
                new_File("CCb", new DateTime(2020,8,23, 9,0,0))
            };


            var result = Grouping.Group(files).ToArray();

            result.Select(x => x.Number).Should().BeInDescendingOrder();
            
            var days = result.SelectMany(x => x.Days);
            days.Select(x => x.Date).Should().BeInDescendingOrder();
            
            result.Length.Should().Be(3);
            result[1].Number.Should().Be(34);
            result[1].Days.ToArray().Length.Should().Be(4);
            result[1].Days.First().Date.Should().Be(new DateTime(2020, 8, 23));
            result[1].Days.First().Files.Count().Should().Be(3);

            
            MDFile new_File(string name, DateTime date)
                => new MDFile(name, name.Length, date, date);
        }
    }
}