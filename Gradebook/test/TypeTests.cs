using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CSharpIsPassByValue()               // Passing by VALUE is default behavior for C#
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);         // NOT: "New Name"
        }

        private void GetBookSetName(InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
            book.Name = newName;                        // Trying to 'force' for purpose of testing
        }


        [Fact]
        public void CSharpCanPassByReference()          // But can pass by REFERENCE, by adding keyword: ref (or out)
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByReference(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);       // NOT: "Book 1"
        }

        private void GetBookSetNameByReference(ref InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string newName)
        {
            book.Name = newName;
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        static InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }


        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);                                /*  Variable 'x' is unaffected by parameter 'y' in SetInt(y)
            SetInt(ref x);                                Unless passing by 'ref' and using keyword in both places ***   */

            Assert.Equal(3, x);
        }

        private void SetInt(int y)                      // *** SetInt(ref int y)
        {
            y = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";                      // Strings are 'ref' types but immutable like 'value' types
            var toUpper = MakeUpperCase(name);          // So, string methods all return a copy of original string

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", toUpper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
