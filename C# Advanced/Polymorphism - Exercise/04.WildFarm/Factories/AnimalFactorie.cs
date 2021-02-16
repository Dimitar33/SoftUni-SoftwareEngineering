using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class AnimalFactorie
    {
        public static Animal CreateAnimal(string[] cmd)
        {
            
            double wight = double.Parse(cmd[2]);

            switch (cmd[0])
            {

                case nameof(Cat):
                    return new Cat(cmd[1], wight, cmd[3], cmd[4]);

                case nameof(Dog):
                    return new Dog(cmd[1], wight, cmd[3]);

                case nameof(Hen):
                    return new Hen(cmd[1], wight, double.Parse(cmd[3]));

                case nameof(Mouse):
                    return new Mouse(cmd[1], wight, cmd[3]);

                case nameof(Owl):
                    return new Owl(cmd[1], wight, double.Parse(cmd[3]));

                case nameof(Tiger):
                    return new Tiger(cmd[1], wight, cmd[3], cmd[4]);

                default:

                    throw new Exception();                    
                   
            }

        }
    }
}
