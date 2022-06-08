using BiblioRecu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {

        String msg = "";
        String prova = "";
        String[] vdades;

        ClProveidorProves proveidor = null;
        ClRecu recu = new ClRecu();

        [TestMethod]
        public void QuinesConsonants()
        {
            List<Char> llistaResultat = new List<Char>();

            llistaResultat.Add('H');
            llistaResultat.Add('l');

            CollectionAssert.AreEqual(llistaResultat, recu.QuinesConsonants("Hola"));
        }

        [TestMethod]
        public void TestParaulesMesRepetides()
        {
            List<Char> llistaResultat = new List<Char>();

            llistaResultat.Add('E');
            llistaResultat.Add('A');
            llistaResultat.Add('O');

            CollectionAssert.AreEqual(llistaResultat, recu.VocalsMesRepetides("El riu de Vilanova", "El parc de Granollers"));
        }

        [TestMethod]
        public void provaCodifica()
        {
            proveidor = new ClProveidorProves("CriptoEncode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        Assert.AreEqual(vdades[2], recu.Codifica(vdades[0], Int32.Parse(vdades[1])), msg);
                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void provaDescodifica()
        {
            proveidor = new ClProveidorProves("CriptoDecode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova + vdades.Length);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        Assert.AreEqual(vdades[2], recu.Descodifica(vdades[0], Int32.Parse(vdades[1])), msg);

                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
    }
}
