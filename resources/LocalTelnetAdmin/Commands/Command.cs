using System;

namespace LocalTelnetAdmin.Commands
{
    public class Command
    {
        public Command(string methodName, string className)
        {
            this.MethodName = methodName;
            this.ClassName = className;
        }

        public string MethodName { get; set; }

        public string ClassName { get; set; }
    }
}