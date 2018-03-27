using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsuarioUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow(1, "Agus", "Rojas", "1234")]
        [DataTestMethod]
        public void txtTest(int id, string nombre, string apellidos, string dni, Guid guid)
        {
            ClaseAlumno alumno1 = new ClaseAlumno(id, nombre, apellidos, dni, guid);
            Assert.IsTrue(guid == alumno1.GUID);
            Assert.IsTrue(id == alumno1.ID);
            Assert.IsTrue(nombre == alumno1.NOMBRE);
            Assert.IsTrue(apellidos == alumno1.APELLIDOS);
            Assert.IsTrue(dni == alumno1.DNI);
        }

        [DataRow(1, "Agus", "Rojas", "1234")]
        [DataTestMethod]
        public void jsonTest(int id, string nombre, string apellidos, string dni, Guid guid)
        {
            ClaseAlumno alumno1 = new ClaseAlumno(id, nombre, apellidos, dni, guid);
            Assert.IsTrue(guid == alumno1.GUID);
            Assert.IsTrue(id == alumno1.ID);
            Assert.IsTrue(nombre == alumno1.NOMBRE);
            Assert.IsTrue(apellidos == alumno1.APELLIDOS);
            Assert.IsTrue(dni == alumno1.DNI);
        }
    }
}
