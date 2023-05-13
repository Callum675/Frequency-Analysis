using FrequencyAnalysis;
using NUnit.Framework;
using System.Text;

[TestFixture]
public class FrequencyAnalysisTests
{
        [Test]
        public void TestFileWithNoCharacters()
        {
            string contents = "";
            string filename = "empty.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 0\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestFileWithOnlyWhitespace()
        {
            string contents = "    \t  \n  ";
            string filename = "whitespace.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 0\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
    }

        [Test]
        public void TestFileWithOneCharacter()
        {
            string contents = "a";
            string filename = "onechar.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 1\r\na (1)\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestFileWithMultipleCharacters()
        {
            string contents = "test!";
            string filename = "test.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 5\r\nt (2)\r\ne (1)\r\ns (1)\r\n! (1)\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestFileWithMixedCase()
        {
            string contents = "TeSt!";
            string filename = "mixedcase.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 5\r\nT (1)\r\ne (1)\r\nS (1)\r\nt (1)\r\n! (1)\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestFileWithCaseInsensitiveOption()
        {
            string contents = "TeSt!";
            string filename = "caseinsensitive.txt";
            File.WriteAllText(filename, contents);
            string[] args = { filename, "-c" };

            // Redirect standard output to a string builder
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Call the method to be tested
            Program.Main(args);

            // Get the string value from the string builder
            string actualOutput = sb.ToString();

            // Assert that the output matches the expected output
            string expectedOutput = "Total characters: 5\r\nt (2)\r\ne (1)\r\ns (1)\r\n! (1)\r\n";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
