/***************************************
 
 Name: Zed Trzcinski
 Class; CST 267
 Professor: Pete Myers
 Assign 1
 Date: 10/12/2016
 
 ******************************************/



using System;
using System.Collections.Generic;



namespace CST279_Assign_1
{

    class Program
    {

        static void Main(string[] args)
        {

            List<Morgs> morgses = new List<Morgs>
            {
                new MorgTypeA(0),
                new MorgTypeB(0),
                new MorgTypeC(0)
            };
            foreach (var m in morgses)
            {
                for (int l = 0; l < 2; l++)
                {
                    Assign_Roles(m);
                    feeding_time(m);
                }
              
            }
        }

        static void Assign_Roles(Morgs m)
        {
            //test function to show that an organism is moving and updating its role when the location changes

            Random randomLocation = new Random();
            int locationOnMap1 = randomLocation.Next(0, 2);
           

            m.Display();
            m.update_role();
            m.PerformMove(locationOnMap1);
            m.SetLocation(locationOnMap1);
            m.Display();
            m.update_role();   

        }

        static void feeding_time(Morgs m)
        {
            //test function for the movement and for the fighting between for the mmorgs
            Random randomLocation = new Random();
            int locationOnMap1 = randomLocation.Next(0, 2);
            int locationOnMap2 = randomLocation.Next(0, 2);
            int locationOnMap3 = randomLocation.Next(0, 2);
            m.Display();
            m.update_role();
            m.PerformMove(locationOnMap1);
            m.SetLocation(locationOnMap1);
            m.Display();
            m.update_role();
            m.Display();
            m.update_role();
            m.PerformMove(locationOnMap2);
            m.SetLocation(locationOnMap2);
            m.Display();
            m.update_role();
            m.Display();
            m.update_role();
            m.PerformMove(locationOnMap3);
            m.SetLocation(locationOnMap3);
            m.Display();
            m.update_role();
            m.Chase(locationOnMap1, locationOnMap2, locationOnMap3);
            m.PerformEat(locationOnMap1, locationOnMap2);

        }


        public class Morgs : IDisplayRole, IObserveCondition
    {
        public enum Condition
        {
            Preditaor = 2,
            Pray =1,
            Neutral =0,
            
        }

        private int _location;
        private List<IObserveCondition> _observeConditions;

        public Morgs(int location)
        {
            _location = location;
            
            _observeConditions = new List<IObserveCondition>();
        }

    

        public int Location { get { return _location; } }

        public void RegisterObserver(IObserveCondition iObserveCondition) { _observeConditions.Add(iObserveCondition);}
        public void RemoveObserver(IObserveCondition iObserveCondition) { _observeConditions.Add(iObserveCondition);}

        public void SetLocation(int location)
        {
            this._location = location;
            foreach (IObserveCondition iObserveCondition in _observeConditions)
            {
                iObserveCondition.update_role();
            }
        }
        private IMoveBehavoir _moevBehavoir;
        private IEatBehavoir _iEatBehavoir;

     


        public void SetMoveBehavior(IMoveBehavoir m)
        {
            _moevBehavoir = m;
        }

        public void SetEatBehavior(IEatBehavoir e)
        {
            _iEatBehavoir = e;
        }

        public int PerformMove(int loc)
        {

            _moevBehavoir.Move(loc);
            return loc;

        }

        public void PerformEat(int location, int secondLocation)
        {

            _iEatBehavoir.close_enough(location, secondLocation);
            
        }


        public int update_role()
        {
            if (_location == 2)
            {
                return (int) Condition.Pray;
            }
          
            if (_location == 1)
             {
                return (int)Condition.Preditaor;
             }
            
            return (int) Condition.Neutral;

        }

        public void Display()
        {
            string c = ((Condition)_location).ToString();
            Console.WriteLine("current location of organism : " + _location + " Role: " + c);
        }

