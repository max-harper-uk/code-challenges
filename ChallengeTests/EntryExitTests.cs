using CodingChallengeSolutions;
using FluentAssertions;
using System.Collections;

namespace ChallengeTests
{
    public class EntryExitTests
    {
        [Theory]
        [ClassData(typeof(EntryExitTestData))]
        public void GivenLogsShouldIdentifyEntriesWithoutExit(string[][] logs)
        {
            //Arrage
            var personPresenceList = PersonPresenceList.ProcessEntryLogs(logs);

            //Act
            var result = personPresenceList.GetNamesForEntryWithoutExit();

            //Assert
            result.Should().BeEquivalentTo("Jack", "Susan", "Steve", "Joanne");        
        }

        [Theory]
        [ClassData(typeof(EntryExitTestData))]
        public void GivenLogsShouldIdentifyExitsWithoutEntry(string[][] logs)
        {
            //Arrage
            var personPresenceList = PersonPresenceList.ProcessEntryLogs(logs);

            //Act
            var result = personPresenceList.GetNamesForExitWithoutEntry();

            //Assert
            result.Should().BeEquivalentTo("Steve", "Joanne", "David");
        }

        public class EntryExitTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new string[][]
                    {                       // IsInList | IsInOffice | EntryWithoutExit | ExitWithoutEntry
                                            //          | false      | 0                | 0
                                            // -------- | ---------- | ---------------- | -----------------
                        ["Paul", "entry"],  // No       | true       | 0                | 0
                        ["Sarah", "entry"], // No       | true       | 0                | 0
                        ["Jack", "entry"],  // No       | true       | 0                | 0
                        ["Susan", "entry"], // No       | true       | 0                | 0
                        ["Steve", "exit"],  // No       | false      | 0                | 1
                        ["Paul", "exit"],   // Yes      | false      | 0                | 0
                        ["Joanne", "exit"], // No       | false      | 0                | 1
                        ["Sarah", "exit"],  // Yes      | false      | 0                | 0
                        ["Jack", "entry"],  // Yes      | true       | 1                | 0
                        ["Joanne", "entry"],// Yes      | true       | 0                | 1
                        ["David", "exit"],  // No       | false      | 0                | 1
                        ["Steve", "entry"], // Yes      | true       | 0                | 1
                        // End of Day -----------------------------------------------------------------------
                        // EntryWithoutExit assumed for names where IsInOffice is true
                        // ["Jack", "Susan", "Steve", "Joanne"]
                    }
                };

                /*
                 *  Is name in list ? (Can use dictionary of name & presence data type)
                 *      Yes:
                 *          Entry : IsInOffice ?
                 *              Yes : EntryWithoutExit ++1 
                 *              No  : IsInOffice = Yes
                 *          Exit : IsInOffice ?
                 *              Yes : IsInOffice = No 
                 *              No  : ExitWithOutEntry ++ 1    
                 *      No:
                 *          Entry : IsInOffice = true; EntryWithoutExit = false (default); ExitWithoutEntry = false (default);
                 *          Exit  : IsInOffice = false; EntryWithoutExit = false (default); ExitWithoutEntry = true;          
                 *          
                 *    After all names have been processed, add 1 to EntryWithoutExit where IsInOffice == true
                 */
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}