using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base (id, manufacturer, model, price, overallPerformance)
        {     
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;  

        public void AddComponent(IComponent component)
        {

            if (Components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format
                (ExceptionMessages.ExistingComponent,
                component.GetType().Name, GetType().Name, Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format
                (ExceptionMessages.ExistingPeripheral,
                peripheral.GetType().Name, GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                   componentType, GetType().Name, Id));
            }
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var periperial = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (periperial == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                   peripheralType, GetType().Name, Id));
            }
            peripherals.Remove(periperial);
            return periperial;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {OverallPerformance}. Price: {Price} - {typeof(Product).Name}: {Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({Components.Count}):");
            foreach (var item in Components)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance)}):");
            foreach (var item in Peripherals)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
