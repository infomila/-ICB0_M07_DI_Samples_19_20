using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RRHHApp.model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Persona_constructor()
        {
            Boolean haPetat = false;
            try
            {
                Persona p = new Persona("XXXX", "Paco", DateTime.Today);                
            }
            catch (Exception e)
            {
                haPetat = true;
            }

            if(!haPetat)
            {
                Assert.Fail("No podem crear persones amb NIF incorrecte");
            }

           /* Assert.AreEqual("XXXX" , p.NIF );
            Assert.AreEqual("Paco", p.Nom );
            Assert.AreEqual(DateTime.Today, p.DataNaixement);*/
        }
    }
}
