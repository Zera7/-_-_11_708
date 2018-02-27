using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static Dictionary<int, int> BracketBegin = new Dictionary<int, int>();
        public static Dictionary<int, int> BracketEnd = new Dictionary<int, int>();
        public static Stack<int> Buffer = new Stack<int>();

        public static void RegisterTo(IVirtualMachine vm)
        {
            FindBrackets(vm);
            vm.RegisterCommand('[', b =>
            {
                if (b.Memory[b.MemoryPointer] == 0)
                    b.InstructionPointer = BracketBegin[b.InstructionPointer];
            });
            vm.RegisterCommand(']', b =>
            {
                if (b.Memory[b.MemoryPointer] != 0)
                    b.InstructionPointer = BracketEnd[b.InstructionPointer];
            });
        }

        // Находит все скобки и ставит их в соответствие друг-другу в словари
        public static void FindBrackets(IVirtualMachine vm)
        {
            for (var i = 0; i < vm.Instructions.Length; i++)
            {
                if (vm.Instructions[i] == '[') Buffer.Push(i);
                else if (vm.Instructions[i] == ']')
                {
                    BracketEnd[i] = Buffer.Peek();
                    BracketBegin[Buffer.Pop()] = i;
                }
            }
        }
    }
}