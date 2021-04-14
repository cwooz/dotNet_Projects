using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            // Arrange: Ojects & values to be used
            var book = new InMemoryBook("Chris");
            book.AddGrade(88.623);
            book.AddGrade(90.500);
            book.AddGrade(77.323);



            // Act: Do something, compute actual values
            var result = book.GetStatistics();



            // Assert
            Assert.Equal(85.5, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
