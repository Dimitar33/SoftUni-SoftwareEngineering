using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> parts;
        private readonly List<IPeripheral> peroperals;

        public Controller()
        {
            computers = new List<IComputer>();
            parts = new List<IComponent>();
            peroperals = new List<IPeripheral>();
        }

        public string AddComponent(
                int computerId, int id, string componentType,
                string manufacturer, string model, decimal price,
                double overallPerformance, int generation)
        {
            NonExistingComp(computerId);

            if (parts.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            if (componentType != "CentralProcessingUnit" &&
                componentType != "Motherboard" &&
                componentType != "PowerSupply" &&
                componentType != "RandomAccessMemory" &&
                componentType != "SolidStateDrive" &&
                componentType != "VideoCard")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent part = null;

            if (componentType == "CentralProcessingUnit")
            {
                part = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                part = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                part = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                part = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                part = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                part = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            var comp = computers.FirstOrDefault(x => x.Id == computerId);
            parts.Add(part);
            comp.AddComponent(part);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

        }

        public string AddComputer(string computerType, int id,
                        string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            if (computerType != "Laptop" && computerType != "DesktopComputer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer comp;
            if (computerType == "Laptop")
            {
                comp = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                comp = new DesktopComputer(id, manufacturer, model, price);
            }

            computers.Add(comp);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(
                int computerId, int id, string peripheralType,
                string manufacturer, string model, decimal price,
                double overallPerformance, string connectionType)
        {
            NonExistingComp(computerId);

            if (peroperals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            if (peripheralType != "Headset" &&
                peripheralType != "Keyboard" &&
                peripheralType != "Monitor" &&
                peripheralType != "Mouse")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral part = null;

            if (peripheralType == "Headset")
            {
                part = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                part = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                part = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                part = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            var comp = computers.FirstOrDefault(x => x.Id == computerId);
            peroperals.Add(part);
            comp.AddPeripheral(part);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

        }

        public string BuyBest(decimal budget)
        {

            if (computers.Count == 0 || !computers.Any(x => x.Price <= budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var comps = computers.OrderByDescending(x => x.OverallPerformance).ThenByDescending(x => x.Price).ToList();

            var comp = comps.First();
            computers.Remove(comp);

            return comp.ToString();
        }

        public string BuyComputer(int id)
        {
            NonExistingComp(id);

            var comp = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(comp);

            return comp.ToString();
        }

        public string GetComputerData(int id)
        {
            NonExistingComp(id);

            var comp = computers.FirstOrDefault(x => x.Id == id);

            return comp.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            NonExistingComp(computerId);

            var comp = computers.FirstOrDefault(x => x.Id == computerId);

            var component = comp.RemoveComponent(componentType);
            parts.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            NonExistingComp(computerId);

            var comp = computers.FirstOrDefault(x => x.Id == computerId);

            if (comp.Peripherals.Any(x => x.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, comp.GetType().Name, computerId));
            }

            var per = comp.RemovePeripheral(peripheralType);
            peroperals.Remove(per);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, per.Id);
        }

        private void NonExistingComp(int id)
        {

            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
