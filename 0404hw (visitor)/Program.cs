using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0404hw__visitor_
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }
    public class House : IComponent
    {

        public void Accept(IVisitor visitor)
        {
            visitor.VisitHouse(this);
        }

        public string SuggestInsurance()
        {
            return "Предложить медицинскую страховку";
        }
    }

    public class Bank : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitBank(this);
        }

        public string SuggestInsurance()
        {
            return "Предложить страховку от грабежа";
        }
    }
    public class Factory : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitFactory(this);
        }

        public string SuggestInsurance()
        {
            return "Предложить страховку от пожара и наводнения";
        }
    }


    public interface IVisitor
    {
        void VisitHouse(House element);

        void VisitBank(Bank element);
        void VisitFactory(Factory element);
    }

    class InsuranceAgent : IVisitor
    {
        public void VisitHouse(House element)
        {
            Console.WriteLine(element.SuggestInsurance());
        }

        public void VisitBank(Bank element)
        {
            Console.WriteLine(element.SuggestInsurance());
        }
        public void VisitFactory(Factory element)
        {
            Console.WriteLine(element.SuggestInsurance());
        }
    }

    public class Client
    {
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            List<IComponent> Buildings = new List<IComponent>
            {
                new House(),
                new Bank(),
                new Factory()
            };
            var IA = new InsuranceAgent();
            Client.ClientCode(Buildings, IA); ;
        }
    }
}
