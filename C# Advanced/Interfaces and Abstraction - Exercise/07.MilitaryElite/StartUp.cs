using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            List<Soldier> soldiers = new List<Soldier>();
            List<Private> privates = new List<Private>();

            while (cmd[0] != "End")
            {
                int id = int.Parse(cmd[1]);
                string firstName = cmd[2];
                string lastName = cmd[3];

                switch (cmd[0])
                {
                    case "Private":

                        Private priv = new Private(id, firstName, lastName, decimal.Parse(cmd[4]));

                        privates.Add(priv);
                        soldiers.Add(priv);

                        break;
                    case "LieutenantGeneral":

                        LieutenantGeneral leuteneant = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(cmd[4]));

                        int[] ids = cmd.Skip(5).Select(int.Parse).ToArray();

                        for (int i = 0; i < ids.Length; i++)
                        {
                            leuteneant.Privates.Add(privates.FirstOrDefault
                                (c => c.Id == ids[i]));
                        }

                        soldiers.Add(leuteneant);

                        break;
                    case "Engineer":

                        try
                        {
                            string[] jobs = cmd.Skip(6).ToArray();
                            List<Repairs> repairs = new List<Repairs>();

                            for (int i = 0; i < jobs.Length - 1; i += 2)
                            {
                                Repairs repair =
                                    new Repairs(jobs[i], int.Parse(jobs[i + 1]));

                                repairs.Add(repair);
                            }

                            Engineer engineer = new Engineer(id, firstName, lastName, decimal.Parse(cmd[4]), cmd[5], repairs);

                            soldiers.Add(engineer);

                        }
                        catch (Exception)
                        {

                            
                        }
                       

                        break;
                    case "Commando":

                        try
                        {
                            string[] tasks = cmd.Skip(6).ToArray();

                            List<Missions> missions = new List<Missions>();

                            for (int i = 0; i < tasks.Length - 1; i += 2)
                            {
                                try
                                {
                                    Missions mision =
                                    new Missions(tasks[i], tasks[i + 1]);

                                    missions.Add(mision);
                                }
                                catch (Exception)
                                {

                                    
                                }
                                
                            }

                            Commando commando = new Commando(id, firstName, lastName, decimal.Parse(cmd[4]), cmd[5], missions);

                            soldiers.Add(commando);

                        }
                        catch (Exception)
                        {

                            
                        }
                        

                        break;
                    case "Spy":

                        Spy spy = new Spy(id, firstName, lastName, int.Parse(cmd[4]));

                        soldiers.Add(spy);

                        break;
                    default:
                        break;
                }

                cmd = Console.ReadLine().Split();
            }

            

            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
