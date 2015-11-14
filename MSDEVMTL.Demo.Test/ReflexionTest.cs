using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSDEVMTL.Demo.Test
{
    [TestClass]
    public class ReflexionTest
    {
        [TestMethod]
        public void Verifier_TesterToutesClassesRegleDeclenchement_ToutesMethodesAppellees()
        {
            //Chargement des librairies
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
            Assembly affairesAssembly = Assembly.Load("MSDEVMTL.DEMO.Main");

            var listeClasses = affairesAssembly.GetExportedTypes()
                                .Where(t => t.Namespace != null && !t.IsInterface && t.Namespace.Contains("Critere") && t.Name.Contains("User")).ToList();

            TesterMethodeVerifierPourChaqueClasse(listeClasses);
        }

        private void TesterMethodeVerifierPourChaqueClasse(List<Type> listeClasses)
        {
            foreach (var classe in listeClasses)
            {
                if (!classe.FindMembers(MemberTypes.Method, BindingFlags.Public | BindingFlags.Instance, DelegateToSearchCriteria, "Verifier").Any())
                    Assert.Fail("La méthode <Verifier> n'a pas été trouvée pour la classe " + classe.Name +
                        ". Celle-ci doit elle être dans le namespace Demande? Si, oui, ajustez le test unitaire.");

                MethodInfo method = classe.GetMethod("Verifier");

                var classeTest = Activator.CreateInstance(classe);

                object[] listeParams = { };

                var resultat = method.Invoke(classeTest, listeParams);

                Assert.IsTrue((bool)resultat);

                //Verification des autres propriétés
                //Synchrone
                PropertyInfo propertySync = classe.GetProperty("Methode");
                var sync = propertySync.GetValue(classeTest);
                Assert.IsTrue((bool)sync);
            }
        }

        private bool DelegateToSearchCriteria(MemberInfo memberInfo, object filterCriteria)
        {
            return memberInfo.Name == filterCriteria.ToString();
        }

        static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}
