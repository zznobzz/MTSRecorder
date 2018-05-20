using System.Collections.Generic;

namespace MTSRecorder.Model
{
    public class Value
    {
        public string Number { get; set; }
        public int CallType { get; set; }
        public string CallTime { get; set; }
        public string Duration { get; set; }
        public string FileName { get; set; }
    }

    public class RootObject
    {
        public List<Value> Value { get; set; }
        public bool Success { get; set; }
        public object Error { get; set; }
        public bool Failure { get; set; }
    }
}