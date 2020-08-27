using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace mft.tests
{
    public class FileCollector_tests
    {
        [Fact]
        public void Collect()
        {
            File.SetCreationTime("sampleFiles/5 Another relevant file.md", new DateTime(2020,5,5));
            File.SetLastWriteTime("sampleFiles/5 Another relevant file.md", new DateTime(2020,7,14));
            
            var sut = new MDFileCollector();
            var result = sut.Collect(".").ToArray();
            
            result.Length.Should().Be(5);

            var r = result.First(x => x.Filename == "1 With a note");
            r.Path.Should().Be("./sampleFiles/a subdir/a deeper subdir");
            r.NumberOfLines.Should().Be(10);
            
            r = result.First(x => x.Filename == "5 Another relevant file");
            r.Path.Should().Be("./sampleFiles");
            r.NumberOfLines.Should().Be(7);
            r.CreatedAt.Should().Be(new DateTime(2020, 5, 5));
            r.LastChangedAt.Should().Be(new DateTime(2020, 7, 14));
        }
    }
}