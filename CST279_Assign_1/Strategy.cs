using System;



namespace CST279_Assign_1
{
    interface IObserveCondition
    {
        int update_role();
        void Chase(int loc, int loc1, int loc2);
    }

    interface IDisplayRole
    {
        void Display();
    }
    interface IMoveBehavoir
       {
           int Move(int loc1);
          
       }

       interface IEatBehavoir
       {
           void Eat();
           void close_enough(int loc1, int loc2);
       }
       
       class Paddles : IMoveBehavoir
       {
           
           public int Move(int loc1)
           {
               Console.WriteLine("Organism is paddling");
               return loc1;

           }

         
       }

       class Oozes : IMoveBehavoir
       {

           public int Move(int loc1)
           {
               Console.WriteLine("Organism is oozing");
               return loc1;

           }

         
       }

       class Absorb : IEatBehavoir
       {
           public void Eat()
           {
               Console.WriteLine("you have been absorbed!"); 

           }

           public void close_enough(int loc1, int loc2)
           {
               if (loc1 == loc2)
               {
                   Eat();

               }
               else
               {
                   Console.WriteLine("could not feed!");
               }
           }
       }

       class EnvelopA : IEatBehavoir
       {
           public void Eat()
           {
               Console.WriteLine("you have been enveloped!"); 

               
           }

           public void close_enough(int loc1,int loc2)
           {
               if (loc1 == loc2)
               {
                   Eat();

               }
               else
               {
                   Console.WriteLine("could not feed!");
               }
               
           }
       }

   

     
   }

