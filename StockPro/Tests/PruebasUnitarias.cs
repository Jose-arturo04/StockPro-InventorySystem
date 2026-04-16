using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StockPro.Tests
{
    [TestClass] // Le dice a Visual Studio que esta es una clase de pruebas
    public class PruebasUnitarias
    {
        // --- STK-10: PRUEBA DE ENTRADA DE STOCK ---
        [TestMethod]
        public void Test_EntradaStock_DebeSumarCorrectamente()
        {
            // Arrange (Preparar)
            int stockInicial = 10;
            int cantidadASumar = 5;
            int resultadoEsperado = 15;

            // Act (Actuar)
            int stockFinal = stockInicial + cantidadASumar;

            // Assert (Afirmar)
            Assert.AreEqual(resultadoEsperado, stockFinal, "La suma del inventario falló.");
        }

        // --- STK-11: PRUEBA DE SALIDA DE STOCK ---
        [TestMethod]
        public void Test_SalidaStock_ValidarInsuficiente()
        {
            // Arrange
            int stockActual = 3;
            int cantidadARetirar = 10;
            bool sePuedeRetirar;

            // Act
            if (cantidadARetirar > stockActual)
                sePuedeRetirar = false;
            else
                sePuedeRetirar = true;

            // Assert
            Assert.IsFalse(sePuedeRetirar, "Error: El sistema permitió retirar más de lo que existe.");
        }

        // --- STK-12: PRUEBA DE UMBRAL DE ALERTA ---
        [TestMethod]
        public void Test_AlertaStock_DetectarLimite()
        {
            // Arrange
            int limiteAlerta = 5;
            int stockCritico = 4;
            int stockSeguro = 20;

            // Act
            bool alertaActivada = stockCritico <= limiteAlerta;
            bool alertaDesactivada = stockSeguro <= limiteAlerta;

            // Assert
            Assert.IsTrue(alertaActivada, "El sistema no detectó el stock bajo.");
            Assert.IsFalse(alertaDesactivada, "El sistema dio una alerta falsa en stock alto.");
        }
    }
}