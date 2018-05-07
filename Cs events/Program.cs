using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Basic C# events
 */
namespace Cs_events
{

    /// <summary> Publisher class </summary>
    class X
    {
        // A delegate is a type that represents references to methods with a particular parameter list and return type
        // it supports += and -= operations
        public delegate int ChangeHandle(String s);

        // Events enable a class or object to notify other classes or objects when something of interest occurs.
        // The class that sends (or raises) the event is called the publisher and the classes that receive (or handle) the event are called subscribers.
        //
        // An event has += and -= public and = private
        // i.e. from outside you can do ChangeEvent += ...
        // but ChangeEvent = ...; or ChangeEvent() only from X
        public event ChangeHandle ChangeEvent;


        public void UnsubscribeAllChangeHandlers()
        {
            ChangeEvent = null;
        }

        /// <summary>
        /// triger the event
        /// </summary>
        /// <param name="s">string to be passed to the event handlers</param>
        public void DoChange(String s)
        {
            // when no handles are added to the event, the event (actually the hiden flag) is set to null
            // so we need to protect
            //
            // this is equivalent with:
            //
            // if (ChangeEvent != null)
            //     ChangeEvent(s);

            ChangeEvent?.Invoke(s);
        }

    }

    class Program
    {
        static int F4(String s) { Console.WriteLine("f4: " + s); return 4; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            X x = new X();

            x.ChangeEvent += (String s) => { Console.WriteLine("h1: " + s); return 1; };
            x.ChangeEvent += (String s) => { Console.WriteLine("h2: " + s); return 2; };

            // to be able to unsubscrive a handle you need to remember the handle. I.e. don't use lambdas or anonymous functions
            x.ChangeEvent += F4;
            X.ChangeHandle h3 = (String s) => { Console.WriteLine("h3: " + s); return 1; };
            x.ChangeEvent += h3;

            x.DoChange("asd");

            Console.WriteLine("====");

            x.ChangeEvent -= F4;
            x.ChangeEvent -= h3;

            x.DoChange("yolo");

            x.UnsubscribeAllChangeHandlers();

            Console.WriteLine("====");
            x.DoChange("nothing");


            Console.WriteLine("Done");
        }
    }
}

// Output:
/*

Hello
h1: asd
h2: asd
f4: asd
h3: asd
====
h1: yolo
h2: yolo
====
Done

 */