        public void Chase( int loc ,int loc1 ,int loc2 )
        {
            //this function uses location of the morgs to identify the feeding pattrens 
            //Note: I will change this to a switch statement for a better design (just ran out of time!!!)

            Morgs morgA = new MorgTypeA(loc);
            Morgs morgB = new MorgTypeB(loc1);
            Morgs morgC = new MorgTypeC(loc2);
            if (morgA.update_role() == 1 && morgB.update_role() == 0 && morgC.update_role() == 0)
            {
                Console.WriteLine(" all the organism are not hungery ");
            }
            if (morgA.update_role() == 1 && morgB.update_role() == 1 && morgC.update_role() == 0)
            {
                Console.WriteLine(" all the organism are not hungery ");
            }
            if (morgA.update_role() == 0 && morgB.update_role() == 0 && morgC.update_role() == 0)
            {
                Console.WriteLine(" all the organism are not hungery ");
            }
            if (morgA.update_role() == 1 && morgB.update_role() == 1 && morgC.update_role() == 1)
            {
                Console.WriteLine(" all organisms are not facing each other ");
            }
            if (morgA.update_role() == 2 && morgB.update_role() == 2 && morgC.update_role() == 2)
            {
                Console.WriteLine("all organisms are facing each other so non are attacking!");
            }
            if (morgA.update_role() == 2 && morgB.update_role() == 1 && morgC.update_role() == 1)
            {
                Console.WriteLine(" organism A consumed  both organisms");
            }
            if (morgB.update_role() == 2 && morgA.update_role() == 1 && morgC.update_role() == 1)
            {
                Console.WriteLine(" organism B consumed  both organisms");
            }
            if (morgC.update_role() == 2 && morgA.update_role() == 1 && morgC.update_role() == 1)
            {
                Console.WriteLine(" organism C consumed  both organisms");
            }
            if (morgA.update_role() == 2 && morgB.update_role() == 1 && morgC.update_role() == 0)
            {
                Console.WriteLine(" organism A consumed  organism  B");
            }
            if (morgA.update_role() == 2 && morgB.update_role() == 0 && morgC.update_role() == 1)
            {
                Console.WriteLine(" organism A consumed  organism C");
            }
            if (morgB.update_role() == 2 && morgA.update_role() == 1 && morgC.update_role() == 0)
            {
                Console.WriteLine(" organism B consumed organism A");
            }
            if (morgB.update_role() == 2 && morgB.update_role() == 0 && morgC.update_role() == 1)
            {
                Console.WriteLine(" organism B consumed   organism C");
            }
            if (morgC.update_role() == 2 && morgB.update_role() == 1 && morgA.update_role() == 0)
            {
                Console.WriteLine(" organism C consumed organism B");
            }
            if (morgC.update_role() == 2 && morgB.update_role() == 0 && morgA.update_role() == 1)
            {
                Console.WriteLine(" organism C consumed  organism A ");
            }
        }

     

      
    }

        class MorgTypeA : Morgs
        {
            private int _typeALocation;
            private Morgs _dataMorgs;
            public MorgTypeA(int typeALocation)
                : base(typeALocation)
            {
                
                SetMoveBehavior(new Paddles());
                SetEatBehavior(new Absorb());
                SetLocation(_typeALocation);
            }



        }

        class MorgTypeB : Morgs
        {
            private int _typeBLocation;
            public MorgTypeB(int typeBLocation): base(typeBLocation)
            {
                SetEatBehavior(new EnvelopA());
                SetMoveBehavior(new Oozes());
                SetLocation(_typeBLocation);
            }

       
        }

        class MorgTypeC : Morgs
        {
            private int _typeCLocation;
            public MorgTypeC(int typeCLocation):base(typeCLocation)
            {
                SetEatBehavior(new EnvelopA());
                SetMoveBehavior(new Paddles());
                SetLocation(_typeCLocation);
            }

        }
     
    }

   
}
  
       
    

