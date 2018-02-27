using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
            // Чтение памяти
            vm.RegisterCommand('.', b => { write((char)b.Memory[b.MemoryPointer]); });
            // Запись в память
            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte)read(); });
            // Увеличить значение ячейки
            vm.RegisterCommand('+', b => 
            {
                if (b.Memory[b.MemoryPointer] == 255) b.Memory[b.MemoryPointer] = 0;
                else b.Memory[b.MemoryPointer]++;
            });
            // Уменьшить значение ячейки
			vm.RegisterCommand('-', b => 
            {
                if (b.Memory[b.MemoryPointer] == 0) b.Memory[b.MemoryPointer] = 255;
                else b.Memory[b.MemoryPointer]--;
            });
            // Сдвинуть указатель на ячейку на +1
            vm.RegisterCommand('>', b => 
            {
                if (b.MemoryPointer == b.Memory.Length - 1) b.MemoryPointer = 0;
                else b.MemoryPointer++;
            });
            // Сдвинуть указатель на ячейку на -1
            vm.RegisterCommand('<', b => 
            {
                if (b.MemoryPointer == 0) b.MemoryPointer = b.Memory.Length - 1;
                else b.MemoryPointer--;
            });
            // Добавление обработки других символов
            AddNewKeys('A', 'Z', vm);
            AddNewKeys('a', 'z', vm);
            AddNewKeys('0', '9', vm);
        }

        private static void AddNewKeys(char v1, char v2, IVirtualMachine vm)
        {
            for (int i = v1; i <= v2; i++)
            {
                var item = i;
                vm.RegisterCommand((char)item, b => { b.Memory[vm.MemoryPointer] = (byte)item; });
            }
        }
    }
}