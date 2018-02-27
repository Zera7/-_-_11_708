using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
        public string Instructions { get; }
        public int InstructionPointer { get; set; }
        public byte[] Memory { get; } = new byte[30000];
        public int MemoryPointer { get; set; } = 0;

        Dictionary<char, Action<IVirtualMachine>> actions = new Dictionary<char, Action<IVirtualMachine>>();

		public VirtualMachine(string program, int memorySize)
		{
            Instructions = program;
            Memory = new byte[memorySize];
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            actions.Add(symbol, execute);
		}

        public void Run()
        {
            while (InstructionPointer < Instructions.Length)
            {
                if (actions.ContainsKey(Instructions[InstructionPointer]))
                    actions[Instructions[InstructionPointer]](this);
                InstructionPointer++;
            }
        }
	}
}