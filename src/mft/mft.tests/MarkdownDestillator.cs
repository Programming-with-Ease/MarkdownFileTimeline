using FluentAssertions;
using mft.adapters;
using Xunit;

namespace mft.tests
{
    public class MarkdownDestillator
    {
        [Fact]
        public void Empty()
        {
            new[] {""}.Excerpt().Should().Be("");
            new[] {"","  ","\t","","", "", " ", "  ", "   ", "    ", "x"}.Excerpt().Should().Be("");
        }
        
        [Fact]
        public void Not_empty_from_first_10_lines() {
            new[] {" X "}.Excerpt().Should().Be("X");
            new[] {"","  ","\t","","", "", " ", "  ", "   ", "x"}.Excerpt().Should().Be("x");
            new[] {"","  ","\t","","", "a", " ", "  ", " b b  ", "x"}.Excerpt().Should().Be("a b b x");
        }
        
        [Fact]
        public void Not_empty_from_headlines() {
            new[] {"# a"}.Excerpt().Should().Be("# a");
            new[] {"","  ","\t","","", "## b", " ", "  ", "   ", "x"}.Excerpt().Should().Be("## b");
            new[] {"","  ","\t","","", "### c", " ", "  # d", "   ", "x"}.Excerpt().Should().Be("### c");
        }
        
        [Fact]
        public void Long_headline() {
            new[] {"1234567890123456789012345678901234567890"}.Excerpt().Should().Be("1234567890123456789012345678901234567890");
            new[] {"1234567890123456789012345678901234567890X"}.Excerpt().Should().Be("1234567890123456789012345678901234567890...");
        }
    }
}