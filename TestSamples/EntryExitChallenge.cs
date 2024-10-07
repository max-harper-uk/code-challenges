using System.Collections.Concurrent;

namespace CodingChallengeSolutions
{
    public class PersonPresenceList
    {
        private readonly ConcurrentDictionary<string, PersonPresenceRecord> records = [];

        public void LogEntry(string name)
        {
            records.AddOrUpdate(name, 
                record => new PersonPresenceRecord().LogEntry(), 
                (name, record) => record.LogEntry());
        }

        public void LogExit(string name)
        {
            records.AddOrUpdate(name,
                record => new PersonPresenceRecord().LogExit(),
                (name, record) => record.LogExit());
        }

        public string[] GetNamesForEntryWithoutExit()
            => records.Where(p => p.Value.EntriesWithoutExit > 0).Select(p => p.Key).ToArray();

        public string[] GetNamesForExitWithoutEntry()
            => records.Where(p => p.Value.ExitsWithoutEntry > 0).Select(p => p.Key).ToArray();

        public static PersonPresenceList ProcessEntryLogs(string[][] records)
        {
            var personPresenceList = new PersonPresenceList();
            foreach (var record in records)
            {
                var name = record[0];
                if (string.IsNullOrEmpty(name)) continue;

                var movement = record[1];
                if (movement.Equals("entry"))
                {
                    personPresenceList.LogEntry(name);
                }
                else if (movement.Equals("exit"))
                {
                    personPresenceList.LogExit(name);
                }
            }

            return personPresenceList;
        }

        internal class PersonPresenceRecord
        {
            private bool isPresent = false;

            private int entriesWithoutExit = 0;
            public int EntriesWithoutExit { get { return isPresent ? entriesWithoutExit + 1 : entriesWithoutExit; } }
            
            
            private int exitsWithoutEntry = 0;
            public int ExitsWithoutEntry { get { return exitsWithoutEntry; } }
            
            public PersonPresenceRecord LogEntry()
            {
                if (isPresent) { entriesWithoutExit++; }
                else { isPresent = true; }
                
                return this;
            }

            public PersonPresenceRecord LogExit()
            {
                if(isPresent) { isPresent = false; }
                else { exitsWithoutEntry++; }
                
                return this;
            }
        }
    }
}
