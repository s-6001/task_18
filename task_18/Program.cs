using System;
using System.Collections.Generic;
using System.Linq;

namespace task_18
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите выражение со скобками (), [] или {}:");
                string line = Console.ReadLine();   //считываем строку
                char[] charArray = line.ToCharArray();  //конвертируем в массив символов
                List<char> charList = charArray.ToList<char>(); //конвертируем в list
                Stack<char> stackClosed = new Stack<char>();    //создаем стек для закрывающихся скобок
                bool mistake = false;   //mistake==true - выражеине со скобками не корректно
                for (int i = 0; i < charList.Count; i++)    //проходим циклом по charList
                {
                    try     //обрабатываем исключение если stackClosed окажется пустым
                    {
                        if (charList[i] == '(') //если встречаем (
                        {
                            stackClosed.Push(')');  //помещаем в стек )
                        }
                        if (charList[i] == '[')
                        {
                            stackClosed.Push(']');
                        }
                        if (charList[i] == '{')
                        {
                            stackClosed.Push('}');
                        }
                        if (charList[i] == '}' && stackClosed.Peek() == '}')    //если встречаем } и в стеке }
                        {
                            stackClosed.Pop();  //то удаляем из стека 
                            continue;   //продолжаем цикл
                        }
                        if (charList[i] == '}' && stackClosed.Peek() != '}')    //если встречаем } и в стеке не }
                        {
                            mistake = true;
                            break;  //прерываем цикл
                        }
                        if (charList[i] == ']' && stackClosed.Peek() == ']')    
                        {
                            stackClosed.Pop();
                            continue;
                        }
                        if (charList[i] == ']' && stackClosed.Peek() != ']')
                        {
                            mistake = true;
                            break;
                        }
                        if (charList[i] == ')' && stackClosed.Peek() == ')')
                        {
                            stackClosed.Pop();
                            continue;
                        }
                        if (charList[i] == ')' && stackClosed.Peek() != ')')
                        {
                            mistake = true;
                            break;
                        }
                    }
                    catch
                    {
                        mistake = true;
                    }
                }
                if (stackClosed.Count == 0 && mistake == false)
                {
                    Console.WriteLine("Скобки расставлены верно.");
                }
                else
                {
                    Console.WriteLine("Скобки расставлены не корректно.");
                }
                Console.WriteLine();
            }
        }
    }
}
