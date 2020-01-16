using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;

namespace UnitTestProject
{
    /// <summary>
    /// Descripción resumida de UnitTest2
    /// </summary>
    [TestClass]
    public class UITest
    {
        public UITest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestUIBasic()
        {
            // Test d'interfície gràfica
            string rutaAlExecutable = System.AppDomain.CurrentDomain.BaseDirectory;
            rutaAlExecutable += "\\RRHHApp.exe";
            Application app = Application.Launch(rutaAlExecutable);
            TestStack.White.UIItems.WindowItems.Window w = app.GetWindows()[0];
            //--------------------------------------------
            TextBox t1 = w.Get<TextBox>("txtOp1");
            TextBox t2 = w.Get<TextBox>("txtOp2");
            int num1 = 2, num2 = 3;
            t1.Text = ""+num1;
            t2.Text = "" + num2;
            //--------------------------------------------
            Button b = w.Get<Button>("btnOperar");
            b.Click();

            TextBox tr = w.Get<TextBox>("txtRes");
            Assert.AreEqual(num1 + num2 + "", tr.Text);


        }
    }
}
